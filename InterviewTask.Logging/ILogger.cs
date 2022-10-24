using static System.Net.Mime.MediaTypeNames;
using System;

namespace InterviewTask.Logging
{
    public interface ILogger
    {
        /// <summary>
        /// Debug: Logs that are used for interactive investigation during development.These logs should primarily contain information useful for debugging and have no long-term value.
        /// </summary>
        /// <param name="message">The debug message</param>
        void LogDebug(string message);

        /// <summary>Information: Logs that track the general flow of the application. These logs should have long-term value.</summary>
        /// <param name="message">The message</param>
        void LogInformation(string message);

        /// <summary>Warning: Logs that highlight an abnormal or unexpected event in the application flow, but do not otherwise cause the application execution to stop.</summary>
        /// <param name="message">The message.</param>
        void LogWarning(string message);

        /// <summary>Error: Logs that highlight when the current flow of execution is stopped due to a failure. These should indicate a failure in the current activity, not an application-wide failure.</summary>
        /// <param name="message">The message.</param>
        void LogError(string message);

        /// <summary>Critical: Logs that describe an unrecoverable application or system crash, or a catastrophic failure that requires immediate attention</summary>
        /// <param name="message">The message.</param>
        void LogCritical(string message);
    }
}