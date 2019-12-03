namespace Bank.Contracts.Request
{
    using System.ComponentModel.DataAnnotations;

    public class AccountRequest
    {
        [Required]
        public int CustomerId { get; set; }

        [Required]
        [MinLength(20), MaxLength(20)]
        public string Number { get; set; }

        [Required]
        public int Balance { get; set; }
    }
}