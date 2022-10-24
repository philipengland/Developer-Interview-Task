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
    public class OpeningTimeMessageTests
    {
        [TestMethod]
        [Description("Does Card Display OpeningTimes Messages When Service Is Closed On A Monday")]
        [DataRow(9)]
        [DataRow(10)]
        public void Does_Card_Display_OpeningTimes_Messages_When_Service_Is_Closed_On_A_Monday(int openTime)
        {
            int closingTime = 17;

            // DateTime is outside an opening time on a Monday
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

            Assert.AreEqual(cardModel.ServiceOpening.OpeningTime, $"{openTime}:00", $"The opening time message should be displayed");
            Assert.AreEqual(cardModel.ServiceOpening.OpeningDay, $"Tuesday", $"The next opening day should be displayed");
        }

        [TestMethod]
        [Description("Does Card Display OpeningTimes Messages When Service Is Closed On A Tuesday")]
        [DataRow(9)]
        [DataRow(10)]
        public void Does_Card_Display_OpeningTimes_Messages_When_Service_Is_Closed_On_A_Tuesday(int openTime)
        {
            int closingTime = 17;

            // DateTime is outside an opening time on a Tuesday
            var dateTime = new DateTime(2022, 10, 18, 19, 0, 0);

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

            Assert.AreEqual(cardModel.ServiceOpening.OpeningTime, $"{openTime}:00", $"The opening time message should be displayed");
            Assert.AreEqual(cardModel.ServiceOpening.OpeningDay, $"Wednesday", $"The next opening day should be displayed");
        }

        [TestMethod]
        [Description("Does Card Display OpeningTimes Messages When Service Is Closed On A Wednesday")]
        [DataRow(9)]
        [DataRow(10)]
        public void Does_Card_Display_OpeningTimes_Messages_When_Service_Is_Closed_On_A_Wednesday(int openTime)
        {
            int closingTime = 17;

            // DateTime is outside an opening time on a Wednesday
            var dateTime = new DateTime(2022, 10, 19, 19, 0, 0);

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

            Assert.AreEqual(cardModel.ServiceOpening.OpeningTime, $"{openTime}:00", $"The opening time message should be displayed");
            Assert.AreEqual(cardModel.ServiceOpening.OpeningDay, $"Thursday", $"The next opening day should be displayed");
        }

        [TestMethod]
        [Description("Does Card Display OpeningTimes Messages When Service Is Closed On A Thursday")]
        [DataRow(9)]
        [DataRow(10)]
        public void Does_Card_Display_OpeningTimes_Messages_When_Service_Is_Closed_On_A_Thursday(int openTime)
        {
            int closingTime = 17;

            // DateTime is outside an opening time on a Thursday
            var dateTime = new DateTime(2022, 10, 20, 19, 0, 0);

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

            Assert.AreEqual(cardModel.ServiceOpening.OpeningTime, $"{openTime}:00", $"The opening time message should be displayed");
            Assert.AreEqual(cardModel.ServiceOpening.OpeningDay, $"Friday", $"The next opening day should be displayed");
        }

        [TestMethod]
        [Description("Does Card Display OpeningTimes Messages When Service Is Closed On A Friday")]
        [DataRow(9)]
        [DataRow(10)]
        public void Does_Card_Display_OpeningTimes_Messages_When_Service_Is_Closed_On_A_Friday(int openTime)
        {
            int closingTime = 17;

            // DateTime is outside an opening time on a Friday
            var dateTime = new DateTime(2022, 10, 21, 19, 0, 0);

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

            Assert.AreEqual(cardModel.ServiceOpening.OpeningTime, $"{openTime}:00", $"The opening time message should be displayed");
            Assert.AreEqual(cardModel.ServiceOpening.OpeningDay, $"Saturday", $"The next opening day should be displayed");
        }

        [TestMethod]
        [Description("Does Card Display OpeningTimes Messages When Service Is Closed On A Saturday")]
        [DataRow(9)]
        [DataRow(10)]
        public void Does_Card_Display_OpeningTimes_Messages_When_Service_Is_Closed_On_A_Saturday(int openTime)
        {
            int closingTime = 17;

            // DateTime is outside an opening time on a Saturday
            var dateTime = new DateTime(2022, 10, 22, 19, 0, 0);

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

            Assert.AreEqual(cardModel.ServiceOpening.OpeningTime, $"{openTime}:00", $"The opening time message should be displayed");
            Assert.AreEqual(cardModel.ServiceOpening.OpeningDay, $"Sunday", $"The next opening day should be displayed");
        }

        [TestMethod]
        [Description("Does Card Display OpeningTimes Messages When Service Is Closed On A Sunday")]
        [DataRow(9)]
        [DataRow(10)]
        public void Does_Card_Display_OpeningTimes_Messages_When_Service_Is_Closed_On_A_Sunday(int openTime)
        {
            int closingTime = 17;

            // DateTime is outside an opening time on a Sunday
            var dateTime = new DateTime(2022, 10, 23, 19, 0, 0);

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

            Assert.AreEqual(cardModel.ServiceOpening.OpeningTime, $"{openTime}:00", $"The opening time message should be displayed");
            Assert.AreEqual(cardModel.ServiceOpening.OpeningDay, $"Monday", $"The next opening day should be displayed");
        }

        [TestMethod]
        [Description("Does Card Display OpeningTimes Messages When Service Is Closed And Closed The Following Day")]
        [DataRow(9)]
        [DataRow(10)]
        public void Does_Card_Display_OpeningTimes_Messages_When_Service_Is_Closed_And_Closed_The_Following_Day(int openTime)
        {
            int closingTime = 17;

            // DateTime is outside an opening time on a Saturday
            var dateTime = new DateTime(2022, 10, 22, 19, 0, 0);

            var openingTimes = new List<int> { openTime, closingTime };
            var closingTimes = new List<int> { 0, 0 };
            var serviceModel = new HelperServiceModel
            {
                MondayOpeningHours = openingTimes,
                TuesdayOpeningHours = openingTimes,
                WednesdayOpeningHours = openingTimes,
                ThursdayOpeningHours = openingTimes,
                FridayOpeningHours = openingTimes,
                SaturdayOpeningHours = openingTimes,
                SundayOpeningHours = closingTimes,
            };

            var handler = new HelperServiceCardHelper(new FixedDateTimeProvider(dateTime), MockConfig.GetLoggerMock(), Mapping.MapperConfig.GetMapperInterface());
            var cardModel = handler.MapHelperServiceCard(serviceModel);

            Assert.AreEqual(cardModel.ServiceOpening.OpeningTime, $"{openTime}:00", $"The opening time message should be displayed");
            Assert.AreEqual(cardModel.ServiceOpening.OpeningDay, $"Monday", $"The next opening day should be displayed");
        }
    }
}
