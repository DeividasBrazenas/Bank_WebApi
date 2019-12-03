namespace Bank.Services.DomainServices.Loan
{
    using System.Collections.Generic;
    using Domain.Objects.Customer;
    using Domain.Objects.Loan;
    using Exceptions;
    using Extensions;
    using Serilog;

    public class StandardLoanDomainService : ILoanDomainService
    {
        public bool CanCreateLoan(Loan loan, Customer customer, List<Loan> customerLoans)
        {
            if (customer == null)
            {
                var errorMessage = $"Customer with id {loan.CustomerId} doesn't exists";

                throw new BusinessException(errorMessage);
            }

            var monthlyLoanAmount = loan.LoanAmount / loan.LoanStart.TotalMonths(loan.LoanEnd);
            var totalMonthlyLoanAmount = monthlyLoanAmount + monthlyLoanAmount * loan.InterestRate;

            if (customer.MonthlySalary / 3 < totalMonthlyLoanAmount)
            {
                var errorMessage = $"Loan amount is too big. Maximum loan amount is {customer.MonthlySalary / 3} per month. " +
                                   $"Your provided loan amount per month (with interest rate) is {totalMonthlyLoanAmount} per month.";

                throw new BusinessException(errorMessage);
            }

            if (customerLoans.Count > 1)
            {
                var errorMessage = $"Customer already has {customerLoans.Count} loans";

                throw new BusinessException(errorMessage);
            }

            return true;
        }
    }
}