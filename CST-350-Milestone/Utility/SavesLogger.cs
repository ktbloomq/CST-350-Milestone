using NLog;

namespace CST_350_Milestone.Utility
{
    public class SavesLogger : ILogger
    {
        private static SavesLogger instance;
        private static Logger logger;

        public static SavesLogger GetInstance()
        {
            if (instance == null)
                instance = new SavesLogger();
            return instance;
        }

        private Logger GetLogger()
        {
            if (SavesLogger.logger == null)
                SavesLogger.logger = LogManager.GetLogger("SaveLoadGameRule");
            return SavesLogger.logger;
        }

        public void Debug(string message)
        {
            GetLogger().Debug(message);
        }

        public void Error(string message)
        {
            GetLogger().Error(message);
        }

        public void Info(string message)
        {
            GetLogger().Info(message);
        }

        public void Warn(string message)
        {
            GetLogger().Warn(message);
        }
    }
}
