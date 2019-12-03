namespace Bank.Contracts.Response
{
    using System;
    using Enums;

    public class LogResponse
    {
        public DateTime Timestamp { get; set; }

        public LogLevel Level { get; set; }

        public string Message { get; set; }
    }
}