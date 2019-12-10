namespace Bank.UnitTests.Loans
{
    using System;
    using System.Collections.Generic;
    using Domain.Objects.Customer;
    using Domain.Objects.Loan;
    using Services.DomainServices.Loan;
    using Services.Exceptions;
    using Xunit;

    public class StandardLoanDomainServiceTests
    {
        private readonly ILoanDomainService _loanDomainService;

        public StandardLoanDomainServiceTests()
        {
            _loanDomainService = new StandardLoanDomainService();
        }

        [Fact]
        public void StandardLoan_Create_Succeeds()
        {
            var loan = new StandardLoan
            {
                CustomerId = 1,
                InterestRate = 0.2,
                LoanAmount = 10000,
                LoanStart = DateTime.Now,
                LoanEnd = DateTime.Now.AddYears(2)
            };

            var customer = new StandardCustomer
            {
                FirstName = "Arnas",
                LastName = "Danaitis",
                MonthlySalary = 3000,
                PersonalNumber = "12345678101"
            };

            var customerLoans = new List<Loan>
            {
                new StandardLoan
                {
                CustomerId = 1,
                InterestRate = 0.2,
                LoanAmount = 30000,
                LoanStart = DateTime.Now.AddYears(-1),
                LoanEnd = DateTime.Now.AddYears(1)
                }
            };

            Assert.True(_loanDomainService.CanCreateLoan(loan, customer, customerLoans));
        }

        [Fact]
        public void StandardLoan_Create_NoCustomer_Fails()
        {
            var loan = new StandardLoan
            {
                CustomerId = 1,
                InterestRate = 0.2,
                LoanAmount = 10000,
                LoanStart = DateTime.Now,
                LoanEnd = DateTime.Now.AddYears(2)
            };

            var customerLoans = new List<Loan>
            {
                new StandardLoan
                {
                    CustomerId = 1,
                    InterestRate = 0.2,
                    LoanAmount = 30000,
                    LoanStart = DateTime.Now.AddYears(-1),
                    LoanEnd = DateTime.Now.AddYears(1)
                }
            };

            Assert.Throws<BusinessException>(() => _loanDomainService.CanCreateLoan(loan, null, customerLoans));
        }

        [Fact]
        public void StandardLoan_Create_TooBigLoan_Fails()
        {
            var loan = new StandardLoan
            {
                CustomerId = 1,
                InterestRate = 0.2,
                LoanAmount = 10000,
                LoanStart = DateTime.Now,
                LoanEnd = DateTime.Now.AddYears(1)
            };

            var customer = new StandardCustomer
            {
                FirstName = "Arnas",
                LastName = "Danaitis",
                MonthlySalary = 1000,
                PersonalNumber = "12345678101"
            };

            Assert.Throws<BusinessException>(() => _loanDomainService.CanCreateLoan(loan, customer, new List<Loan>()));
        }

        [Fact]
        public void StandardLoan_Create_TooManyLoans_Fails()
        {
            var loan = new StandardLoan
            {
                CustomerId = 1,
                InterestRate = 0.2,
                LoanAmount = 10000,
                LoanStart = DateTime.Now,
                LoanEnd = DateTime.Now.AddYears(1)
            };

            var customer = new StandardCustomer
            {
                FirstName = "Arnas",
                LastName = "Danaitis",
                MonthlySalary = 1000,
                PersonalNumber = "12345678101"
            };

            var customerLoans = new List<Loan>
            {
                new StandardLoan
                {
                    CustomerId = 1,
                    InterestRate = 0.2,
                    LoanAmount = 30000,
                    LoanStart = DateTime.Now.AddYears(-1),
                    LoanEnd = DateTime.Now.AddYears(1)
                },
                new StandardLoan
                {
                    CustomerId = 1,
                    InterestRate = 0.2,
                    LoanAmount = 30000,
                    LoanStart = DateTime.Now.AddYears(-1),
                    LoanEnd = DateTime.Now.AddYears(1)
                }
            };

            Assert.Throws<BusinessException>(() => _loanDomainService.CanCreateLoan(loan, customer, customerLoans));
        }
    }
}