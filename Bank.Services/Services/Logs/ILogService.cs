namespace Bank.Services.Services.Logs
{
    using System.Collections.Generic;
    using Contracts.Response;

    public interface ILogService
    {
        List<LogResponse> GetLogs();
    }
}