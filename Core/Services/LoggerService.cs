using NLog;
using NLog.Config;

namespace Core.Services
{
    public class LoggerService
    {
        private static readonly ILogger Logger;

        static LoggerService()
        {
            LogManager.Configuration = new XmlLoggingConfiguration("Config/NLog.config");
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
