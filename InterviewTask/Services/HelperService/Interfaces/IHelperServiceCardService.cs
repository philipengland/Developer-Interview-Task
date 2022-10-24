using InterviewTask.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace InterviewTask.Services
{
    public interface IHelperServiceCardService
    {
        /// <summary>Gets the list of Helper Service Cards to display on the Helper Service Page</summary>
        /// <returns>
        ///   <br />
        /// </returns>
        IEnumerable<HelperServiceCardModel> Get();

        /// <summary>Gets the list of Helper Service Cards, appended with the current Weather Forecat to display on the Helper Service Page</summary>
        /// <returns>
        ///   <br />
        /// </returns>
        Task<IEnumerable<HelperServiceCardModel>> GetWithWeatherAsync();
    }
}