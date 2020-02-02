using System;
using System.IO;

namespace LoggerMicroservice.Services
{
    public class FileLogger: LogBase
    {
        private string _pathString;

        public FileLogger()
        {
            _pathString = @"C:\inetpub\wwwroot\Logger";
            if (!Directory.Exists(_pathString))
            {
                Directory.CreateDirectory(_pathString);
            }
        }
        
        public override void Log(int id, string message, DateTime dateTimeStamp)
        {
            _pathString = _pathString + @"\LoggerMicroservice.txt";
            string logData = dateTimeStamp + " , " + id + " , " + message;
            using (StreamWriter streamWriter = new StreamWriter(_pathString, true))  // True to append data to the file; false to overwrite the file
            {
                streamWriter.WriteLine(logData);
                streamWriter.Close();
            }
        }
    }
}
