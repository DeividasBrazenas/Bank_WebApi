namespace Bank.Services.Mappers.Log
{
    using System;
    using System.Collections.Generic;
    using Contracts.Response;
    using Domain.Enums;
    using Domain.Objects;
    using Serilog.Core;

    public class LogMapper : ILogMapper
    {
        private static readonly Dictionary<string, LogLevel> LogLevels = new Dictionary<string, LogLevel>
            {
                { "INF", LogLevel.Information },
                { "ERR", LogLevel.Error }
            };


        public Log MapToDomain(string timestamp, string level, string message)
        {
            return new Log
            {
                Timestamp = DateTime.Parse(timestamp),
                Level = LogLevels[level],
                Message = message
            };
        }

        public LogResponse MapToResponse(Log log)
        {
            return new LogResponse
            {
                Timestamp = log.Timestamp,
                Level = (Contracts.Enums.LogLevel) log.Level,
                Message = log.Message
            };
        }
    }
}