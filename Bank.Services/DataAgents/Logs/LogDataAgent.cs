namespace Bank.Services.DataAgents.Logs
{
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Text.RegularExpressions;
    using Domain.Objects;
    using Mappers.Log;

    public class LogDataAgent : ILogDataAgent
    {
        private readonly ILogMapper _logMapper;

        public LogDataAgent(ILogMapper logMapper)
        {
            _logMapper = logMapper;
        }

        public List<Log> GetAllLogs()
        {
            var logFilePaths = Directory.GetFiles(Directory.GetCurrentDirectory()).Where(x => x.Contains("log")).ToList();

            var logs = new List<Log>();

            foreach (var path in logFilePaths)
            {
                logs.AddRange(ReadLogFile(path));
            }

            return logs;
        }

        private List<Log> ReadLogFile(string filePath)
        {
            var logs = new List<Log>();

            using var stream = File.Open(filePath, FileMode.Open, FileAccess.Read, FileShare.ReadWrite);
            using var reader = new StreamReader(stream);

            var logFileContent = reader.ReadToEnd();

            var matches = Regex.Matches(logFileContent, @"(?<timestamp>(\d{4})-(\d{2})-(\d{2}) (\d{2}):(\d{2}):(\d{2}).(\d{3})).*\[(?<level>.*)\] (?<message>.*)");

            foreach (Match match in matches)
            {
                var timestamp = match.Groups["timestamp"].Value;
                var level = match.Groups["level"].Value;
                var message = match.Groups["message"].Value.Replace("\r", string.Empty);

                logs.Add(_logMapper.MapToDomain(timestamp, level, message));
            }

            return logs;
        }
    }
}