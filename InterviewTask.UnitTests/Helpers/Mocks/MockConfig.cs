using AutoMapper;
using InterviewTask.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterviewTask.UnitTests.Helpers.Mocks
{
    public static class MockConfig
    {
        public static ILogger GetLoggerMock()
        {
            return new Moq.Mock<ILogger>().Object;
        }
    }
}