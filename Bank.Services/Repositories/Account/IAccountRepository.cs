namespace Bank.Services.Repositories.Account
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Domain.Entities;

    public interface IAccountRepository : IBaseRepository<AccountEntity>
    {
        Task<List<AccountEntity>> GetAccountsByCustomerId(int id);
    }
}