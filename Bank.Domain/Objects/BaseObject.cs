namespace Bank.Domain.Objects
{
    using Enums;

    public abstract class BaseObject
    {
        public int Id { get; set; }

        public virtual BankingType Type { get; }
    }
}