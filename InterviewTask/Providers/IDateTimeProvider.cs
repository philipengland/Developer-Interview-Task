using System;

namespace InterviewTask.Providers
{
    public interface IDateTimeProvider
    {
        DateTime GetNow();
    }
}