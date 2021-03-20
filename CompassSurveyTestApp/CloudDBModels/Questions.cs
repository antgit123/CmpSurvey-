using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace CompassSurveyTestApp.CloudDBModels
{
    public partial class Questions
    {
        public Questions()
        {
            Options = new HashSet<Options>();
        }

        public int Id { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedDataTime { get; set; }
        public string Title { get; set; }
        public string Subtitle { get; set; }
        public int? QuestionType { get; set; }
        public int? SurveyId { get; set; }
        [JsonIgnore]
        public Survey Survey { get; set; }
        public ICollection<Options> Options { get; set; }
    }
}
