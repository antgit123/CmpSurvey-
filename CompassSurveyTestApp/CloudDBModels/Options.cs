using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace CompassSurveyTestApp.CloudDBModels
{
    public partial class Options
    {
        public int Id { get; set; }
        public string OptionId { get; set; }
        public string OptionText { get; set; }
        public int? QuestionId { get; set; }
        [JsonIgnore]
        public Questions Question { get; set; }
    }
}
