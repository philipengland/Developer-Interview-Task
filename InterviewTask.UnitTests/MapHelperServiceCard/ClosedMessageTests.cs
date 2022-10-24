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
    public class ClosedMessageTests
    {
        [TestMethod]
        [Description("Does Card Display Closed Message When Outside Opening Times On A Monday")]
        [DataRow(7, 0)]
        [DataRow(8, 59)]
        [DataRow(17, 0)]
        [DataRow(18, 0)]
        public void Does_Card_Display_Closed_Message_When_Outside_Opening_Times_On_A_Monday(int currentHour, int currentMinute)
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

            Assert.IsFalse(cardModel.ServiceOpening.ServiceOpen, $"Service should be closed outside of 9-17, current time: {currentHour}-{currentMinute}");
            Assert.IsTrue(cardModel.ServiceOpening.OpeningTimesAvailable, "The OpeningTimesAvailable property should be true if opening times are available");
        }

        [TestMethod]
        [Description("Does Card Display Closed Message When Service Is Closed On A Monday")]
        [DataRow(16, 0)]
        public void Does_Card_Display_Closed_Message_When_Service_Is_Closed_Monday(int currentHour, int currentMinute)
        {
            // Is A Monday
            var dateTime = new DateTime(2022, 10, 17, currentHour, currentMinute, 0);

            var openingTimes = new List<int> { 9, 17 };
            var closingTime = new List<int> { 0, 0 };
            var serviceModel = new HelperServiceModel
            {
                MondayOpeningHours = closingTime,
                TuesdayOpeningHours = openingTimes,
                WednesdayOpeningHours = openingTimes,
                ThursdayOpeningHours = openingTimes,
                FridayOpeningHours = openingTimes,
                SaturdayOpeningHours = openingTimes,
                SundayOpeningHours = openingTimes
            };

            var handler = new HelperServiceCardHelper(new FixedDateTimeProvider(dateTime), MockConfig.GetLoggerMock(), Mapping.MapperConfig.GetMapperInterface());
            var cardModel = handler.MapHelperServiceCard(serviceModel);

            Assert.IsFalse(cardModel.ServiceOpening.ServiceOpen, $"Service should be closed when Service is closed for the day");
            Assert.IsTrue(cardModel.ServiceOpening.OpeningTimesAvailable, "The OpeningTimesAvailable property should be true if opening times are available");
        }

        [TestMethod]
        [Description("Does Card Display Closed Message When Within Opening Times On A Tuesday")]
        [DataRow(7, 0)]
        [DataRow(8, 59)]
        [DataRow(17, 0)]
        [DataRow(18, 0)]
        public void Does_Card_Display_Closed_Message_When_Within_Opening_Times_On_A_Tuesday(int currentHour, int currentMinute)
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

            Assert.IsFalse(cardModel.ServiceOpening.ServiceOpen, $"Service should be closed outside of 9-17, current time: {currentHour}-{currentMinute}");
            Assert.IsTrue(cardModel.ServiceOpening.OpeningTimesAvailable, "The OpeningTimesAvailable property should be true if opening times are available");
        }

        [TestMethod]
        [Description("Does Card Display Closed Message When Service Is Closed On A Tuesday")]
        [DataRow(16, 0)]
        public void Does_Card_Display_Closed_Message_When_Service_Is_Closed_Tuesday(int currentHour, int currentMinute)
        {
            // Is A Monday
            var dateTime = new DateTime(2022, 10, 18, currentHour, currentMinute, 0);

            var openingTimes = new List<int> { 9, 17 };
            var closingTime = new List<int> { 0, 0 };
            var serviceModel = new HelperServiceModel
            {
                MondayOpeningHours = openingTimes,
                TuesdayOpeningHours = closingTime,
                WednesdayOpeningHours = openingTimes,
                ThursdayOpeningHours = openingTimes,
                FridayOpeningHours = openingTimes,
                SaturdayOpeningHours = openingTimes,
                SundayOpeningHours = openingTimes
            };

            var handler = new HelperServiceCardHelper(new FixedDateTimeProvider(dateTime), MockConfig.GetLoggerMock(), Mapping.MapperConfig.GetMapperInterface());
            var cardModel = handler.MapHelperServiceCard(serviceModel);

            Assert.IsFalse(cardModel.ServiceOpening.ServiceOpen, $"Service should be closed when Service is closed for the day");
            Assert.IsTrue(cardModel.ServiceOpening.OpeningTimesAvailable, "The OpeningTimesAvailable property should be true if opening times are available");
        }

        [TestMethod]
        [Description("Does Card Display Closed Message When Within Opening Times On A Wednesday")]
        [DataRow(7, 0)]
        [DataRow(8, 59)]
        [DataRow(17, 0)]
        [DataRow(18, 0)]
        public void Does_Card_Display_Closed_Message_When_Within_Opening_Times_On_A_Wednesday(int currentHour, int currentMinute)
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

            Assert.IsFalse(cardModel.ServiceOpening.ServiceOpen, $"Service should be closed outside of 9-17, current time: {currentHour}-{currentMinute}");
            Assert.IsTrue(cardModel.ServiceOpening.OpeningTimesAvailable, "The OpeningTimesAvailable property should be true if opening times are available");
        }

        [TestMethod]
        [Description("Does Card Display Closed Message When Service Is Closed On A Wednesday")]
        [DataRow(16, 0)]
        public void Does_Card_Display_Closed_Message_When_Service_Is_Closed_Wednesday(int currentHour, int currentMinute)
        {
            // Is A Monday
            var dateTime = new DateTime(2022, 10, 19, currentHour, currentMinute, 0);

            var openingTimes = new List<int> { 9, 17 };
            var closingTime = new List<int> { 0, 0 };
            var serviceModel = new HelperServiceModel
            {
                MondayOpeningHours = openingTimes,
                TuesdayOpeningHours = openingTimes,
                WednesdayOpeningHours = closingTime,
                ThursdayOpeningHours = openingTimes,
                FridayOpeningHours = openingTimes,
                SaturdayOpeningHours = openingTimes,
                SundayOpeningHours = openingTimes
            };

            var handler = new HelperServiceCardHelper(new FixedDateTimeProvider(dateTime), MockConfig.GetLoggerMock(), Mapping.MapperConfig.GetMapperInterface());
            var cardModel = handler.MapHelperServiceCard(serviceModel);

            Assert.IsFalse(cardModel.ServiceOpening.ServiceOpen, $"Service should be closed when Service is closed for the day");
            Assert.IsTrue(cardModel.ServiceOpening.OpeningTimesAvailable, "The OpeningTimesAvailable property should be true if opening times are available");
        }

        [TestMethod]
        [Description("Does Card Display Closed Message When Within Opening Times On A Thursday")]
        [DataRow(7, 0)]
        [DataRow(8, 59)]
        [DataRow(17, 0)]
        [DataRow(18, 0)]
        public void Does_Card_Display_Closed_Message_When_Within_Opening_Times_On_A_Thursday(int currentHour, int currentMinute)
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

            Assert.IsFalse(cardModel.ServiceOpening.ServiceOpen, $"Service should be closed outside of 9-17, current time: {currentHour}-{currentMinute}");
            Assert.IsTrue(cardModel.ServiceOpening.OpeningTimesAvailable, "The OpeningTimesAvailable property should be true if opening times are available");
        }

        [TestMethod]
        [Description("Does Card Display Closed Message When Service Is Closed On A Thursday")]
        [DataRow(16, 0)]
        public void Does_Card_Display_Closed_Message_When_Service_Is_Closed_Thursday(int currentHour, int currentMinute)
        {
            // Is A Monday
            var dateTime = new DateTime(2022, 10, 20, currentHour, currentMinute, 0);

            var openingTimes = new List<int> { 9, 17 };
            var closingTime = new List<int> { 0, 0 };
            var serviceModel = new HelperServiceModel
            {
                MondayOpeningHours = openingTimes,
                TuesdayOpeningHours = openingTimes,
                WednesdayOpeningHours = openingTimes,
                ThursdayOpeningHours = closingTime,
                FridayOpeningHours = openingTimes,
                SaturdayOpeningHours = openingTimes,
                SundayOpeningHours = openingTimes
            };

            var handler = new HelperServiceCardHelper(new FixedDateTimeProvider(dateTime), MockConfig.GetLoggerMock(), Mapping.MapperConfig.GetMapperInterface());
            var cardModel = handler.MapHelperServiceCard(serviceModel);

            Assert.IsFalse(cardModel.ServiceOpening.ServiceOpen, $"Service should be closed when Service is closed for the day");
            Assert.IsTrue(cardModel.ServiceOpening.OpeningTimesAvailable, "The OpeningTimesAvailable property should be true if opening times are available");
        }

        [TestMethod]
        [Description("Does Card Display Closed Message When Within Opening Times On A Friday")]
        [DataRow(7, 0)]
        [DataRow(8, 59)]
        [DataRow(17, 0)]
        [DataRow(18, 0)]
        public void Does_Card_Display_Closed_Message_When_Within_Opening_Times_On_A_Friday(int currentHour, int currentMinute)
        {
            // Is A Friday
            var dateTime = new DateTime(2022, 10, 21, currentHour, currentMinute, 0);

            var openingTimes = new List<int> { 9, 17 };
            var closingTime = new List<int> { 0, 0 };
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

            Assert.IsFalse(cardModel.ServiceOpening.ServiceOpen, $"Service should be closed outside of 9-17, current time: {currentHour}-{currentMinute}");
            Assert.IsTrue(cardModel.ServiceOpening.OpeningTimesAvailable, "The OpeningTimesAvailable property should be true if opening times are available");
        }

        [TestMethod]
        [Description("Does Card Display Closed Message When Service Is Closed On A Friday")]
        [DataRow(16, 0)]
        public void Does_Card_Display_Closed_Message_When_Service_Is_Closed_Friday(int currentHour, int currentMinute)
        {
            // Is A Monday
            var dateTime = new DateTime(2022, 10, 21, currentHour, currentMinute, 0);

            var openingTimes = new List<int> { 9, 17 };
            var closingTime = new List<int> { 0, 0 };
            var serviceModel = new HelperServiceModel
            {
                MondayOpeningHours = openingTimes,
                TuesdayOpeningHours = openingTimes,
                WednesdayOpeningHours = openingTimes,
                ThursdayOpeningHours = openingTimes,
                FridayOpeningHours = closingTime,
                SaturdayOpeningHours = openingTimes,
                SundayOpeningHours = openingTimes
            };

            var handler = new HelperServiceCardHelper(new FixedDateTimeProvider(dateTime), MockConfig.GetLoggerMock(), Mapping.MapperConfig.GetMapperInterface());
            var cardModel = handler.MapHelperServiceCard(serviceModel);

            Assert.IsFalse(cardModel.ServiceOpening.ServiceOpen, $"Service should be closed when Service is closed for the day");
            Assert.IsTrue(cardModel.ServiceOpening.OpeningTimesAvailable, "The OpeningTimesAvailable property should be true if opening times are available");
        }

        [TestMethod]
        [Description("Does Card Display Closed Message When Within Opening Times On A Saturday")]
        [DataRow(7, 0)]
        [DataRow(8, 59)]
        [DataRow(17, 0)]
        [DataRow(18, 0)]
        public void Does_Card_Display_Closed_Message_When_Within_Opening_Times_On_A_Saturday(int currentHour, int currentMinute)
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

            Assert.IsFalse(cardModel.ServiceOpening.ServiceOpen, $"Service should be closed outside of 9-17, current time: {currentHour}-{currentMinute}");
            Assert.IsTrue(cardModel.ServiceOpening.OpeningTimesAvailable, "The OpeningTimesAvailable property should be true if opening times are available");
        }

        [TestMethod]
        [Description("Does Card Display Closed Message When Service Is Closed On A Saturday")]
        [DataRow(16, 0)]
        public void Does_Card_Display_Closed_Message_When_Service_Is_Closed_Saturday(int currentHour, int currentMinute)
        {
            // Is A Monday
            var dateTime = new DateTime(2022, 10, 22, currentHour, currentMinute, 0);

            var openingTimes = new List<int> { 9, 17 };
            var closingTime = new List<int> { 0, 0 };
            var serviceModel = new HelperServiceModel
            {
                MondayOpeningHours = openingTimes,
                TuesdayOpeningHours = openingTimes,
                WednesdayOpeningHours = openingTimes,
                ThursdayOpeningHours = openingTimes,
                FridayOpeningHours = openingTimes,
                SaturdayOpeningHours = closingTime,
                SundayOpeningHours = openingTimes
            };

            var handler = new HelperServiceCardHelper(new FixedDateTimeProvider(dateTime), MockConfig.GetLoggerMock(), Mapping.MapperConfig.GetMapperInterface());
            var cardModel = handler.MapHelperServiceCard(serviceModel);

            Assert.IsFalse(cardModel.ServiceOpening.ServiceOpen, $"Service should be closed when Service is closed for the day");
            Assert.IsTrue(cardModel.ServiceOpening.OpeningTimesAvailable, "The OpeningTimesAvailable property should be true if opening times are available");
        }

        [TestMethod]
        [Description("Does Card Display Closed Message When Within Opening Times On A Sunday")]
        [DataRow(7, 0)]
        [DataRow(8, 59)]
        [DataRow(17, 0)]
        [DataRow(18, 0)]
        public void Does_Card_Display_Closed_Message_When_Within_Opening_Times_On_A_Sunday(int currentHour, int currentMinute)
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

            Assert.IsFalse(cardModel.ServiceOpening.ServiceOpen, $"Service should be closed outside of 9-17, current time: {currentHour}-{currentMinute}");
            Assert.IsTrue(cardModel.ServiceOpening.OpeningTimesAvailable, "The OpeningTimesAvailable property should be true if opening times are available");
        }

        [TestMethod]
        [Description("Does Card Display Closed Message When Service Is Closed On A Sunday")]
        [DataRow(16, 0)]
        public void Does_Card_Display_Closed_Message_When_Service_Is_Closed_Sunday(int currentHour, int currentMinute)
        {
            // Is A Monday
            var dateTime = new DateTime(2022, 10, 23, currentHour, currentMinute, 0);

            var openingTimes = new List<int> { 9, 17 };
            var closingTime = new List<int> { 0, 0 };
            var serviceModel = new HelperServiceModel
            {
                MondayOpeningHours = openingTimes,
                TuesdayOpeningHours = openingTimes,
                WednesdayOpeningHours = openingTimes,
                ThursdayOpeningHours = openingTimes,
                FridayOpeningHours = openingTimes,
                SaturdayOpeningHours = openingTimes,
                SundayOpeningHours = closingTime
            };

            var handler = new HelperServiceCardHelper(new FixedDateTimeProvider(dateTime), MockConfig.GetLoggerMock(), Mapping.MapperConfig.GetMapperInterface());
            var cardModel = handler.MapHelperServiceCard(serviceModel);

            Assert.IsFalse(cardModel.ServiceOpening.ServiceOpen, $"Service should be closed when Service is closed for the day");
            Assert.IsTrue(cardModel.ServiceOpening.OpeningTimesAvailable, "The OpeningTimesAvailable property should be true if opening times are available");
        }
    }
}
