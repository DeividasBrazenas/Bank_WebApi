namespace Bank.Services.Mappers.Log
{
    using Contracts.Response;
    using Domain.Objects;

    public interface ILogMapper
    {
        Log MapToDomain(string timestamp, string level, string message);

        LogResponse MapToResponse(Log log);
    }
}