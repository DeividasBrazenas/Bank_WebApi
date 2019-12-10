namespace Bank.Services.Mappers.Accounts
{
    using Contracts.Request;
    using Contracts.Response;
    using Domain.Entities;
    using Domain.Objects.Account;

    public abstract class BaseAccountMapper : IAccountMapper
    {
        public abstract Account MapToDomain(AccountRequest account);

        public abstract Account MapToDomain(AccountEntity account);

        public AccountEntity MapToEntity(Account account)
        {
            return new AccountEntity
            {
                Id = account.Id,
                CustomerId = account.CustomerId,
                Number = account.Number,
                Balance = account.Balance,
                Type = (BankingType)account.Type
            };
        }

        public AccountResponse MapToResponse(Account account)
        {
            return new AccountResponse
            {
                Id = account.Id,
                CustomerId = account.CustomerId,
                Number = account.Number,
                Balance = account.Balance,
                Type = (Contracts.Enums.BankingType)account.Type
            };
        }
    }
}