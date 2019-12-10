namespace Bank.Services.Mappers.Customers
{
    using Contracts.Request;
    using Contracts.Response;
    using Domain.Entities;
    using Domain.Objects.Customer;

    public abstract class BaseCustomerMapper : ICustomerMapper
    {
        public abstract Customer MapToDomain(CustomerRequest customer);

        public abstract Customer MapToDomain(CustomerEntity customer);

        public CustomerEntity MapToEntity(Customer customer)
        {
            return new CustomerEntity
            {
                Id = customer.Id,
                FirstName = customer.FirstName,
                LastName = customer.LastName,
                PersonalNumber = customer.PersonalNumber,
                MonthlySalary = customer.MonthlySalary,
                Type = (BankingType)customer.Type
            };
        }

        public CustomerResponse MapToResponse(Customer customer)
        {
            return new CustomerResponse
            {
                Id = customer.Id,
                FirstName = customer.FirstName,
                LastName = customer.LastName,
                PersonalNumber = customer.PersonalNumber,
                MonthlySalary = customer.MonthlySalary,
                Type = (Contracts.Enums.BankingType)customer.Type
            };
        }
    }
}