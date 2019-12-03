namespace Bank.Services.Services.Account
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Contracts.Request;
    using Contracts.Response;

    public interface IAccountService
    {
        Task<int?> CreateAccount(AccountRequest account);

        Task<List<AccountResponse>> GetAllAccounts();

        Task<AccountResponse> GetAccountById(int id);

        Task<List<AccountResponse>> GetAccountsByCustomerId(int id);

        Task<AccountResponse> UpdateAccount(int id, AccountRequest account);

        Task<int?> DeleteAccount(int id);
    }
}