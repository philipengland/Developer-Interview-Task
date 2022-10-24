using InterviewTask.Logging;
using InterviewTask.OpenWeather.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace InterviewTask.OpenWeather.Services
{
    public class OpenWeatherService : IOpenWeatherService
    {
        private readonly IRestClient restClient;
        private readonly ILogger logger;
        private readonly string url;
        private readonly string apiKey;

        public OpenWeatherService(IRestClient restClient, ILogger logger, string apiKey, string url)
        {
            this.restClient = restClient;
            this.logger = logger;
            this.apiKey = apiKey;
            this.url = url;
        }

        public async Task<WeatherForcast> GetCurrentWeatherAsync(string lattitude, string longitude)
        {
            var response = await restClient.GetJsonRequest(url, $"/data/2.5/weather?lat={lattitude}&lon={longitude}&units=metric&appid={apiKey}");
            if (response.IsSuccessStatusCode) 
            { 
                return await response.Content.ReadAsAsync<WeatherForcast>(); 
            }

            logger.LogError($"OpenWeatherService, GetCurrentWeatherAsync: Error code returned from Open Weather API");
            return null;
        }


        public async Task<IList<Coordinates>> GetCoordinatesAsync(string city)
        {
            var response = await restClient.GetJsonRequest(url, $"/geo/1.0/direct?q={city}&limit=5&appid={apiKey}");
            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadAsAsync<IList<Coordinates>>();
            }

            logger.LogError($"OpenWeatherService, GetCurrentWeatherAsync: Error code returned from Open Weather API");
            return null;
        }
    }
}
