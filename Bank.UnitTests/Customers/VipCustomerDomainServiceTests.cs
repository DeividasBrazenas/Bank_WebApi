namespace Bank.UnitTests.Customers
{
    using System.Collections.Generic;
    using Domain.Objects.Customer;
    using Services.DomainServices.Customer;
    using Services.Exceptions;
    using Xunit;

    public class VipCustomerDomainServiceTests
    {
        private readonly ICustomerDomainService _customerDomainService;

        public VipCustomerDomainServiceTests()
        {
            _customerDomainService = new VipCustomerDomainService();
        }

        [Fact]
        public void VipCustomer_Create_Succeeds()
        {
            var customer = new VipCustomer
            {
                FirstName = "Deividas",
                LastName = "Brazenas",
                MonthlySalary = 1000,
                PersonalNumber = "12345678901"
            };

            var existingCustomers = new List<Customer>
            {
                new StandardCustomer
                {
                    FirstName = "Tomas",
                    LastName = "Drasutis",
                    MonthlySalary = 1100,
                    PersonalNumber = "12345678101"
                },
                new VipCustomer
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
        public void VipCustomer_Create_Fails()
        {
            var customer = new VipCustomer
            {
                FirstName = "Deividas",
                LastName = "Brazenas",
                MonthlySalary = 1000,
                PersonalNumber = "12345678901"
            };

            var existingCustomers = new List<Customer>
            {
                new StandardCustomer
                {
                    FirstName = "Tomas",
                    LastName = "Drasutis",
                    MonthlySalary = 1100,
                    PersonalNumber = "12345678101"
                },
                new VipCustomer
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