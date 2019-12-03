namespace Bank.UnitTests.Accounts
{
    using System.Collections.Generic;
    using Domain.Objects.Account;
    using Moq;
    using Serilog;
    using Services.DomainServices.Account;
    using Services.Exceptions;
    using Xunit;

    public class VipAccountDomainServiceTests
    {
        private readonly IAccountDomainService _accountDomainService;

        public VipAccountDomainServiceTests()
        {
            _accountDomainService = new VipAccountDomainService();
        }

        [Fact]
        public void VipAccount_Create_Succeeds()
        {
            var account = new VipAccount
            {
                CustomerId = 1,
                Balance = 1000,
                Number = "LT123456789012345678"
            };

            var existingAccounts = new List<Account>
            {
                new VipAccount
                {
                    CustomerId = 1,
                    Balance = 1000,
                    Number = "LT123456789012345679"
                },
                new VipAccount
                {
                    CustomerId = 1,
                    Balance = 1000,
                    Number = "LT123456789012345670"
                }
            };

            Assert.True(_accountDomainService.CanCreateAccount(account, existingAccounts));
        }

        [Fact]
        public void VipAccount_Create_5AccountsAlreadyExist_Fails()
        {
            var account = new VipAccount
            {
                CustomerId = 1,
                Balance = 1000,
                Number = "LT123456789012345678"
            };

            var existingAccounts = new List<Account>
            {
                new VipAccount
                {
                    CustomerId = 1,
                    Balance = 1000,
                    Number = "LT123456789012345679"
                },
                new VipAccount
                {
                    CustomerId = 1,
                    Balance = 1000,
                    Number = "LT123456789012345670"
                },
                new VipAccount
                {
                    CustomerId = 1,
                    Balance = 1000,
                    Number = "LT123456789012345671"
                },
                new VipAccount
                {
                    CustomerId = 1,
                    Balance = 1000,
                    Number = "LT123456789012145671"
                },
                new VipAccount
                {
                    CustomerId = 1,
                    Balance = 1000,
                    Number = "LT123456789012345671"
                }
            };

            Assert.Throws<BusinessException>(() => _accountDomainService.CanCreateAccount(account, existingAccounts));
        }

        [Fact]
        public void VipAccount_Create_AccountWithSameNumber_Fails()
        {
            var account = new VipAccount
            {
                CustomerId = 1,
                Balance = 1000,
                Number = "LT123456789012345678"
            };

            var existingAccounts = new List<Account>
            {
                new VipAccount
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
