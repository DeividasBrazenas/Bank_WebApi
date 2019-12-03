namespace Bank.Domain.Entities
{
    public class AccountEntity : BaseEntity
    {
        public int CustomerId { get; set; }

        public CustomerEntity Customer { get; set; }

        public string Number { get; set; }

        public int Balance { get; set; }
    }
}