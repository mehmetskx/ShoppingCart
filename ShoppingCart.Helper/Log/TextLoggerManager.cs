using NLog;
using ShoppingCart.Helper.Infrastructure;

namespace ShoppingCart.Helper.Log
{
    public class TextLoggerManager : ILoggerManager
    {
        private static ILogger logger = LogManager.GetCurrentClassLogger();
       
        //NotePad Saving Simulation
        public void LogDebug(string message)
        {
            logger.Debug(message);
        }

        public void LogError(string message)
        {
            logger.Error(message);
        }

        public void LogInfo(string message)
        {
            logger.Info(message);
        }

        public void LogWarn(string message)
        {
            logger.Warn(message);
        }
    }
}


