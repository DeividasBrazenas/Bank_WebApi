namespace Bank.Domain.Objects.Customer
{
    using Objects;

    public abstract class Customer : BaseObject
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string PersonalNumber { get; set; }

        public double MonthlySalary { get; set; }
    }
}