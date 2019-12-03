namespace Bank.Domain.Entities
{
    using System;

    public class LoanEntity : BaseEntity
    {
        public int CustomerId { get; set; }

        public CustomerEntity Customer { get; set; }

        public double InterestRate { get; set; }

        public int LoanAmount { get; set; }

        public DateTime LoanStart { get; set; }

        public DateTime LoanEnd { get; set; }
    }
}