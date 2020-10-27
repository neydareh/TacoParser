using System;

namespace LoggingKata
{
    public class TacoLogger : ILog
    {
        public void LogFatal(string log, Exception exception = null)
        {
            Console.WriteLine($"Fatal: {log}, Exception {exception.Message}");
        }

        public void LogError(string log, Exception exception = null)
        {
            Console.WriteLine($"Error: {log}, Exception {exception.Message}");
        }

        public void LogWarning(string log)
        {
            Console.WriteLine($"Warning: {log}");
        }

        public void LogInfo(string log)
        {
            Console.WriteLine($"Info: {log}");
        }

        public void LogDebug(string log)
        {
            Console.WriteLine($"Debug: {log}");
        }
    }
}
