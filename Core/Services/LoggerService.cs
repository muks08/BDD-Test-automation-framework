using NLog;
using NLog.Config;

namespace Core.Services
{
    public class LoggerService
    {
        private static readonly ILogger Logger;

        static LoggerService()
        {
            var baseDirectory = AppDomain.CurrentDomain.BaseDirectory;
            LogManager.Configuration = new XmlLoggingConfiguration(Path.Combine(baseDirectory, "Config/NLog.config"));
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
