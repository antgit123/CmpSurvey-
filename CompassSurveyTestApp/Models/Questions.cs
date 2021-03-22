using System;
using System.Collections.Generic;
using Newtonsoft.Json;

/*
This is the model file which maps to the Questions table in the database  
Fields are:
1. createBy (string)- the name of the question author
2. createdDataTime (DateTime)- the date time when the question was created 
3. title (string)- the title of the question 
4. subtitle (string)- the subtitle of the question
5. Options (Collection List) - the list of option entities linked to the question
6. surveyId (integer) - the foreign key id of the survey the question is linked to 
7. question type (integer) - Integer representing the question type 
*/

namespace CompassSurveyTestApp.Models
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
