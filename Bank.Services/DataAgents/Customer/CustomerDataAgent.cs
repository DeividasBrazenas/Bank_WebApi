namespace Bank.Services.DataAgents.Customer
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Domain.Objects.Account;
    using Domain.Objects.Customer;
    using Domain.Objects.Loan;
    using Mappers.Accounts;
    using Mappers.Customers;
    using Mappers.Loans;
    using Repositories.Customer;

    public class CustomerDataAgent : ICustomerDataAgent
    {
        private readonly ICustomerRepository _customerRepository;
        private readonly ICustomerMapper _customerMapper;
        private readonly IAccountMapper _accountMapper;
        private readonly ILoanMapper _loanMapper;

        public CustomerDataAgent(ICustomerRepository customerRepository, ICustomerMapper customerMapper, IAccountMapper accountMapper, ILoanMapper loanMapper)
        {
            _customerRepository = customerRepository;
            _customerMapper = customerMapper;
            _accountMapper = accountMapper;
            _loanMapper = loanMapper;
        }

        public Task<int?> CreateCustomer(Customer customer)
        {
            var customerEntity = _customerMapper.MapToEntity(customer);

            return _customerRepository.Add(customerEntity);
        }

        public async Task<List<Customer>> GetAllCustomers()
        {
            var customers = await _customerRepository.GetAll();

            return customers.Select(x => _customerMapper.MapToDomain(x)).ToList();
        }

        public async Task<Customer> GetCustomerById(int id)
        {
            var customer = await _customerRepository.GetById(id);

            return customer == null ? null : _customerMapper.MapToDomain(customer);
        }

        public async Task<List<Account>> GetCustomerAccounts(int id)
        {
            var accounts = await _customerRepository.GetCustomersAccounts(id);

            return accounts.Select(x => _accountMapper.MapToDomain(x)).ToList();
        }

        public async Task<List<Loan>> GetCustomerLoans(int id)
        {
            var loans = await _customerRepository.GetCustomersLoans(id);

            return loans.Select(x => _loanMapper.MapToDomain(x)).ToList();
        }

        public async Task<Customer> UpdateCustomer(int id, Customer customer)
        {
            var customerEntity = _customerMapper.MapToEntity(customer);

            var updatedCustomer = await _customerRepository.Update(id, customerEntity);

            return updatedCustomer == null ? null : _customerMapper.MapToDomain(updatedCustomer);
        }

        public Task<int?> DeleteCustomer(int id)
        {
            return _customerRepository.Delete(id);
        }
    }
}