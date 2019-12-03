namespace Bank.Services.Mappers.Accounts
{
    using Contracts.Request;
    using Contracts.Response;
    using Domain.Entities;
    using Domain.Objects.Account;

    public interface IAccountMapper
    {
        Account MapToDomain(AccountRequest account);

        Account MapToDomain(AccountEntity account);

        AccountEntity MapToEntity(Account account);

        AccountResponse MapToResponse(Account account);
    }
}