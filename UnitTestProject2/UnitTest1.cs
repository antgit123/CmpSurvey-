using Microsoft.VisualStudio.TestTools.UnitTesting;
using CompassSurveyTestApp.Models;
using CompassSurveyTestApp.Controllers;

namespace UnitTestProject2
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            //var mockRepo = new Mock(CompassDBContext)
            Assert.AreEqual(4, Add(2, 2));
        }

        int Add(int x, int y)
        {
            return x + y;
        }
    }
}
