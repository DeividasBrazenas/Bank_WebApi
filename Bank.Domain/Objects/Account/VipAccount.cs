namespace Bank.Domain.Objects.Account
{
    using Enums;

    public class VipAccount : Account
    {
        public override BankingType Type => BankingType.Vip;
    }
}