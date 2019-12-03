namespace Bank.Services.Repositories.Customer
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Domain.Entities;
    using Microsoft.EntityFrameworkCore;
    using Persistence;

    public class CustomerRepository : BaseRepository<CustomerEntity>, ICustomerRepository
    {
        public CustomerRepository(IDatabaseContext databaseContext) : base(databaseContext)
        {
        }

        public override async Task<CustomerEntity> Update(int id, CustomerEntity entity)
        {
            var customer = await _databaseContext.Set<CustomerEntity>().FindAsync(id);

            if (customer == null)
            {
                return null;
            }

            customer.FirstName = entity.FirstName;
            customer.LastName = entity.LastName;

            await _databaseContext.SaveChangesAsync();

            return entity;
        }

        public async Task<List<AccountEntity>> GetCustomersAccounts(int id)
        {
            var customerEntity = await _databaseContext.Customers.Include(x => x.Accounts).FirstOrDefaultAsync(x => x.Id == id);

            return customerEntity?.Accounts;
        }

        public async Task<List<LoanEntity>> GetCustomersLoans(int id)
        {
            var customerEntity = await _databaseContext.Customers.Include(x => x.Loans).FirstOrDefaultAsync(x => x.Id == id);

            return customerEntity?.Loans;
        }
    }
}