using System;

namespace NotificationsApp.Models
{
    public class Log
    {
        public string Type { get; set; }
        public string Recipient { get; set; }
        public string Message { get; set; }
        public DateTime Date { get; set; }
    }
}
