using InterviewTask.HelperService.Models;
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
    public class HelperServiceMappingTests
    {
        [TestMethod]
        [Description("Does HelperServiceModel Map To HelperServiceCardModel")]
        public void Does_HelperServiceModel_Map_Title_To_HelperServiceCardModel()
        {
            string description = "This is a description";
            string title = "This is a title";
            string telephoneNumber = "0207 0000000";
            var openingTimes = new List<int> { 9, 17 };
            var serviceModel = new HelperServiceModel
            {
                Title = title,
                Description = description,
                Id = Guid.Parse("FD15B5C7-EF00-4623-8CEA-20E7513283FC"),
                TelephoneNumber = telephoneNumber,

                MondayOpeningHours = openingTimes,
            };

            var handler = new HelperServiceCardHelper(new FixedDateTimeProvider(DateTime.Now), MockConfig.GetLoggerMock(), Mapping.MapperConfig.GetMapperInterface());
            var cardModel = handler.MapHelperServiceCard(serviceModel);

            Assert.AreEqual(cardModel.Title, title, "The title should be mapped");
            Assert.AreEqual(cardModel.Description, description, "The description should be mapped");
            Assert.AreEqual(cardModel.TelephoneNumber, telephoneNumber, "The telephoneNumber should be mapped");
        }
    }
}
