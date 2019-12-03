namespace Bank.Services.Mappers.Loans
{
    using Contracts.Request;
    using Domain.Entities;
    using Domain.Objects.Loan;

    public class StandardLoanMapper : BaseLoanMapper
    {
        public override Loan MapToDomain(LoanRequest loan)
        {
            return new StandardLoan
            {
                CustomerId = loan.CustomerId,
                InterestRate = loan.InterestRate,
                LoanAmount = loan.LoanAmount,
                LoanStart = loan.LoanStart,
                LoanEnd = loan.LoanEnd
            };
        }

        public override Loan MapToDomain(LoanEntity loan)
        {
            return new StandardLoan
            {
                Id = loan.Id,
                CustomerId = loan.CustomerId,
                InterestRate = loan.InterestRate,
                LoanAmount = loan.LoanAmount,
                LoanStart = loan.LoanStart,
                LoanEnd = loan.LoanEnd
            };
        }
    }
}