using InterviewTask.OpenWeather.Models;
using InterviewTask.OpenWeather.Services;
using InterviewTask.Services.Weather;
using InterviewTask.UnitTests.Helpers.Mocks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace InterviewTask.UnitTests.GetCurrentWeather
{
    [TestClass]
    public class ExceptionTests
    {
        [TestMethod]
        [Description("Does GetCurrentWeatherAsync Return ArgumentException If Passed City Is Null")]
        [ExpectedException(typeof(ArgumentNullException))]
        public async Task Does_GetCurrentWeatherAsync_Return_ArgumentException_If_Passed_City_Is_Null()
        {
            var weatherServiceMock = new Mock<IOpenWeatherService>();

            var weatherService = new WeatherService(weatherServiceMock.Object, MockConfig.GetLoggerMock(), Mapping.MapperConfig.GetMapperInterface());
            var currentWeather = await weatherService.GetCurrentWeatherAsync(null);
        }
    }
}
