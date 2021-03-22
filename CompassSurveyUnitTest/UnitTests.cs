using System;
using Xunit;
using CompassSurveyTestApp.Controllers;
using CompassSurveyTestApp.Models;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System.Threading.Tasks;

namespace CompassSurveyUnitTest
{
    public class UnitTests
    {
        [Fact]
        public async Task Verify_IncorrectSurveyCreation()
        {
            var mockDBContext = new Mock<CompassDBContext>();
            var surveyController = new SurveysController(mockDBContext.Object);            
            surveyController.ModelState.AddModelError("error", "Incorrect data");
            // Act
            var result = await surveyController.PostSurvey(null);
            // Assert
            Assert.IsType<BadRequestObjectResult>(result);                     
        }        

        [Fact]
        public async Task Verify_DummySurveyCreated()
        {
            // Arrange
            string surveyName = "Survey 4";
            int surveyId = 4;        
            Survey sample_survey = GetSurvey();
            var mockRepo = new Mock<CompassDBContext>();            
            var controller = new SurveysController(mockRepo.Object);

            // Act
            var result = await controller.PostSurvey(sample_survey);
            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            var returnSession = Assert.IsType<Survey>(okResult.Value);

            Assert.Equal(surveyId, returnSession.Id);
            Assert.Equal(surveyName, returnSession.Name);
            Assert.Equal(1, returnSession.Questions.Count);
        }

        [Fact]
        public async Task CreateActionResult_ReturnsNotFoundObjectResultForIncorrectEntity()
        {
            // Arrange
            var nonExistentSurveyId = 999;
            string surveyName = "Survey 999";           
            var mockRepo = new Mock<CompassDBContext>();
            var controller = new SurveysController(mockRepo.Object);

            var survey = new Survey()
            {                
                Name = surveyName,
                Id = nonExistentSurveyId,
                Questions = { }
            };
            // Act
            var result = await controller.PostSurvey(survey);
            // Assert
            var actionResult = Assert.IsType<ActionResult<Questions>>(result);
            Assert.IsType<NotFoundObjectResult>(actionResult.Result);
        }

        public Survey GetSurvey()
        {
            var option1 = new Options()
            {
                Id = 20,
                OptionId = "1",
                OptionText = "Ball",
                QuestionId = 7
            };
            var option2 = new Options()
            {
                Id = 21,
                OptionId = "2",
                OptionText = "Fruit",
                QuestionId = 7
            };
            var option3 = new Options()
            {
                Id=22,
                OptionId = "3",
                OptionText = "Animal",
                QuestionId = 7
            };
            var question = new Questions()
            {
                Title = "What is an apple?",
                Id = 7,
                Subtitle = "fruit",
                CreatedBy = "Ant",
                CreatedDataTime = new DateTime(2016, 7, 2),
                SurveyId = 4,
                Options = {option1,option2,option3}
            };
            var survey = new Survey()
            {                
                Id = 4,
                Name = "Survey 4",
                Questions = {question}
            };        
            return survey;
        }
    }
}
