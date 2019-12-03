namespace Bank.Services.DomainServices.Customer
{
    using System.Collections.Generic;
    using Domain.Objects.Customer;

    public interface ICustomerDomainService
    {
        bool CanCreateCustomer(Customer customer, List<Customer> existingCustomers);
    }
}