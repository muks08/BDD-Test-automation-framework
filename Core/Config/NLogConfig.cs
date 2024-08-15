using NLog;
using NLog.Config;
using NLog.Targets;

namespace Core.Config
{
    public static class NLogConfig
    {
        public static void ConfigureNLog()
        {
            var config = new LoggingConfiguration();

            var logConsole = new ConsoleTarget("logconsole");

            config.AddTarget(logConsole);

            var rule = new LoggingRule("*", LogLevel.Info, logConsole);
            config.LoggingRules.Add(rule);

            LogManager.Configuration = config;
        }
    }
}
