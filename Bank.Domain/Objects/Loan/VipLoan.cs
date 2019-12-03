namespace Bank.Domain.Objects.Loan
{
    using Enums;

    public class VipLoan : Loan
    {
        public override BankingType Type => BankingType.Vip;
    }
}