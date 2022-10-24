using System;
using System.Collections.Generic;
using InterviewTask.HelperService.Models;

namespace InterviewTask.HelperService.Repository
{
    public interface IHelperServiceRepository
    {
        IEnumerable<HelperServiceModel> Get();
        HelperServiceModel Get(Guid id);
    }
}
