namespace Bank.Services.DataAgents.Loan
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Domain.Objects.Loan;
    using Mappers.Loans;
    using Repositories.Loan;

    public class LoanDataAgent : ILoanDataAgent
    {
        private readonly ILoanRepository _loanRepository;
        private readonly ILoanMapper _loanMapper;

        public LoanDataAgent(ILoanRepository loanRepository, ILoanMapper loanMapper)
        {
            _loanRepository = loanRepository;
            _loanMapper = loanMapper;
        }

        public Task<int?> CreateLoan(Loan loan)
        {
            var loanEntity = _loanMapper.MapToEntity(loan);

            return _loanRepository.Add(loanEntity);
        }

        public async Task<List<Loan>> GetAllLoans()
        {
            var loans = await _loanRepository.GetAll();

            return loans.Select(x => _loanMapper.MapToDomain(x)).ToList();
        }

        public async Task<Loan> GetLoanById(int id)
        {
            var loan = await _loanRepository.GetById(id);

            return loan == null ? null : _loanMapper.MapToDomain(loan);
        }

        public async Task<List<Loan>> GetLoansByCustomerId(int id)
        {
            var loans = await _loanRepository.GetLoansByCustomerId(id);

            return loans.Select(x => _loanMapper.MapToDomain(x)).ToList();
        }

        public async Task<Loan> UpdateLoan(int id, Loan loan)
        {
            var loanEntity = _loanMapper.MapToEntity(loan);

            var updatedLoan = await _loanRepository.Update(id, loanEntity);

            return updatedLoan == null ? null : _loanMapper.MapToDomain(updatedLoan);
        }

        public Task<int?> DeleteLoan(int id)
        {
            return _loanRepository.Delete(id);
        }
    }
}