namespace Bank.Services.Services.Logs
{
    using System.Collections.Generic;
    using System.Linq;
    using Contracts.Response;
    using DataAgents.Logs;
    using Mappers.Log;

    public class LogService : ILogService
    {
        private readonly ILogDataAgent _logDataAgent;
        private readonly ILogMapper _logMapper;

        public LogService(ILogDataAgent logDataAgent, ILogMapper logMapper)
        {
            _logDataAgent = logDataAgent;
            _logMapper = logMapper;
        }

        public List<LogResponse> GetLogs()
        {
            var logs = _logDataAgent.GetAllLogs();

            return logs.Select(x => _logMapper.MapToResponse(x)).OrderBy(x => x.Timestamp).ToList();
        }
    }
}