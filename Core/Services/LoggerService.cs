using Core.Config;
using NLog;

namespace Core.Services
{
    public class LoggerService
    {
        private static readonly ILogger Logger;

        static LoggerService()
        {
            NLogConfig.ConfigureNLog();
            Logger = LogManager.GetCurrentClassLogger();
        }

        public static void Info(string message)
        {
            Logger.Info(message);
        }

        public static void Error(Exception ex, string message)
        {
            Logger.Error(ex, message);
        }
    }
}
