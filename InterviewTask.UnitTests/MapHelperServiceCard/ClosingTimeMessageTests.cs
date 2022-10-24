using InterviewTask.HelperService.Models;
using InterviewTask.Services;
using InterviewTask.UnitTests.Helpers.Mocks;
using InterviewTask.UnitTests.Providers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace InterviewTask.UnitTests.MapHelperServiceCard
{

    [TestClass]
    public class ClosingTimeMessageTests
    {
        [TestMethod]
        [Description("Does Card Not Display ClosingTime Message When Service Is Not Open")]
        [DataRow(18)]
        public void Does_Card_Not_Display_ClosingTime_Message_When_Service_Is_Not_Open(int closingTime)
        {
            int openTime = 9;

            // DateTime is outside of an opening time
            var dateTime = new DateTime(2022, 10, 17, 19, 0, 0);

            var openingTimes = new List<int> { openTime, closingTime };
            var serviceModel = new HelperServiceModel
            {
                MondayOpeningHours = openingTimes,
                TuesdayOpeningHours = openingTimes,
                WednesdayOpeningHours = openingTimes,
                ThursdayOpeningHours = openingTimes,
                FridayOpeningHours = openingTimes,
                SaturdayOpeningHours = openingTimes,
                SundayOpeningHours = openingTimes,
            };

            var handler = new HelperServiceCardHelper(new FixedDateTimeProvider(dateTime), MockConfig.GetLoggerMock(), Mapping.MapperConfig.GetMapperInterface());
            var cardModel = handler.MapHelperServiceCard(serviceModel);

            Assert.AreEqual(cardModel.ServiceOpening.ClosingTime, null, $"The closing time message should not be displayed");
        }

        [TestMethod]
        [Description("Does Card Display ClosingTime Message When Service Is Open On A Monday")]
        [DataRow(15)]
        [DataRow(17)]
        [DataRow(18)]
        public void Does_Card_Display_ClosingTime_Message_When_Service_Is_Open_On_A_Monday(int closingTime)
        {
            int openTime = 9;

            // DateTime is within an opening time on a Monday
            var dateTime = new DateTime(2022, 10, 17, 10, 0, 0);

            var openingTimes = new List<int> { openTime, closingTime };
            var serviceModel = new HelperServiceModel
            {
                MondayOpeningHours = openingTimes,
                TuesdayOpeningHours = openingTimes,
                WednesdayOpeningHours = openingTimes,
                ThursdayOpeningHours = openingTimes,
                FridayOpeningHours = openingTimes,
                SaturdayOpeningHours = openingTimes,
                SundayOpeningHours = openingTimes,
            };

            var handler = new HelperServiceCardHelper(new FixedDateTimeProvider(dateTime), MockConfig.GetLoggerMock(), Mapping.MapperConfig.GetMapperInterface());
            var cardModel = handler.MapHelperServiceCard(serviceModel);

            Assert.AreEqual(cardModel.ServiceOpening.ClosingTime, $"{closingTime}:00", $"The closing time message should be displayed");
        }

        [TestMethod]
        [Description("Does Card Display ClosingTime Message When Service Is Open On A Tuesday")]
        [DataRow(15)]
        [DataRow(17)]
        [DataRow(18)]
        public void Does_Card_Display_ClosingTime_Message_When_Service_Is_Open_On_A_Tuesday(int closingTime)
        {
            int openTime = 9;

            // DateTime is within an opening time on a Tuesday
            var dateTime = new DateTime(2022, 10, 18, 10, 0, 0);

            var openingTimes = new List<int> { openTime, closingTime };
            var serviceModel = new HelperServiceModel
            {
                MondayOpeningHours = openingTimes,
                TuesdayOpeningHours = openingTimes,
                WednesdayOpeningHours = openingTimes,
                ThursdayOpeningHours = openingTimes,
                FridayOpeningHours = openingTimes,
                SaturdayOpeningHours = openingTimes,
                SundayOpeningHours = openingTimes,
            };

            var handler = new HelperServiceCardHelper(new FixedDateTimeProvider(dateTime), MockConfig.GetLoggerMock(), Mapping.MapperConfig.GetMapperInterface());
            var cardModel = handler.MapHelperServiceCard(serviceModel);

            Assert.AreEqual(cardModel.ServiceOpening.ClosingTime, $"{closingTime}:00", $"The closing time message should be displayed");
        }

        [TestMethod]
        [Description("Does Card Display ClosingTime Message When Service Is Open On A Wednesday")]
        [DataRow(15)]
        [DataRow(17)]
        [DataRow(18)]
        public void Does_Card_Display_ClosingTime_Message_When_Service_Is_Open_On_A_Wednesday(int closingTime)
        {
            int openTime = 9;

            // DateTime is within an opening time on a Wednesday
            var dateTime = new DateTime(2022, 10, 19, 10, 0, 0);

            var openingTimes = new List<int> { openTime, closingTime };
            var serviceModel = new HelperServiceModel
            {
                MondayOpeningHours = openingTimes,
                TuesdayOpeningHours = openingTimes,
                WednesdayOpeningHours = openingTimes,
                ThursdayOpeningHours = openingTimes,
                FridayOpeningHours = openingTimes,
                SaturdayOpeningHours = openingTimes,
                SundayOpeningHours = openingTimes,
            };

            var handler = new HelperServiceCardHelper(new FixedDateTimeProvider(dateTime), MockConfig.GetLoggerMock(), Mapping.MapperConfig.GetMapperInterface());
            var cardModel = handler.MapHelperServiceCard(serviceModel);

            Assert.AreEqual(cardModel.ServiceOpening.ClosingTime, $"{closingTime}:00", $"The closing time message should be displayed");
        }

        [TestMethod]
        [Description("Does Card Display ClosingTime Message When Service Is Open On A Thursday")]
        [DataRow(15)]
        [DataRow(17)]
        [DataRow(18)]
        public void Does_Card_Display_ClosingTime_Message_When_Service_Is_Open_On_A_Thursday(int closingTime)
        {
            int openTime = 9;

            // DateTime is within an opening time on a Thursday
            var dateTime = new DateTime(2022, 10, 20, 10, 0, 0);

            var openingTimes = new List<int> { openTime, closingTime };
            var serviceModel = new HelperServiceModel
            {
                MondayOpeningHours = openingTimes,
                TuesdayOpeningHours = openingTimes,
                WednesdayOpeningHours = openingTimes,
                ThursdayOpeningHours = openingTimes,
                FridayOpeningHours = openingTimes,
                SaturdayOpeningHours = openingTimes,
                SundayOpeningHours = openingTimes,
            };

            var handler = new HelperServiceCardHelper(new FixedDateTimeProvider(dateTime), MockConfig.GetLoggerMock(), Mapping.MapperConfig.GetMapperInterface());
            var cardModel = handler.MapHelperServiceCard(serviceModel);

            Assert.AreEqual(cardModel.ServiceOpening.ClosingTime, $"{closingTime}:00", $"The closing time message should be displayed");
        }

        [TestMethod]
        [Description("Does Card Display ClosingTime Message When Service Is Open On A Friday")]
        [DataRow(15)]
        [DataRow(17)]
        [DataRow(18)]
        public void Does_Card_Display_ClosingTime_Message_When_Service_Is_Open_On_A_Friday(int closingTime)
        {
            int openTime = 9;

            // DateTime is within an opening time on a Friday
            var dateTime = new DateTime(2022, 10, 21, 10, 0, 0);

            var openingTimes = new List<int> { openTime, closingTime };
            var serviceModel = new HelperServiceModel
            {
                MondayOpeningHours = openingTimes,
                TuesdayOpeningHours = openingTimes,
                WednesdayOpeningHours = openingTimes,
                ThursdayOpeningHours = openingTimes,
                FridayOpeningHours = openingTimes,
                SaturdayOpeningHours = openingTimes,
                SundayOpeningHours = openingTimes,
            };

            var handler = new HelperServiceCardHelper(new FixedDateTimeProvider(dateTime), MockConfig.GetLoggerMock(), Mapping.MapperConfig.GetMapperInterface());
            var cardModel = handler.MapHelperServiceCard(serviceModel);

            Assert.AreEqual(cardModel.ServiceOpening.ClosingTime, $"{closingTime}:00", $"The closing time message should be displayed");
        }

        [TestMethod]
        [Description("Does Card Display ClosingTime Message When Service Is Open On A Saturday")]
        [DataRow(15)]
        [DataRow(17)]
        [DataRow(18)]
        public void Does_Card_Display_ClosingTime_Message_When_Service_Is_Open_On_A_Saturday(int closingTime)
        {
            int openTime = 9;

            // DateTime is within an opening time on a Saturday
            var dateTime = new DateTime(2022, 10, 22, 10, 0, 0);

            var openingTimes = new List<int> { openTime, closingTime };
            var serviceModel = new HelperServiceModel
            {
                MondayOpeningHours = openingTimes,
                TuesdayOpeningHours = openingTimes,
                WednesdayOpeningHours = openingTimes,
                ThursdayOpeningHours = openingTimes,
                FridayOpeningHours = openingTimes,
                SaturdayOpeningHours = openingTimes,
                SundayOpeningHours = openingTimes,
            };

            var handler = new HelperServiceCardHelper(new FixedDateTimeProvider(dateTime), MockConfig.GetLoggerMock(), Mapping.MapperConfig.GetMapperInterface());
            var cardModel = handler.MapHelperServiceCard(serviceModel);

            Assert.AreEqual(cardModel.ServiceOpening.ClosingTime, $"{closingTime}:00", $"The closing time message should be displayed");
        }

        [TestMethod]
        [Description("Does Card Display ClosingTime Message When Service Is Open On A Sunday")]
        [DataRow(15)]
        [DataRow(17)]
        [DataRow(18)]
        public void Does_Card_Display_ClosingTime_Message_When_Service_Is_Open_On_A_Sunday(int closingTime)
        {
            int openTime = 9;

            // DateTime is within an opening time on a Sunday
            var dateTime = new DateTime(2022, 10, 23, 10, 0, 0);

            var openingTimes = new List<int> { openTime, closingTime };
            var serviceModel = new HelperServiceModel
            {
                MondayOpeningHours = openingTimes,
                TuesdayOpeningHours = openingTimes,
                WednesdayOpeningHours = openingTimes,
                ThursdayOpeningHours = openingTimes,
                FridayOpeningHours = openingTimes,
                SaturdayOpeningHours = openingTimes,
                SundayOpeningHours = openingTimes,
            };

            var handler = new HelperServiceCardHelper(new FixedDateTimeProvider(dateTime), MockConfig.GetLoggerMock(), Mapping.MapperConfig.GetMapperInterface());
            var cardModel = handler.MapHelperServiceCard(serviceModel);

            Assert.AreEqual(cardModel.ServiceOpening.ClosingTime, $"{closingTime}:00", $"The closing time message should be displayed");
        }
    }
}
