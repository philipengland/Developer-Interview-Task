using Autofac;
using Autofac.Integration.Mvc;
using InterviewTask.HelperService.Repository;
using InterviewTask.Logging;
using InterviewTask.OpenWeather.Services;
using InterviewTask.Providers;
using InterviewTask.Services;
using InterviewTask.Services.Weather;
using System.Net.Http;
using System.Web.Configuration;

namespace InterviewTask.App_Start
{
    public class IoCConfig
    {
        public static ContainerBuilder RegisterDependencies()
        {
            var builder = new ContainerBuilder();

            builder.RegisterType<HelperServiceRepository>().As<IHelperServiceRepository>();
            builder.RegisterType<HelperServiceCardService>().As<IHelperServiceCardService>();
            builder.RegisterType<HelperServiceCardHelper>().As<IHelperServiceCardHelper>();
            builder.RegisterType<OpenWeatherService>().As<IOpenWeatherService>()
                .WithParameter("apiKey", WebConfigurationManager.AppSettings["OpenWeatherApiKey"])
                .WithParameter("url", WebConfigurationManager.AppSettings["OpenWeatherUrl"]).PropertiesAutowired();
            builder.RegisterType<DateTimeProvider>().As<IDateTimeProvider>();
            builder.RegisterType<WeatherService>().As<IWeatherService>();
            builder.RegisterType<RestClient>().As<IRestClient>();
            builder.RegisterType<FileSinkLogging>().As<ILogger>()
                .WithParameter("fileSinkLocation", WebConfigurationManager.AppSettings["FileSinkDirectory"]);

            builder.Register(c => new HttpClient()).As<HttpClient>().SingleInstance(); // httpclient should be static with a single instance used throughout the app 

            builder.RegisterControllers(typeof(MvcApplication).Assembly)
                   .InstancePerRequest();

     
            builder.RegisterAssemblyModules(typeof(MvcApplication).Assembly);
     
     
            builder.RegisterModule<AutofacWebTypesModule>();

            return builder;
        }
    }
}