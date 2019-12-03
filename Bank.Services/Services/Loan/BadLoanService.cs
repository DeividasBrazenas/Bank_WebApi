namespace Bank.Services.Services.Loan
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Contracts.Request;
    using Contracts.Response;
    using DataAgents.Customer;
    using DataAgents.Loan;
    using Mappers.Loans;
    using Serilog;

    public class BadLoanService : ILoanService
    {
        private readonly ILoanDataAgent _loanDataAgent;
        private readonly ICustomerDataAgent _customerDataAgent;
        private readonly ILoanMapper _loanMapper;
        private readonly ILogger _logger;

        public BadLoanService(ILoanDataAgent loanDataAgent, ICustomerDataAgent customerDataAgent, ILoanMapper loanMapper, ILogger logger)
        {
            _loanDataAgent = loanDataAgent;
            _customerDataAgent = customerDataAgent;
            _loanMapper = loanMapper;
            _logger = logger;
        }

        public async Task<int?> CreateLoan(LoanRequest loan)
        {
            var customer = await _customerDataAgent.GetCustomerById(loan.CustomerId);

            var customerLoans = await _loanDataAgent.GetLoansByCustomerId(loan.CustomerId);

            var loanObject = _loanMapper.MapToDomain(loan);

            var createdLoanId = await _loanDataAgent.CreateLoan(loanObject);

            _logger.Information($"Loan created. Id - {createdLoanId}");

            return createdLoanId;
        }

        public async Task<List<LoanResponse>> GetAllLoans()
        {
            var loans = await _loanDataAgent.GetAllLoans();

            _logger.Information($"Loans count - {loans.Count}");

            return loans.Select(x => _loanMapper.MapToResponse(x)).ToList();
        }

        public async Task<LoanResponse> GetLoanById(int id)
        {
            var loan = await _loanDataAgent.GetLoanById(id);

            _logger.Information($"Loan retrieved. Id - {id}");

            return loan == null ? null : _loanMapper.MapToResponse(loan);
        }

        public async Task<List<LoanResponse>> GetLoansByCustomerId(int id)
        {
            var loans = await _loanDataAgent.GetLoansByCustomerId(id);

            _logger.Information($"Customer's loans retrieved. Count - {loans.Count}");

            return loans.Select(x => _loanMapper.MapToResponse(x)).ToList();
        }

        public async Task<LoanResponse> UpdateLoan(int id, LoanRequest loan)
        {
            var loanObject = _loanMapper.MapToDomain(loan);

            var updatedLoan = await _loanDataAgent.UpdateLoan(id, loanObject);

            if (updatedLoan != null)
            {
                _logger.Information($"Loan updated. Id - {updatedLoan.Id}");

                return _loanMapper.MapToResponse(updatedLoan);
            }

            return null;
        }

        public Task<int?> DeleteLoan(int id)
        {
            var deletedLoanId = _loanDataAgent.DeleteLoan(id);

            if (deletedLoanId != null)
            {
                _logger.Information($"Loan deleted. Id - {deletedLoanId}");

                return deletedLoanId;
            }

            return null;
        }
    }
}