namespace Bank.Services.DomainServices.Loan
{
    using System.Collections.Generic;
    using Domain.Objects.Customer;
    using Domain.Objects.Loan;

    public interface ILoanDomainService
    {
        bool CanCreateLoan(Loan loan, Customer customer, List<Loan> customerLoans);
    }
}