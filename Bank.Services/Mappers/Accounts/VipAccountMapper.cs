namespace Bank.Services.Mappers.Accounts
{
    using Contracts.Request;
    using Domain.Entities;
    using Domain.Objects.Account;

    public class VipAccountMapper : BaseAccountMapper
    {
        public override Account MapToDomain(AccountRequest account)
        {
            return new VipAccount
            {
                CustomerId = account.CustomerId,
                Number = account.Number,
                Balance = account.Balance
            };
        }

        public override Account MapToDomain(AccountEntity account)
        {
            return new VipAccount
            {
                Id = account.Id,
                CustomerId = account.CustomerId,
                Number = account.Number,
                Balance = account.Balance
            };
        }
    }
}