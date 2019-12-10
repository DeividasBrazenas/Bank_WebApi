namespace Bank.Services.Mappers.Loans
{
    using Contracts.Request;
    using Contracts.Response;
    using Domain.Entities;
    using Domain.Objects.Loan;

    public abstract class BaseLoanMapper : ILoanMapper
    {
        public abstract Loan MapToDomain(LoanRequest loan);

        public abstract Loan MapToDomain(LoanEntity loan);

        public LoanEntity MapToEntity(Loan loan)
        {
            return new LoanEntity
            {
                Id = loan.Id,
                CustomerId = loan.CustomerId,
                InterestRate = loan.InterestRate,
                LoanAmount = loan.LoanAmount,
                LoanStart = loan.LoanStart,
                LoanEnd = loan.LoanEnd,
                Type = (BankingType)loan.Type
            };
        }

        public LoanResponse MapToResponse(Loan loan)
        {
            return new LoanResponse
            {
                Id = loan.Id,
                CustomerId = loan.CustomerId,
                InterestRate = loan.InterestRate,
                LoanAmount = loan.LoanAmount,
                LoanStart = loan.LoanStart,
                LoanEnd = loan.LoanEnd,
                Type = (Contracts.Enums.BankingType)loan.Type
            };
        }
    }
}