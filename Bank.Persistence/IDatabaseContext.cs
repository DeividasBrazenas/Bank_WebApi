namespace Bank.Persistence
{
    using System.Threading.Tasks;
    using Domain.Entities;
    using Microsoft.EntityFrameworkCore;

    public interface IDatabaseContext
    {
        DbSet<CustomerEntity> Customers { get; set; }

        DbSet<AccountEntity> Accounts { get; set; }

        DbSet<LoanEntity> Loans { get; set; }

        DbSet<T> Set<T>() where T : BaseEntity;

        Task<int> SaveChangesAsync();
    }
}