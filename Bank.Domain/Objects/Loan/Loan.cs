namespace Bank.Domain.Objects.Loan
{
    using System;
    using Objects;

    public abstract class Loan : BaseObject
    {
        public int CustomerId { get; set; }

        public double InterestRate { get; set; }

        public int LoanAmount { get; set; }

        public DateTime LoanStart { get; set; }

        public DateTime LoanEnd { get; set; }
    }
}