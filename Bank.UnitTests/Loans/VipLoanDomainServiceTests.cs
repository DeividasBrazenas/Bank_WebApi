namespace Bank.UnitTests.Loans
{
    using System;
    using System.Collections.Generic;
    using Domain.Objects.Customer;
    using Domain.Objects.Loan;
    using Moq;
    using Serilog;
    using Services.DomainServices.Loan;
    using Services.Exceptions;
    using Xunit;

    public class VipLoanDomainServiceTests
    {
        private readonly ILoanDomainService _loanDomainService;

        public VipLoanDomainServiceTests()
        {
            _loanDomainService = new VipLoanDomainService();
        }

        [Fact]
        public void VipLoan_Create_Succeeds()
        {
            var loan = new VipLoan
            {
                CustomerId = 1,
                InterestRate = 0.02,
                LoanAmount = 6000,
                LoanStart = DateTime.Now,
                LoanEnd = DateTime.Now.AddYears(2)
            };

            var customer = new VipCustomer
            {
                FirstName = "Arnas",
                LastName = "Danaitis",
                MonthlySalary = 2000,
                PersonalNumber = "12345678101"
            };

            var customerLoans = new List<Loan>
            {
                new VipLoan
                {
                CustomerId = 1,
                InterestRate = 0.02,
                LoanAmount = 30000,
                LoanStart = DateTime.Now.AddYears(-1),
                LoanEnd = DateTime.Now.AddYears(1)
                }
            };

            Assert.True(_loanDomainService.CanCreateLoan(loan, customer, customerLoans));
        }

        [Fact]
        public void VipLoan_Create_NoCustomer_Fails()
        {
            var loan = new VipLoan
            {
                CustomerId = 1,
                InterestRate = 0.02,
                LoanAmount = 10000,
                LoanStart = DateTime.Now,
                LoanEnd = DateTime.Now.AddYears(2)
            };

            var customerLoans = new List<Loan>
            {
                new VipLoan
                {
                    CustomerId = 1,
                    InterestRate = 0.02,
                    LoanAmount = 30000,
                    LoanStart = DateTime.Now.AddYears(-1),
                    LoanEnd = DateTime.Now.AddYears(1)
                }
            };

            Assert.Throws<BusinessException>(() => _loanDomainService.CanCreateLoan(loan, null, customerLoans));
        }

        [Fact]
        public void VipLoan_Create_TooBigLoan_Fails()
        {
            var loan = new VipLoan
            {
                CustomerId = 1,
                InterestRate = 0.02,
                LoanAmount = 10000,
                LoanStart = DateTime.Now,
                LoanEnd = DateTime.Now.AddYears(1)
            };

            var customer = new VipCustomer
            {
                FirstName = "Arnas",
                LastName = "Danaitis",
                MonthlySalary = 1000,
                PersonalNumber = "12345678101"
            };

            Assert.Throws<BusinessException>(() => _loanDomainService.CanCreateLoan(loan, customer, new List<Loan>()));
        }

        [Fact]
        public void VipLoan_Create_TooManyLoans_Fails()
        {
            var loan = new VipLoan
            {
                CustomerId = 1,
                InterestRate = 0.02,
                LoanAmount = 10000,
                LoanStart = DateTime.Now,
                LoanEnd = DateTime.Now.AddYears(1)
            };

            var customer = new VipCustomer
            {
                FirstName = "Arnas",
                LastName = "Danaitis",
                MonthlySalary = 1000,
                PersonalNumber = "12345678101"
            };

            var customerLoans = new List<Loan>
            {
                new VipLoan
                {
                    CustomerId = 1,
                    InterestRate = 0.02,
                    LoanAmount = 30000,
                    LoanStart = DateTime.Now.AddYears(-1),
                    LoanEnd = DateTime.Now.AddYears(1)
                },
                new VipLoan
                {
                    CustomerId = 1,
                    InterestRate = 0.02,
                    LoanAmount = 30000,
                    LoanStart = DateTime.Now.AddYears(-1),
                    LoanEnd = DateTime.Now.AddYears(1)
                },
                new VipLoan
                {
                    CustomerId = 1,
                    InterestRate = 0.02,
                    LoanAmount = 30000,
                    LoanStart = DateTime.Now.AddYears(-1),
                    LoanEnd = DateTime.Now.AddYears(1)
                }
            };

            Assert.Throws<BusinessException>(() => _loanDomainService.CanCreateLoan(loan, customer, customerLoans));
        }
    }
}