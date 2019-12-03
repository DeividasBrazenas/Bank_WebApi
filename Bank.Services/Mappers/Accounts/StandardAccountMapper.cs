namespace Bank.Services.Mappers.Accounts
{
    using Contracts.Request;
    using Domain.Entities;
    using Domain.Objects.Account;

    public class StandardAccountMapper : BaseAccountMapper
    {
        public override Account MapToDomain(AccountRequest account)
        {
            return new StandardAccount
            {
                CustomerId = account.CustomerId,
                Number = account.Number,
                Balance = account.Balance,
            };
        }

        public override Account MapToDomain(AccountEntity account)
        {
            return new StandardAccount
            {
                Id = account.Id,
                CustomerId = account.CustomerId,
                Number = account.Number,
                Balance = account.Balance
            };
        }
    }
}
