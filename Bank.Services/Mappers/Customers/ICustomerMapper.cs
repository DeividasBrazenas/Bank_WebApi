namespace Bank.Services.Mappers.Customers
{
    using Contracts.Request;
    using Contracts.Response;
    using Domain.Entities;
    using Domain.Objects.Customer;

    public interface ICustomerMapper
    {
        Customer MapToDomain(CustomerRequest customer);

        Customer MapToDomain(CustomerEntity customer);

        CustomerEntity MapToEntity(Customer customer);

        CustomerResponse MapToResponse(Customer customer);
    }
}