namespace Bank.Services.DataAgents.Loan
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Domain.Objects.Loan;

    public interface ILoanDataAgent
    {
        Task<int?> CreateLoan(Loan loan);

        Task<List<Loan>> GetAllLoans();

        Task<Loan> GetLoanById(int id);

        Task<List<Loan>> GetLoansByCustomerId(int id);

        Task<Loan> UpdateLoan(int id, Loan loan);

        Task<int?> DeleteLoan(int id);
    }
}