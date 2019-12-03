namespace Bank.Services.Repositories.Account
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Domain.Entities;
    using Microsoft.EntityFrameworkCore;
    using Persistence;

    public class AccountRepository : BaseRepository<AccountEntity>, IAccountRepository
    {
        public AccountRepository(IDatabaseContext databaseContext) : base(databaseContext)
        {
        }

        public Task<List<AccountEntity>> GetAccountsByCustomerId(int id)
        {
            return _databaseContext.Accounts.Where(x => x.CustomerId == id).ToListAsync();
        }

        public override async Task<AccountEntity> Update(int id, AccountEntity entity)
        {
            var account = await _databaseContext.Set<AccountEntity>().FindAsync(id);

            if (account == null)
            {
                return null;
            }

            account.CustomerId = entity.CustomerId;
            account.Number = entity.Number;
            account.Balance = entity.Balance;

            await _databaseContext.SaveChangesAsync();

            return entity;
        }
    }
}