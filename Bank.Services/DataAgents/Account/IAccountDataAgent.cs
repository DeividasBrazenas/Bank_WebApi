namespace Bank.Services.DataAgents.Account
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Domain.Objects.Account;

    public interface IAccountDataAgent
    {
        Task<int?> CreateAccount(Account account);

        Task<List<Account>> GetAllAccounts();

        Task<Account> GetAccountById(int id);

        Task<List<Account>> GetAccountsByCustomerId(int id);

        Task<Account> UpdateAccount(int id, Account account);

        Task<int?> DeleteAccount(int id);
    }
}