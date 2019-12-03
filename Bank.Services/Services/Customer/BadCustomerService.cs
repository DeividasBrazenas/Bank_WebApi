namespace Bank.Services.Services.Customer
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Contracts.Request;
    using Contracts.Response;
    using DataAgents.Customer;
    using Mappers.Accounts;
    using Mappers.Customers;
    using Mappers.Loans;
    using Serilog;

    public class BadCustomerService : ICustomerService
    {
        private readonly ICustomerDataAgent _customerDataAgent;
        private readonly ICustomerMapper _customerMapper;
        private readonly IAccountMapper _accountMapper;
        private readonly ILoanMapper _loanMapper;
        private readonly ILogger _logger;

        public BadCustomerService(ICustomerDataAgent customerDataAgent, ICustomerMapper customerMapper, IAccountMapper accountMapper, ILoanMapper loanMapper, ILogger logger)
        {
            _customerDataAgent = customerDataAgent;
            _customerMapper = customerMapper;
            _accountMapper = accountMapper;
            _loanMapper = loanMapper;
            _logger = logger;
        }

        public async Task<int?> CreateCustomer(CustomerRequest customer)
        {
            var customers = await _customerDataAgent.GetAllCustomers();

            var customerObject = _customerMapper.MapToDomain(customer);

            var createdCustomerId = await _customerDataAgent.CreateCustomer(customerObject);

            _logger.Information($"Customer created. Id - {createdCustomerId}");

            return createdCustomerId;
        }

        public async Task<List<CustomerResponse>> GetAllCustomers()
        {
            var customers = await _customerDataAgent.GetAllCustomers();

            _logger.Information($"Customers count - {customers.Count}");

            return customers.Select(x => _customerMapper.MapToResponse(x)).ToList();
        }

        public async Task<CustomerResponse> GetCustomerById(int id)
        {
            var customer = await _customerDataAgent.GetCustomerById(id);

            _logger.Information($"Customer retrieved. Id - {id}");

            return customer == null ? null : _customerMapper.MapToResponse(customer);
        }

        public async Task<List<AccountResponse>> GetCustomersAccounts(int id)
        {
            var accounts = await _customerDataAgent.GetCustomersAccounts(id);

            _logger.Information($"Customer's accounts retrieved. Count - {accounts.Count}");

            return accounts.Select(x => _accountMapper.MapToResponse(x)).ToList();
        }

        public async Task<List<LoanResponse>> GetCustomersLoans(int id)
        {
            var loans = await _customerDataAgent.GetCustomersLoans(id);

            _logger.Information($"Customer's loans retrieved. Count - {loans.Count}");

            return loans.Select(x => _loanMapper.MapToResponse(x)).ToList();
        }

        public async Task<CustomerResponse> UpdateCustomer(int id, CustomerRequest customer)
        {
            var customerObject = _customerMapper.MapToDomain(customer);

            var updatedCustomer = await _customerDataAgent.UpdateCustomer(id, customerObject);

            if (updatedCustomer != null)
            {
                _logger.Information($"Customer updated. Id - {updatedCustomer.Id}");

                _customerMapper.MapToResponse(updatedCustomer);
            }

            return null;
        }

        public async Task<int?> DeleteCustomer(int id)
        {
            var deleteCustomerId = await _customerDataAgent.DeleteCustomer(id);

            if (deleteCustomerId != null)
            {
                _logger.Information($"Customer deleted. Id - {deleteCustomerId}");

                return deleteCustomerId;
            }

            return null;
        }
    }
}