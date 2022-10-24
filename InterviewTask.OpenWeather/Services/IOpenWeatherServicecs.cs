using InterviewTask.OpenWeather.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace InterviewTask.OpenWeather.Services
{
    public interface IOpenWeatherService
    {
        /// <summary>Gets the current Weather Forcast for a set of coordinates
        /// If you are unsure of the coordinates then  use the GetCoordinates</summary>
        /// <param name="lattitude">The lattitude</param>
        /// <param name="longitude">The longitude</param>
        /// <returns>
        ///   <br />
        /// </returns>
        Task<WeatherForcast> GetCurrentWeatherAsync(string lattitude, string longitude);

        /// <summary>Gets the coordinates for a passed City Name</summary>
        /// <param name="city">The city.</param>
        /// <returns>
        ///   <br />
        /// </returns>
        Task<IList<Coordinates>> GetCoordinatesAsync(string city);
    }
}