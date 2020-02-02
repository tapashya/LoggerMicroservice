using System;

namespace LoggerMicroservice.Services
{
    public abstract class LogBase
    {
        public abstract void Log(int id, string message, DateTime dateTimeStamp);
    }
}
