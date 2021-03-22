using System;
using System.Collections.Generic;
using Newtonsoft.Json;

/*
This is the model file which maps to the options table in the database  
Fields are:
1. OptionId (string)- the unique option Id of the option
2. OptionText (string)- the option text shown as a response to the survey question
*/

namespace CompassSurveyTestApp.Models
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
