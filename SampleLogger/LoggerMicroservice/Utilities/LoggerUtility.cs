using System;
using LoggerMicroservice.Enums;
using LoggerMicroservice.Services;

namespace LoggerMicroservice.Utilities
{
    public static class LoggerUtility
    {
        private static LogBase logger = null;
        public static void Log(LogTarget target, int id, string message, DateTime dateTimeStamp)
        {
            switch (target)
            {
                case LogTarget.File:
                    logger = new FileLogger();
                    logger.Log(id, message, dateTimeStamp);
                    break;
                case LogTarget.Database:
                    logger = new DbLogger();
                    logger.Log(id, message, dateTimeStamp);
                    break;
                case LogTarget.EventLog:
                    logger = new EventLogger();
                    logger.Log(id, message, dateTimeStamp);
                    break;
                default:
                    return;
            }
        }
    }
}
