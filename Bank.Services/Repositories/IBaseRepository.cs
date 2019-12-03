namespace Bank.Services.Repositories
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Domain.Entities;

    public interface IBaseRepository<T> where T : BaseEntity
    {
        Task<int?> Add(T entity);

        Task<List<T>> GetAll();

        Task<T> GetById(int id);

        Task<T> Update(int id, T entity);

        Task<int?> Delete(int id);
    }
}