using NLog;

namespace CST_350_Milestone.Utility
{
    public class UserLogger : ILogger
    {

        private static UserLogger instance;
        private static Logger logger;

        public static UserLogger GetInstance()
        {
            if (instance == null)
                instance = new UserLogger();
            return instance;
        }

        private Logger GetLogger()
        {
            if (UserLogger.logger == null)
                UserLogger.logger = LogManager.GetLogger("LoginRegisterRule");
            return UserLogger.logger;
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
