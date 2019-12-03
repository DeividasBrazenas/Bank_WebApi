namespace Bank.Contracts.Request
{
    using System;
    using System.ComponentModel.DataAnnotations;

    public class LoanRequest
    {
        [Required]
        public int CustomerId { get; set; }

        [Required]
        public int LoanAmount { get; set; }

        [Required]
        public double InterestRate { get; set; }

        [Required]
        public DateTime LoanStart { get; set; }

        [Required]
        public DateTime LoanEnd { get; set; }
    }
}