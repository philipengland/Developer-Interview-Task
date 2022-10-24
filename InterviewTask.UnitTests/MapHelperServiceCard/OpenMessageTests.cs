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
    public class OpenMessageTests
    {
        [TestMethod]
        [Description("Does Card Display Open Message When Within Opening Times On A Monday")]
        [DataRow(9, 0)]
        [DataRow(9, 1)]
        [DataRow(11, 0)]
        [DataRow(13, 0)]
        [DataRow(15, 0)]
        [DataRow(16, 59)]
        public void Does_Card_Display_Open_Message_When_Within_Opening_Times_On_A_Monday(int currentHour, int currentMinute)
        {
            // Is A Monday
            var dateTime = new DateTime(2022, 10, 17, currentHour, currentMinute, 0);

            var openingTimes = new List<int> { 9, 17 };
            var serviceModel = new HelperServiceModel
            {
                MondayOpeningHours = openingTimes,
                TuesdayOpeningHours = openingTimes,
                WednesdayOpeningHours = openingTimes,
                ThursdayOpeningHours = openingTimes,
                FridayOpeningHours = openingTimes,
                SaturdayOpeningHours = openingTimes,
                SundayOpeningHours = openingTimes
            };

            var handler = new HelperServiceCardHelper(new FixedDateTimeProvider(dateTime), MockConfig.GetLoggerMock(), Mapping.MapperConfig.GetMapperInterface());
            var cardModel = handler.MapHelperServiceCard(serviceModel);
          
            Assert.IsTrue(cardModel.ServiceOpening.ServiceOpen, $"Service should be open between 9-17, current time: {currentHour}-{currentMinute}");
            Assert.IsTrue(cardModel.ServiceOpening.OpeningTimesAvailable, "The OpeningTimesAvailable property should be true if opening times are available");
        }

        [TestMethod]
        [Description("Does Card Display Open Message When Within Opening Times On A Tuesday")]
        [DataRow(9, 0)]
        [DataRow(9, 1)]
        [DataRow(11, 0)]
        [DataRow(13, 0)]
        [DataRow(15, 0)]
        [DataRow(16, 59)]
        public void Does_Card_Display_Open_Message_When_Within_Opening_Times_On_A_Tuesday(int currentHour, int currentMinute)
        {
            // Is A Tuesday
            var dateTime = new DateTime(2022, 10, 18, currentHour, currentMinute, 0);

            var openingTimes = new List<int> { 9, 17 };
            var serviceModel = new HelperServiceModel
            {
                MondayOpeningHours = openingTimes,
                TuesdayOpeningHours = openingTimes,
                WednesdayOpeningHours = openingTimes,
                ThursdayOpeningHours = openingTimes,
                FridayOpeningHours = openingTimes,
                SaturdayOpeningHours = openingTimes,
                SundayOpeningHours = openingTimes
            };

            var handler = new HelperServiceCardHelper(new FixedDateTimeProvider(dateTime), MockConfig.GetLoggerMock(), Mapping.MapperConfig.GetMapperInterface());
            var cardModel = handler.MapHelperServiceCard(serviceModel);

            Assert.IsTrue(cardModel.ServiceOpening.ServiceOpen, $"Service should be open between 9-17, current time: {currentHour}-{currentMinute}");
            Assert.IsTrue(cardModel.ServiceOpening.OpeningTimesAvailable, "The OpeningTimesAvailable property should be true if opening times are available");
        }

        [TestMethod]
        [Description("Does Card Display Open Message When Within Opening Times On A Wednesday")]
        [DataRow(9, 0)]
        [DataRow(9, 1)]
        [DataRow(11, 0)]
        [DataRow(13, 0)]
        [DataRow(15, 0)]
        [DataRow(16, 59)]
        public void Does_Card_Display_Open_Message_When_Within_Opening_Times_On_A_Wednesday(int currentHour, int currentMinute)
        {
            // Is A Wednesday
            var dateTime = new DateTime(2022, 10, 19, currentHour, currentMinute, 0);

            var openingTimes = new List<int> { 9, 17 };
            var serviceModel = new HelperServiceModel
            {
                MondayOpeningHours = openingTimes,
                TuesdayOpeningHours = openingTimes,
                WednesdayOpeningHours = openingTimes,
                ThursdayOpeningHours = openingTimes,
                FridayOpeningHours = openingTimes,
                SaturdayOpeningHours = openingTimes,
                SundayOpeningHours = openingTimes
            };

            var handler = new HelperServiceCardHelper(new FixedDateTimeProvider(dateTime), MockConfig.GetLoggerMock(), Mapping.MapperConfig.GetMapperInterface());
            var cardModel = handler.MapHelperServiceCard(serviceModel);

            Assert.IsTrue(cardModel.ServiceOpening.ServiceOpen, $"Service should be open between 9-17, current time: {currentHour}-{currentMinute}");
            Assert.IsTrue(cardModel.ServiceOpening.OpeningTimesAvailable, "The OpeningTimesAvailable property should be true if opening times are available");
        }

        [TestMethod]
        [Description("Does Card Display Open Message When Within Opening Times On A Thursday")]
        [DataRow(9, 0)]
        [DataRow(9, 1)]
        [DataRow(11, 0)]
        [DataRow(13, 0)]
        [DataRow(15, 0)]
        [DataRow(16, 59)]
        public void Does_Card_Display_Open_Message_When_Within_Opening_Times_On_A_Thursday(int currentHour, int currentMinute)
        {
            // Is A Thursday
            var dateTime = new DateTime(2022, 10, 20, currentHour, currentMinute, 0);

            var openingTimes = new List<int> { 9, 17 };
            var serviceModel = new HelperServiceModel
            {
                MondayOpeningHours = openingTimes,
                TuesdayOpeningHours = openingTimes,
                WednesdayOpeningHours = openingTimes,
                ThursdayOpeningHours = openingTimes,
                FridayOpeningHours = openingTimes,
                SaturdayOpeningHours = openingTimes,
                SundayOpeningHours = openingTimes
            };

            var handler = new HelperServiceCardHelper(new FixedDateTimeProvider(dateTime), MockConfig.GetLoggerMock(), Mapping.MapperConfig.GetMapperInterface());
            var cardModel = handler.MapHelperServiceCard(serviceModel);

            Assert.IsTrue(cardModel.ServiceOpening.ServiceOpen, $"Service should be open between 9-17, current time: {currentHour}-{currentMinute}");
            Assert.IsTrue(cardModel.ServiceOpening.OpeningTimesAvailable, "The OpeningTimesAvailable property should be true if opening times are available");
        }

        [TestMethod]
        [Description("Does Card Display Open Message When Within Opening Times On A Friday")]
        [DataRow(9, 0)]
        [DataRow(9, 1)]
        [DataRow(11, 0)]
        [DataRow(13, 0)]
        [DataRow(15, 0)]
        [DataRow(16, 59)]
        public void Does_Card_Display_Open_Message_When_Within_Opening_Times_On_A_Friday(int currentHour, int currentMinute)
        {
            // Is A Friday
            var dateTime = new DateTime(2022, 10, 21, currentHour, currentMinute, 0);

            var openingTimes = new List<int> { 9, 17 };
            var serviceModel = new HelperServiceModel
            {
                MondayOpeningHours = openingTimes,
                TuesdayOpeningHours = openingTimes,
                WednesdayOpeningHours = openingTimes,
                ThursdayOpeningHours = openingTimes,
                FridayOpeningHours = openingTimes,
                SaturdayOpeningHours = openingTimes,
                SundayOpeningHours = openingTimes
            };

            var handler = new HelperServiceCardHelper(new FixedDateTimeProvider(dateTime), MockConfig.GetLoggerMock(), Mapping.MapperConfig.GetMapperInterface());
            var cardModel = handler.MapHelperServiceCard(serviceModel);

            Assert.IsTrue(cardModel.ServiceOpening.ServiceOpen, $"Service should be open between 9-17, current time: {currentHour}-{currentMinute}");
            Assert.IsTrue(cardModel.ServiceOpening.OpeningTimesAvailable, "The OpeningTimesAvailable property should be true if opening times are available");
        }



        [TestMethod]
        [Description("Does Card Display Open Message When Within Opening Times On A Saturday")]
        [DataRow(9, 0)]
        [DataRow(9, 1)]
        [DataRow(11, 0)]
        [DataRow(13, 0)]
        [DataRow(15, 0)]
        [DataRow(16, 59)]
        public void Does_Card_Display_Open_Message_When_Within_Opening_Times_On_A_Saturday(int currentHour, int currentMinute)
        {
            // Is A Saturday
            var dateTime = new DateTime(2022, 10, 22, currentHour, currentMinute, 0);

            var openingTimes = new List<int> { 9, 17 };
            var serviceModel = new HelperServiceModel
            {
                MondayOpeningHours = openingTimes,
                TuesdayOpeningHours = openingTimes,
                WednesdayOpeningHours = openingTimes,
                ThursdayOpeningHours = openingTimes,
                FridayOpeningHours = openingTimes,
                SaturdayOpeningHours = openingTimes,
                SundayOpeningHours = openingTimes
            };

            var handler = new HelperServiceCardHelper(new FixedDateTimeProvider(dateTime), MockConfig.GetLoggerMock(), Mapping.MapperConfig.GetMapperInterface());
            var cardModel = handler.MapHelperServiceCard(serviceModel);

            Assert.IsTrue(cardModel.ServiceOpening.ServiceOpen, $"Service should be open between 9-17, current time: {currentHour}-{currentMinute}");
            Assert.IsTrue(cardModel.ServiceOpening.OpeningTimesAvailable, "The OpeningTimesAvailable property should be true if opening times are available");
        }

        [TestMethod]
        [Description("Does Card Display Open Message When Within Opening Times On A Sunday")]
        [DataRow(9, 0)]
        [DataRow(9, 1)]
        [DataRow(11, 0)]
        [DataRow(13, 0)]
        [DataRow(15, 0)]
        [DataRow(16, 59)]
        public void Does_Card_Display_Open_Message_When_Within_Opening_Times_On_A_Sunday(int currentHour, int currentMinute)
        {
            // Is A Sunday
            var dateTime = new DateTime(2022, 10, 23, currentHour, currentMinute, 0);

            var openingTimes = new List<int> { 9, 17 };
            var serviceModel = new HelperServiceModel
            {
                MondayOpeningHours = openingTimes,
                TuesdayOpeningHours = openingTimes,
                WednesdayOpeningHours = openingTimes,
                ThursdayOpeningHours = openingTimes,
                FridayOpeningHours = openingTimes,
                SaturdayOpeningHours = openingTimes,
                SundayOpeningHours = openingTimes
            };

            var handler = new HelperServiceCardHelper(new FixedDateTimeProvider(dateTime), MockConfig.GetLoggerMock(), Mapping.MapperConfig.GetMapperInterface());
            var cardModel = handler.MapHelperServiceCard(serviceModel);

            Assert.IsTrue(cardModel.ServiceOpening.ServiceOpen, $"Service should be open between 9-17, current time: {currentHour}-{currentMinute}");
            Assert.IsTrue(cardModel.ServiceOpening.OpeningTimesAvailable, "The OpeningTimesAvailable property should be true if opening times are available");
        }
    }
}
