using AutoMapper;
using InterviewTask.Logging;
using InterviewTask.Models;
using InterviewTask.OpenWeather.Services;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace InterviewTask.Services.Weather
{
    public class WeatherService : IWeatherService
    {
        private readonly IOpenWeatherService openWeatherService;
        private readonly ILogger logger;
        private readonly IMapper mapper;

        public WeatherService(IOpenWeatherService openWeatherService, ILogger logger, IMapper mapper)
        {
            this.openWeatherService = openWeatherService;
            this.logger = logger;
            this.mapper = mapper;
        }

        public virtual async Task<WeatherForcastModel> GetCurrentWeatherAsync(string city)
        {
            if (city == null)
            {
                logger.LogError("GetCurrentWeatherAsync: Null city passed ");
                throw new ArgumentNullException("GetCurrentWeatherAsync: city is null");
            }

            var weatherForcastModel = new WeatherForcastModel();

            var coordinates = await openWeatherService.GetCoordinatesAsync(city);
            if (coordinates == null) {
                logger.LogWarning($"HelperServiceWeatherService, GetCurrentWeatherAsync: No coordinates returned for {city}");
                return ReturnWeatherRetrievalFailure(weatherForcastModel); }

            foreach (var item in coordinates)
            {
                var forecast = await openWeatherService.GetCurrentWeatherAsync(item.Longitude.ToString(), item.Lattitude.ToString());
                if (forecast != null)
                {
                    if (forecast.Main != null)
                        weatherForcastModel.WeatherInformation = mapper.Map<WeatherInformation>(forecast.Main);

                    if (forecast.Weather != null && forecast.Weather.Any())
                        weatherForcastModel.WeatherDescription = mapper.Map<WeatherDescription>(forecast.Weather.First());

                    weatherForcastModel.WeatherRetrieved = true;
                    weatherForcastModel.WeatherRetrievalFailed = false;

                    return weatherForcastModel;
                }
            }

            logger.LogWarning($"HelperServiceWeatherService, GetCurrentWeatherAsync: No weather returned for {city}");
            return ReturnWeatherRetrievalFailure(weatherForcastModel);
        }

        private static WeatherForcastModel ReturnWeatherRetrievalFailure(WeatherForcastModel weatherForcastModel)
        {
            weatherForcastModel.WeatherRetrieved = false;
            weatherForcastModel.WeatherRetrievalFailed = true;
            return weatherForcastModel;
        }
    }
}