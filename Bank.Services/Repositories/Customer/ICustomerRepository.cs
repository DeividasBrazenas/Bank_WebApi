namespace Bank.Services.Repositories.Customer
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Domain.Entities;

    public interface ICustomerRepository : IBaseRepository<CustomerEntity>
    {
        Task<List<AccountEntity>> GetCustomersAccounts(int id);

        Task<List<LoanEntity>> GetCustomersLoans(int id);
    }
}