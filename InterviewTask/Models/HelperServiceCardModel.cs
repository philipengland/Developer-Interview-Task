using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace InterviewTask.Models
{
    public class HelperServiceCardModel
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public string TelephoneNumber { get; set; }

        public ServiceOpening ServiceOpening { get; set; } = new ServiceOpening();

        public WeatherForcastModel WeatherForcast { get; set; } = new WeatherForcastModel();
    }

    public class ServiceOpening
    {
        public bool? ServiceOpen { get; set; }
        public bool OpeningTimesAvailable { get { return this.ServiceOpen.HasValue ? true : false; } }
        public string OpeningTime { get; set; }

        public string OpeningDay { get; set; }

        public string ClosingTime { get; set; }
    }


}