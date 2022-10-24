using System;
using System.IO;

namespace InterviewTask.Logging
{
    public class FileSinkLogging : ILogger
    {
        private readonly string fileSinkLocation;

        public FileSinkLogging(string fileSinkLocation)
        {
            this.fileSinkLocation = fileSinkLocation;
        }

        private void Log(string severity, string message)
        {
            var logLocation = $"{fileSinkLocation}/{DateTime.Now.ToString("yyyy/MM/dd")}";

            if (!Directory.Exists(logLocation)) { Directory.CreateDirectory(logLocation); }

            string logName = $"{logLocation}/{DateTime.Now.ToString("hh-mm")}-Log.txt";
            using (StreamWriter writer = new StreamWriter(logName, append: true))
            {
                writer.WriteLine($"{severity}: {message}");
                writer.Close();
            }
        }

        public void LogCritical(string message)
        {
            Log("Critical", message);
        }

        public void LogDebug(string message)
        {
            Log("Debug", message);
        }

        public void LogError(string message)
        {
            Log("Error", message);
        }

        public void LogInformation(string message)
        {
            Log("Information", message);
        }

        public void LogWarning(string message)
        {
            Log("Warning", message);
        }
    }
}
