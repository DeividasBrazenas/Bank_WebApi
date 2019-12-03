namespace Bank.UnitTests.Accounts
{
    using System.Collections.Generic;
    using Domain.Objects.Account;
    using Moq;
    using Serilog;
    using Services.DomainServices.Account;
    using Services.Exceptions;
    using Xunit;

    public class StandardAccountDomainServiceTests
    {
        private readonly IAccountDomainService _accountDomainService;

        public StandardAccountDomainServiceTests()
        {
            _accountDomainService = new StandardAccountDomainService();
        }

        [Fact]
        public void StandardAccount_Create_Succeeds()
        {
            var account = new StandardAccount
            {
                CustomerId = 1,
                Balance = 1000,
                Number = "LT123456789012345678"
            };

            var existingAccounts = new List<Account>
            {
                new StandardAccount
                {
                    CustomerId = 1,
                    Balance = 1000,
                    Number = "LT123456789012345679"
                },
                new StandardAccount
                {
                    CustomerId = 1,
                    Balance = 1000,
                    Number = "LT123456789012345670"
                }
            };

            Assert.True(_accountDomainService.CanCreateAccount(account, existingAccounts));
        }

        [Fact]
        public void StandardAccount_Create_3AccountsAlreadyExist_Fails()
        {
            var account = new StandardAccount
            {
                CustomerId = 1,
                Balance = 1000,
                Number = "LT123456789012345678"
            };

            var existingAccounts = new List<Account>
            {
                new StandardAccount
                {
                    CustomerId = 1,
                    Balance = 1000,
                    Number = "LT123456789012345679"
                },
                new StandardAccount
                {
                    CustomerId = 1,
                    Balance = 1000,
                    Number = "LT123456789012345670"
                },
                new StandardAccount
                {
                    CustomerId = 1,
                    Balance = 1000,
                    Number = "LT123456789012345671"
                }
            };

            Assert.Throws<BusinessException>(() => _accountDomainService.CanCreateAccount(account, existingAccounts));
        }

        [Fact]
        public void StandardAccount_Create_AccountWithSameNumber_Fails()
        {
            var account = new StandardAccount
            {
                CustomerId = 1,
                Balance = 1000,
                Number = "LT123456789012345678"
            };

            var existingAccounts = new List<Account>
            {
                new StandardAccount
                {
                    CustomerId = 1,
                    Balance = 1000,
                    Number = "LT123456789012345678"
                }
            };

            Assert.Throws<BusinessException>(() => _accountDomainService.CanCreateAccount(account, existingAccounts));
        }
    }
}
