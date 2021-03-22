using System;
using Xunit;
using CompassSurveyTestApp.Controllers;
using CompassSurveyTestApp.Models;

namespace CompassSurveyUnitTest
{
    public class UnitTest1
    {
        [Fact]
        public void Test1()
        {
            CompassDBContext dbContext = new CompassDBContext();
           // var surveyController = new SurveysController(dbContext);
            //var survey = await surveyController.GetSurvey(1);
            Assert.Equal(4, Add(2, 2));
        }


        [Fact]
        public void FailingTest()
        {
            Assert.Equal(5, Add(2, 2));
        }

        int Add(int x, int y)
        {
            return x + y;
        }
    }
}
