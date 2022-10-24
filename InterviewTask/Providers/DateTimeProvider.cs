using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace InterviewTask.Providers
{
    public class DateTimeProvider : IDateTimeProvider
    {
        public DateTime GetNow() => DateTime.Now;
    }
}