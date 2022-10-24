using InterviewTask.HelperService.Models;
using InterviewTask.Models;

namespace InterviewTask.Services
{
    public interface IHelperServiceCardHelper
    {
        /// <summary>Maps the helper service model retrieved from the HelperService Repository to the Helper Service Card Model for the website</summary>
        /// <param name="model">The helper service model.</param>
        /// <returns>
        ///   <br />
        /// </returns>
        HelperServiceCardModel MapHelperServiceCard(HelperServiceModel model);
    }
}
