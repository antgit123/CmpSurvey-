using System;
using System.Collections.Generic;

namespace CompassSurveyTestApp.Models
{
    public partial class Survey
    {
        public Survey()
        {
            Questions = new HashSet<Questions>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<Questions> Questions { get; set; }
    }
}
