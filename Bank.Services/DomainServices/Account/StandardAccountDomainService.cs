namespace Bank.Services.DomainServices.Account
{
    using System.Collections.Generic;
    using System.Linq;
    using Domain.Objects.Account;
    using Exceptions;

    public class StandardAccountDomainService : IAccountDomainService
    {
        public bool CanCreateAccount(Account accountToCreate, List<Account> existingAccounts)
        {
            if (existingAccounts.Count >= 3)
            {
                var errorMessage = $"Customer (Id - {accountToCreate.CustomerId}) already has 3 or more accounts";

                throw new BusinessException(errorMessage);
            }

            if (existingAccounts.Any(x => x.Number == accountToCreate.Number))
            {
                var errorMessage = $"Account with number {accountToCreate.Number} already exists";

                throw new BusinessException(errorMessage);
            }

            return true;
        }
    }
}