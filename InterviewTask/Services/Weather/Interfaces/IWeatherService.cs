using InterviewTask.Models;
using System.Threading.Tasks;

namespace InterviewTask.Services.Weather
{
    public interface IWeatherService
    {
        /// <summary>Gets the current weather for a city</summary>
        /// <param name="city">The city.</param>
        /// <returns>
        ///   <br />
        /// </returns>
        Task<WeatherForcastModel> GetCurrentWeatherAsync(string city);
    }
}