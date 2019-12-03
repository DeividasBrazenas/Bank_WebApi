namespace Bank.Contracts.Response
{
    using System;
    using Enums;

    public class LoanResponse
    {
        public int Id { get; set; }

        public BankingType Type { get; set; }

        public int CustomerId { get; set; }

        public int LoanAmount { get; set; }

        public double InterestRate { get; set; }

        public DateTime LoanStart { get; set; }

        public DateTime LoanEnd { get; set; }
    }
}