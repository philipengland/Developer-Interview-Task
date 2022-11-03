using InterviewTask.Models;
using InterviewTask.Services.HelperService.Interfaces;
using System.Collections.Generic;

namespace InterviewTask.Services
{
    public interface IHelperServiceCardService : IHelperServiceCardServiceAttributes
    {
        /// <summary>Gets the list of Helper Service Cards to display on the Helper Service Page</summary>
        /// <returns>
        ///   <br />
        /// </returns>
        IEnumerable<HelperServiceCardModel> Get();


    }
}