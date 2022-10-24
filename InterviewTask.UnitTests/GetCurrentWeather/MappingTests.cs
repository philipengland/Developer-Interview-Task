using InterviewTask.Models;
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
    public class MappingTests
    {
        [TestMethod]
        [Description("Does GetCurrentWeatherAsync Map WeatherDescription")]
        public async Task Does_GetCurrentWeatherAsync_Map_WeatherDescription()
        {
            string city = "Liverpool";
            string description = "description";
            string main = "main";

            var coordinates = new List<Coordinates>() { new Coordinates() { Lattitude = 1, Longitude = 1 } };
            var weather = new WeatherForcast() { Name = "Liverpool", Weather = new List<Weather>() { new Weather() { Description = description, Main = main } } };

            var weatherServiceMock = new Mock<IOpenWeatherService>();
            weatherServiceMock.Setup(x => x.GetCoordinatesAsync(city)).Returns(Task.FromResult(coordinates as IList<Coordinates>));
            weatherServiceMock.Setup(x => x.GetCurrentWeatherAsync("1", "1")).Returns(Task.FromResult(weather));

            var weatherService = new WeatherService(weatherServiceMock.Object, MockConfig.GetLoggerMock(), Mapping.MapperConfig.GetMapperInterface());
            var currentWeather = await weatherService.GetCurrentWeatherAsync(city);

            Assert.AreEqual(currentWeather.WeatherDescription.Main, main, $"WeatherDescription main is not mapped");
            Assert.AreEqual(currentWeather.WeatherDescription.Description, description, $"WeatherDescription Description is not mapped");
        }

        [TestMethod]
        [Description("Does GetCurrentWeatherAsync Map WeatherInformation")]
        public async Task Does_GetCurrentWeatherAsync_Map_WeatherInformation()
        {
            string city = "Liverpool";
            double feelslike = 10;
            int humidity = 11;
            int pressure = 12;
            double temperature = 13;
            double temperatureMax = 14;
            double temperatureMin = 15;

            var coordinates = new List<Coordinates>() { new Coordinates() { Lattitude = 1, Longitude = 1 } };
            var weather = new WeatherForcast() { Name = "Liverpool"
                , Main = new Main() { FeelsLike = feelslike, Humidity = humidity, Pressure = pressure, Temperature = temperature, TemperatureMax = temperatureMax, TemperatureMin = temperatureMin } };

            var weatherServiceMock = new Mock<IOpenWeatherService>();
            weatherServiceMock.Setup(x => x.GetCoordinatesAsync(city)).Returns(Task.FromResult(coordinates as IList<Coordinates>));
            weatherServiceMock.Setup(x => x.GetCurrentWeatherAsync("1", "1")).Returns(Task.FromResult(weather));

            var weatherService = new WeatherService(weatherServiceMock.Object, MockConfig.GetLoggerMock(), Mapping.MapperConfig.GetMapperInterface());
            var currentWeather = await weatherService.GetCurrentWeatherAsync(city);

            Assert.AreEqual(currentWeather.WeatherInformation.FeelsLike, feelslike, $"WeatherInformation FeelsLike is not mapped");
            Assert.AreEqual(currentWeather.WeatherInformation.Humidity, humidity, $"WeatherInformation Humidity is not mapped");
            Assert.AreEqual(currentWeather.WeatherInformation.Temperature, temperature, $"WeatherInformation Temperature is not mapped");
            Assert.AreEqual(currentWeather.WeatherInformation.TemperatureMax, temperatureMax, $"WeatherInformation TemperatureMax is not mapped");
            Assert.AreEqual(currentWeather.WeatherInformation.TemperatureMin, temperatureMin, $"WeatherInformation TemperatureMin is not mapped");
        }
    }
}
