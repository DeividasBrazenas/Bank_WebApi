namespace Bank.Domain.Entities
{
    using System;
    using Enums;

    public abstract class BaseEntity
    {
        public int Id { get; set; }

        public BankingType Type { get; set; }

        public DateTime CreatedOn { get; set; }

        public DateTime? ModifiedOn { get; set; }
    }
}