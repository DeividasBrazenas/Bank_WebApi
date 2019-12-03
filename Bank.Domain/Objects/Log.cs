namespace Bank.Domain.Objects
{
    using System;
    using Enums;

    public class Log
    {
        public DateTime Timestamp { get; set; }

        public LogLevel Level { get; set; }

        public string Message { get; set; }
    }
}