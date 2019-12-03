namespace Bank.Services.DomainServices.Account
{
    using System.Collections.Generic;
    using Domain.Objects.Account;

    public interface IAccountDomainService
    {
        bool CanCreateAccount(Account accountToCreate, List<Account> existingAccounts);
    }
}