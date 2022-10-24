using InterviewTask.App_Start;
using InterviewTask.Models;
using InterviewTask.Services;
using InterviewTask.UnitTests.Helpers.Mocks;
using InterviewTask.UnitTests.Providers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Pose;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace InterviewTask.UnitTests.MapHelperServiceCard
{
    /// <summary>
    /// Summary description for UnitTest1
    /// </summary>
    [TestClass]
    public class MapHelperServiceCardTests
    {
        [TestMethod]
        [Description("Does Card Return ArgumentException If Passed Model Is Null")]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Does_Card_Return_ArgumentException_If_Passed_Model_Is_Null()
        {
            var handler = new HelperServiceCardHelper(new FixedDateTimeProvider(DateTime.Now), MockConfig.GetLoggerMock(), Mapping.MapperConfig.GetMapperInterface());
            var cardModel = handler.MapHelperServiceCard(null);
        }
    }
}
