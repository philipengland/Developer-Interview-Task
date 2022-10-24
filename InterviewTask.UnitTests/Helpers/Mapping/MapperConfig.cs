using AutoMapper;
using InterviewTask.App_Start;
using InterviewTask.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterviewTask.UnitTests.Mapping
{
    public class MapperConfig
    {
        public static IMapper GetMapperInterface()
        {
            var mappingConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new HelperServiceProfile());
            });
            return mappingConfig.CreateMapper();
        }
    }
}
