namespace Bank.Services.Mappers.Loans
{
    using Contracts.Request;
    using Contracts.Response;
    using Domain.Entities;
    using Domain.Objects.Loan;

    public interface ILoanMapper
    {
        Loan MapToDomain(LoanRequest loan);

        Loan MapToDomain(LoanEntity loan);

        LoanEntity MapToEntity(Loan loan);

        LoanResponse MapToResponse(Loan loan);
    }
}