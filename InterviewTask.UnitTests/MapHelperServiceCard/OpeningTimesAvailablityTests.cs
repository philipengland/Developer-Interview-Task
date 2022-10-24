using InterviewTask.HelperService.Models;
using InterviewTask.Models;
using InterviewTask.Providers;
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
    [TestClass]
    public class OpeningTimesAvailablityTests
    {
        [TestMethod]
        [Description("Does Card Indicate Opening Times Unavailable When None Are Retrieved")]
        public void Does_Card_Indicate_Opening_Time_Unavailable_When_None_Are_Retrieved()
        {
            // Is A Monday
            var dateTime = new DateTime(2022, 10, 17, 0, 0, 0);

            var openingTimes = new List<int> { 9, 17 };
            var serviceModel = new HelperServiceModel{ 
                MondayOpeningHours = null,
                TuesdayOpeningHours = null,
                WednesdayOpeningHours = null,
                ThursdayOpeningHours = null,
                FridayOpeningHours = null,
                SaturdayOpeningHours = null,
                SundayOpeningHours = null
            };

            var handler = new HelperServiceCardHelper(new FixedDateTimeProvider(dateTime), MockConfig.GetLoggerMock(), Mapping.MapperConfig.GetMapperInterface());
            var cardModel = handler.MapHelperServiceCard(serviceModel);
          
            Assert.IsNull(cardModel.ServiceOpening.ServiceOpen, "The ServiceOpen property should be null if opening times are not available");
            Assert.IsFalse(cardModel.ServiceOpening.OpeningTimesAvailable, "The OpeningTimesAvailable property should be false if opening times are not available");
        }
    }
}
