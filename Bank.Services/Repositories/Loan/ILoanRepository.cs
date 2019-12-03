namespace Bank.Services.Repositories.Loan
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Domain.Entities;

    public interface ILoanRepository : IBaseRepository<LoanEntity>
    {
        Task<List<LoanEntity>> GetLoansByCustomerId(int id);
    }
}