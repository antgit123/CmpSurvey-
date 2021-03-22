using System;
using System.Collections.Generic;

/*
This is the model file which maps to the Survey table in the database  
Fields are:
1. name (string)- the name of the survey
2. Questions (Collection List) - the list of question entities linked to the survey
*/

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
