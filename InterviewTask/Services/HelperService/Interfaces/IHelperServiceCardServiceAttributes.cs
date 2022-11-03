using InterviewTask.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterviewTask.Services.HelperService.Interfaces
{
    public interface IHelperServiceCardServiceAttributes
    {
        Task AddWeather(IEnumerable<HelperServiceCardModel> models);
    }
}
