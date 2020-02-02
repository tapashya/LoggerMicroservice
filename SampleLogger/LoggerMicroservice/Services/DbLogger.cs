using System;

namespace LoggerMicroservice.Services
{
    public class DbLogger : LogBase
    {
        string _connectionString = string.Empty;

        public override void Log(int id, string message, DateTime dateTimeStamp)
        {
            throw new NotImplementedException("DbLogger not implemented");
        }
    }
}
