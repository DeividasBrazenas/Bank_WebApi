namespace Bank.Services.Mappers.Customers
{
    using Contracts.Request;
    using Domain.Entities;
    using Domain.Objects.Customer;

    public class StandardCustomerMapper : BaseCustomerMapper
    {
        public override Customer MapToDomain(CustomerRequest customer)
        {
            return new StandardCustomer
            {
                FirstName = customer.FirstName,
                LastName = customer.LastName,
                PersonalNumber = customer.PersonalNumber,
                MonthlySalary = customer.MonthlySalary
            };
        }

        public override Customer MapToDomain(CustomerEntity customer)
        {
            return new StandardCustomer
            {
                Id = customer.Id,
                FirstName = customer.FirstName,
                LastName = customer.LastName,
                PersonalNumber = customer.PersonalNumber,
                MonthlySalary = customer.MonthlySalary
            };
        }
    }
}