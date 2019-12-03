namespace Bank.Services.Repositories.Loan
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Domain.Entities;
    using Microsoft.EntityFrameworkCore;
    using Persistence;

    public class LoanRepository : BaseRepository<LoanEntity>, ILoanRepository
    {
        public LoanRepository(IDatabaseContext databaseContext) : base(databaseContext)
        {
        }

        public Task<List<LoanEntity>> GetLoansByCustomerId(int id)
        {
            return _databaseContext.Loans.Where(x => x.CustomerId == id).ToListAsync();
        }

        public override async Task<LoanEntity> Update(int id, LoanEntity entity)
        {
            var loan = await _databaseContext.Set<LoanEntity>().FindAsync(id);

            if (loan == null)
            {
                return null;
            }

            loan.CustomerId = entity.CustomerId;
            loan.InterestRate = entity.InterestRate;
            loan.LoanAmount = entity.LoanAmount;
            loan.LoanStart = entity.LoanStart;
            loan.LoanEnd = entity.LoanEnd;

            await _databaseContext.SaveChangesAsync();

            return entity;
        }
    }
}