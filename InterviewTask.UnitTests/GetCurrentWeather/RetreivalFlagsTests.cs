using InterviewTask.OpenWeather.Models;
using InterviewTask.OpenWeather.Services;
using InterviewTask.Services.Weather;
using InterviewTask.UnitTests.Helpers.Mocks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace InterviewTask.UnitTests.GetCurrentWeather
{
    [TestClass]
    public class RetreivalFlagsTests
    {
        [TestMethod]
        [Description("Does GetCurrentWeatherAsync Correctly Set WeatherRetieval Flags When Weather Is Returned")]
        public async Task Does_GetCurrentWeatherAsync_Correctly_Set_WeatherRetieval_Flags_When_Weather_Is_Returned()
        {
            string city = "Liverpool";

            var coordinates = new List<Coordinates>() { new Coordinates() { Lattitude = 1, Longitude = 1 } };
            var weather = new WeatherForcast() { Name = "Liverpool" };

            // We are returning coordinates and the weather
            var weatherServiceMock = new Mock<IOpenWeatherService>();
            weatherServiceMock.Setup(x => x.GetCoordinatesAsync(city)).Returns(Task.FromResult(coordinates as IList<Coordinates>));
            weatherServiceMock.Setup(x => x.GetCurrentWeatherAsync("1", "1")).Returns(Task.FromResult(weather));

            var weatherService = new WeatherService(weatherServiceMock.Object, MockConfig.GetLoggerMock(), Mapping.MapperConfig.GetMapperInterface());
            var currentWeather = await weatherService.GetCurrentWeatherAsync(city);

            Assert.IsTrue(currentWeather.WeatherRetrieved, $"WeatherRetrieved Flag must be set to true");
            Assert.IsFalse(currentWeather.WeatherRetrievalFailed, "WeatherRetrievalFailed must be set to false");
        }

        [TestMethod]
        [Description("Does GetCurrentWeatherAsync Correctly Set WeatherRetieval Flags To False When Weather Is Not Returned")]
        public async Task Does_GetCurrentWeatherAsync_Correctly_Set_WeatherRetieval_Flags_To_False_When_Weather_Is_Not_Returned()
        {
            string city = "Liverpool";

            var coordinates = new List<Coordinates>() { new Coordinates() { Lattitude = 1, Longitude = 1 } };

            // We are returning coordinates but not the weather
            var weatherServiceMock = new Mock<IOpenWeatherService>();
            weatherServiceMock.Setup(x => x.GetCoordinatesAsync(city)).Returns(Task.FromResult(coordinates as IList<Coordinates>));
       
            var weatherService = new WeatherService(weatherServiceMock.Object, MockConfig.GetLoggerMock(), Mapping.MapperConfig.GetMapperInterface());
            var currentWeather = await weatherService.GetCurrentWeatherAsync(city);

            Assert.IsFalse(currentWeather.WeatherRetrieved, $"WeatherRetrieved Flag must be set to false");
            Assert.IsTrue(currentWeather.WeatherRetrievalFailed, "WeatherRetrievalFailed must be set to true");
        }

        [TestMethod]
        [Description("Does GetCurrentWeatherAsync Correctly Set WeatherRetieval Flags To False When Coordinates Are Not Returned")]
        public async Task Does_GetCurrentWeatherAsync_Correctly_Set_WeatherRetieval_Flags_To_False_When_Coordinates_Are_Not_Returned()
        {
            string city = "Liverpool";

            // We are not returning coordinates or the weather
            var weatherServiceMock = new Mock<IOpenWeatherService>();

            var weatherService = new WeatherService(weatherServiceMock.Object, MockConfig.GetLoggerMock(), Mapping.MapperConfig.GetMapperInterface());
            var currentWeather = await weatherService.GetCurrentWeatherAsync(city);

            Assert.IsFalse(currentWeather.WeatherRetrieved, $"WeatherRetrieved Flag must be set to false");
            Assert.IsTrue(currentWeather.WeatherRetrievalFailed, "WeatherRetrievalFailed must be set to true");
        }
    }
}
