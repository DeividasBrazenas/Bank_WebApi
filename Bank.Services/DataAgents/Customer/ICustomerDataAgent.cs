namespace Bank.Services.DataAgents.Customer
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Domain.Objects.Account;
    using Domain.Objects.Customer;
    using Domain.Objects.Loan;

    public interface ICustomerDataAgent
    {
        Task<int?> CreateCustomer(Customer customer);

        Task<List<Customer>> GetAllCustomers();

        Task<Customer> GetCustomerById(int id);

        Task<List<Account>> GetCustomersAccounts(int id);

        Task<List<Loan>> GetCustomersLoans(int id);

        Task<Customer> UpdateCustomer(int id, Customer customer);

        Task<int?> DeleteCustomer(int id);
    }
}