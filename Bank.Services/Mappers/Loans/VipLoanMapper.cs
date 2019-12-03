namespace Bank.Services.Mappers.Loans
{
    using Contracts.Request;
    using Domain.Entities;
    using Domain.Objects.Loan;

    public class VipLoanMapper : BaseLoanMapper
    {
        public override Loan MapToDomain(LoanRequest loan)
        {
            return new VipLoan
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
            return new VipLoan
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