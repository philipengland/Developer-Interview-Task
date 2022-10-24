using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using InterviewTask.Logging;

namespace InterviewTask.OpenWeather.Services
{
    public class RestClient : IRestClient
    {
        private readonly HttpClient client;
        private readonly ILogger logger;

        public RestClient(HttpClient client, ILogger logger)
        {
            this.client = client;
            this.logger = logger;
        }
        public async Task<HttpResponseMessage> GetJsonRequest(string baseUrl, string parameters)
        {
            try
            {
            //    client.BaseAddress = new Uri(baseUrl);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                var response = await client.GetAsync($"{baseUrl}/{parameters}");
                return response;
            }
            catch (Exception e)
            {
                logger.LogError($"OpenWeatherService, Exception: {e.Message}");
                return new HttpResponseMessage(System.Net.HttpStatusCode.InternalServerError);
            }
        }
    }
}
