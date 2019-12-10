namespace Bank.Domain.Objects.Account
{
    using Objects;

    public abstract class Account : BaseObject
    {
        public int CustomerId { get; set; }

        public string Number { get; set; }

        public int Balance { get; set; }
    }
}