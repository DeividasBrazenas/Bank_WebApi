namespace Bank.UnitTests.Customers
{
    using System.Collections.Generic;
    using Domain.Objects.Customer;
    using Services.DomainServices.Customer;
    using Services.Exceptions;
    using Xunit;

    public class StandardCustomerDomainServiceTests
    {
        private readonly ICustomerDomainService _customerDomainService;

        public StandardCustomerDomainServiceTests()
        {
            _customerDomainService = new StandardCustomerDomainService();
        }

        [Fact]
        public void StandardCustomer_Create_Succeeds()
        {
            var customer = new StandardCustomer
            {
                FirstName = "Deividas",
                LastName = "Brazenas",
                MonthlySalary = 1000,
                PersonalNumber = "12345678901"
            };

            var existingCustomers = new List<Customer>
            {
                new VipCustomer
                {
                    FirstName = "Tomas",
                    LastName = "Drasutis",
                    MonthlySalary = 1100,
                    PersonalNumber = "12345678101"
                },
                new StandardCustomer
                {
                    FirstName = "Arnas",
                    LastName = "Danaitis",
                    MonthlySalary = 1000,
                    PersonalNumber = "12345678101"
                }
            };

            Assert.True(_customerDomainService.CanCreateCustomer(customer, existingCustomers));
        }

        [Fact]
        public void StandardCustomer_Create_Fails()
        {
            var customer = new StandardCustomer
            {
                FirstName = "Deividas",
                LastName = "Brazenas",
                MonthlySalary = 1000,
                PersonalNumber = "12345678901"
            };

            var existingCustomers = new List<Customer>
            {
                new VipCustomer
                {
                    FirstName = "Tomas",
                    LastName = "Drasutis",
                    MonthlySalary = 1100,
                    PersonalNumber = "12345678101"
                },
                new StandardCustomer
                {
                    FirstName = "Arnas",
                    LastName = "Danaitis",
                    MonthlySalary = 1000,
                    PersonalNumber = "12345678901"
                }
            };

            Assert.Throws<BusinessException>(() => _customerDomainService.CanCreateCustomer(customer, existingCustomers));
        }
    }
}