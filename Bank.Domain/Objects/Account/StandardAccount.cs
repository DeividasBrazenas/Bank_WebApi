namespace Bank.Domain.Objects.Account
{
    using Enums;

    public class StandardAccount : Account
    {
        public override BankingType Type => BankingType.Standard;
    }
}