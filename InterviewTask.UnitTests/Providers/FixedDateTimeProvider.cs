using InterviewTask.Providers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterviewTask.UnitTests.Providers
{
    //FixedDateTimeProvider implementation for unit tests
    public class FixedDateTimeProvider : IDateTimeProvider
    {
        private DateTime _fixedDateTime;

        public FixedDateTimeProvider(DateTime fixedDateTime)
            => _fixedDateTime = fixedDateTime;

        public DateTime GetNow() => _fixedDateTime;
    }
}
