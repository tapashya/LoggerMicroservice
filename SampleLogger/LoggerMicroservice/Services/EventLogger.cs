using System;

namespace LoggerMicroservice.Services
{
    public class EventLogger : LogBase
    {
        public override void Log(int id, string message, DateTime dateTimeStamp)
        {
            throw new NotImplementedException("EventLogger not implemented");
        }
    }
}
