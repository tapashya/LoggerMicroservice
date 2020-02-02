using System;
using TestLoggerMicroservice.Enums;

namespace TestLoggerMicroservice.Models
{
    public class LogModel
    {
        public int Id { get; set; } 

        public string Message { get; set; }

        public DateTime DateTimestamp { get; set; }

        public LogTarget Target { get; set; }

    }
}
