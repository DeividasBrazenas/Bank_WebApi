namespace Bank.Domain.Objects.Customer
{
    using Enums;

    public class VipCustomer : Customer
    {
        public override BankingType Type => BankingType.Vip;
    }
}