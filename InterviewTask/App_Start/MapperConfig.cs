using Autofac;
using AutoMapper;
using InterviewTask.HelperService.Models;
using InterviewTask.Models;
using InterviewTask.OpenWeather.Models;

namespace InterviewTask.App_Start
{
    public class MapperConfig
    {
        public static void RegisterMapperWithContainer(ContainerBuilder builder)
        {
            builder.Register(context => new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<HelperServiceProfile>();
            })).AsSelf().SingleInstance();

            builder.Register(c =>
            {
                //This resolves a new context that can be used later.
                var context = c.Resolve<IComponentContext>();
                var config = context.Resolve<MapperConfiguration>();
                return config.CreateMapper(context.Resolve);
            }).As<IMapper>().InstancePerLifetimeScope();
        }
    }

    public class HelperServiceProfile : Profile
    {
        public HelperServiceProfile()
        {
            CreateMap<HelperServiceCardModel, HelperServiceModel>().ReverseMap();
            CreateMap<Weather, WeatherDescription>().ReverseMap();
            CreateMap<Main, WeatherInformation>().ReverseMap();
        }
    }
}