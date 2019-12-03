namespace Bank.Domain.Objects.Loan
{
    using Enums;

    public class StandardLoan : Loan
    {
        public override BankingType Type => BankingType.Standard;
    }
}