namespace Bank.Services.DataAgents.Logs
{
    using System.Collections.Generic;
    using Domain.Objects;

    public interface ILogDataAgent
    {
        List<Log> GetAllLogs();
    }
}