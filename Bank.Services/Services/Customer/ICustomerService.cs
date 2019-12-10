namespace Bank.Services.Services.Customer
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Contracts.Request;
    using Contracts.Response;

    public interface ICustomerService
    {
        Task<int?> CreateCustomer(CustomerRequest customer);

        Task<List<CustomerResponse>> GetAllCustomers();

        Task<CustomerResponse> GetCustomerById(int id);

        Task<List<AccountResponse>> GetCustomerAccounts(int id);

        Task<List<LoanResponse>> GetCustomerLoans(int id);

        Task<CustomerResponse> UpdateCustomer(int id, CustomerRequest customer);

        Task<int?> DeleteCustomer(int id);
    }
}