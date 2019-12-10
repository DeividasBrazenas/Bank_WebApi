namespace Bank.Services.DomainServices.Customer
{
    using System.Collections.Generic;
    using System.Linq;
    using Domain.Objects.Customer;
    using Exceptions;

    public class StandardCustomerDomainService : ICustomerDomainService
    {
        public bool CanCreateCustomer(Customer customer, List<Customer> existingCustomers)
        {
            if (existingCustomers.Any(x => x.PersonalNumber == customer.PersonalNumber))
            {
                var errorMessage = $"Customer with personal number {customer.PersonalNumber} already exists";

                throw new BusinessException(errorMessage);
            }

            return true;
        }
    }
}