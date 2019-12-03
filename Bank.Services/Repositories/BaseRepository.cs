namespace Bank.Services.Repositories
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Domain.Entities;
    using Microsoft.EntityFrameworkCore;
    using Persistence;

    public abstract class BaseRepository<T> : IBaseRepository<T> where T : BaseEntity
    {
        protected readonly IDatabaseContext _databaseContext;

        protected BaseRepository(IDatabaseContext databaseContext)
        {
            _databaseContext = databaseContext;
        }

        public abstract Task<T> Update(int id, T entity);

        public async Task<int?> Add(T entity)
        {
            await _databaseContext.Set<T>().AddAsync(entity);

            var result = await _databaseContext.SaveChangesAsync();

            if (result == 0)
            {
                return null;
            }

            return entity.Id;
        }

        public Task<List<T>> GetAll()
        {
            return _databaseContext.Set<T>().ToListAsync();
        }

        public async Task<T> GetById(int id)
        {
            return await _databaseContext.Set<T>().FindAsync(id);
        }

        public async Task<int?> Delete(int id)
        {
            var entity = _databaseContext.Set<T>().Find(id);

            if (entity == null)
            {
                return null;
            }

            _databaseContext.Set<T>().Remove(entity);

            await _databaseContext.SaveChangesAsync();

            return id;
        }
    }
}