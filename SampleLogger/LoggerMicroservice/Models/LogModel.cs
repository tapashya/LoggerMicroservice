using System;
using System.ComponentModel.DataAnnotations;
using LoggerMicroservice.Enums;

namespace LoggerMicroservice.Models
{
    public class LogModel
    {
        [Required]
        public int Id { get; set; } //could be a guid if it is transaction id
        [Required]
        [StringLength(255)]
        public string Message { get; set; }
        [Required]
        [DataType(DataType.DateTime)]
        public DateTime DateTimestamp { get; set; }
        [Required]
        public LogTarget Target { get; set; }

    }
}
