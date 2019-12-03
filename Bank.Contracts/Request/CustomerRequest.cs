namespace Bank.Contracts.Request
{
    using System.ComponentModel.DataAnnotations;

    public class CustomerRequest
    {
        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        [Required]
        public double MonthlySalary { get; set; }

        [Required]
        [MinLength(11), MaxLength(11)]
        public string PersonalNumber { get; set; }
    }
}