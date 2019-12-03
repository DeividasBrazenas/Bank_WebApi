namespace Bank.Contracts.Response
{
    using Enums;

    public class CustomerResponse
    {
        public int Id { get; set; }

        public BankingType Type { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string PersonalNumber { get; set; }

        public double MonthlySalary { get; set; }
    }
}