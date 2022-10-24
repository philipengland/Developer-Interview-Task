using System.Net.Http;
using System.Threading.Tasks;

namespace InterviewTask.OpenWeather.Services
{
    public interface IRestClient
    {
        /// <summary>Make a GET Json Request to a REST Api using query string parameters</summary>
        /// <param name="baseUrl">The base URL.</param>
        /// <param name="parameters">Query string parameters</param>
        /// <returns>
        ///   <br />
        /// </returns>
        Task<HttpResponseMessage> GetJsonRequest(string baseUrl, string parameters);
    }
}