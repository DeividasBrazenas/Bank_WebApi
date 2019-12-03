namespace Bank.Domain.Objects.Customer
{
    using Enums;

    public class StandardCustomer : Customer
    {
        public override BankingType Type => BankingType.Standard;
    }
}