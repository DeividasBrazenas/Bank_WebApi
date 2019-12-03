namespace Bank.Domain.Entities
{
    using System.Collections.Generic;

    public class CustomerEntity : BaseEntity
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string PersonalNumber { get; set; }

        public double MonthlySalary { get; set; }

        public List<LoanEntity> Loans { get; set; }

        public List<AccountEntity> Accounts { get; set; }
    }
}