namespace Bank.Contracts.Response
{
    using Enums;

    public class AccountResponse
    {
        public int Id { get; set; }

        public BankingType Type { get; set; }

        public int CustomerId { get; set; }

        public string Number { get; set; }

        public int Balance { get; set; }
    }
}