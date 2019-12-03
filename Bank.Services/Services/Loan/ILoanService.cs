namespace Bank.Services.Services.Loan
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Contracts.Request;
    using Contracts.Response;

    public interface ILoanService
    {
        Task<int?> CreateLoan(LoanRequest loan);

        Task<List<LoanResponse>> GetAllLoans();

        Task<LoanResponse> GetLoanById(int id);

        Task<List<LoanResponse>> GetLoansByCustomerId(int id);

        Task<LoanResponse> UpdateLoan(int id, LoanRequest loan);

        Task<int?> DeleteLoan(int id);
    }
}