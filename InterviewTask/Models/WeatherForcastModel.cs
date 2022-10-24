using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace InterviewTask.Models
{
    public class WeatherForcastModel
    {
        public bool WeatherRetrieved { get; set; } = false;
        public bool WeatherRetrievalFailed { get; set; } = false;
        public WeatherDescription WeatherDescription { get; set; } = new WeatherDescription();
        public WeatherInformation WeatherInformation { get; set; } = new WeatherInformation();
    }

    public class WeatherDescription
    {
        public string Main { get; set; }
        public string Description { get; set; }

    }

    public class WeatherInformation
    {
        public double Temperature { get; set; }
        public double FeelsLike { get; set; }
        public double TemperatureMin { get; set; }
        public double TemperatureMax { get; set; }
        public int Pressure { get; set; }
        public int Humidity { get; set; }
    }
}    
