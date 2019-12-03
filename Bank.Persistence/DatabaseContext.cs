namespace Bank.Persistence
{
    using System;
    using System.Threading.Tasks;
    using Domain.Entities;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.ChangeTracking;

    public sealed class DatabaseContext : DbContext, IDatabaseContext
    {
        public DbSet<CustomerEntity> Customers { get; set; }

        public DbSet<AccountEntity> Accounts { get; set; }

        public DbSet<LoanEntity> Loans { get; set; }

        public DbSet<T> Set<T>() where T : BaseEntity
        {
            return base.Set<T>();
        }

        public Task<int> SaveChangesAsync()
        {
            return base.SaveChangesAsync();
        }

        EntityEntry<T> IDatabaseContext.Entry<T>(T entity)
        {
            return base.Entry(entity);
        }

        public DatabaseContext(DbContextOptions options) : base(options)
        {
            ChangeTracker.Tracked += OnEntityTracked;
            ChangeTracker.StateChanged += OnEntityStateChanged;
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CustomerEntity>(x =>
            {
                x.HasKey(k => k.Id);
                x.Property(p => p.FirstName).IsRequired();
                x.Property(p => p.LastName).IsRequired();
                x.Property(p => p.PersonalNumber).IsRequired();
                x.Property(p => p.MonthlySalary).IsRequired();
                x.Property(p => p.Type).IsRequired();
                x.Property(p => p.CreatedOn).IsRequired();
            });

            modelBuilder.Entity<AccountEntity>(x =>
            {
                x.HasKey(k => k.Id);
                x.Property(p => p.CustomerId).IsRequired();
                x.Property(p => p.Balance).IsRequired();
                x.Property(p => p.Number).IsRequired();
                x.Property(p => p.Type).IsRequired();
                x.Property(p => p.CreatedOn).IsRequired();
            });

            modelBuilder.Entity<LoanEntity>(x =>
            {
                x.HasKey(k => k.Id);
                x.Property(p => p.CustomerId).IsRequired();
                x.Property(p => p.LoanAmount).IsRequired();
                x.Property(p => p.LoanStart).IsRequired();
                x.Property(p => p.LoanEnd).IsRequired();
                x.Property(p => p.Type).IsRequired();
                x.Property(p => p.CreatedOn).IsRequired();
            });

            base.OnModelCreating(modelBuilder);
        }

        private void OnEntityTracked(object sender, EntityTrackedEventArgs e)
        {
            if (!e.FromQuery && e.Entry.State == EntityState.Added && e.Entry.Entity is BaseEntity entity)
            {
                entity.CreatedOn = DateTime.UtcNow;
            }
        }

        private void OnEntityStateChanged(object sender, EntityStateChangedEventArgs e)
        {
            if (e.NewState == EntityState.Modified && e.Entry.Entity is BaseEntity entity)
            {
                entity.ModifiedOn = DateTime.UtcNow;
            }
        }
    }
}