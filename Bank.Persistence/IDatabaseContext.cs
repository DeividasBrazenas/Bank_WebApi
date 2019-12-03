namespace Bank.Persistence
{
    using System.Threading.Tasks;
    using Domain.Entities;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.ChangeTracking;

    public interface IDatabaseContext
    {
        DbSet<CustomerEntity> Customers { get; set; }

        DbSet<AccountEntity> Accounts { get; set; }

        DbSet<LoanEntity> Loans { get; set; }

        DbSet<T> Set<T>() where T : BaseEntity;

        Task<int> SaveChangesAsync();

        EntityEntry<T> Entry<T>(T entity) where T : BaseEntity;
    }
}