namespace Bank.Services.Services.Account
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Contracts.Request;
    using Contracts.Response;
    using DataAgents.Account;
    using Mappers.Accounts;
    using Serilog;

    public class BadAccountService : IAccountService
    {
        private readonly IAccountDataAgent _accountDataAgent;
        private readonly IAccountMapper _accountMapper;
        private readonly ILogger _logger;

        public BadAccountService(IAccountDataAgent accountDataAgent, IAccountMapper accountMapper, ILogger logger)
        {
            _accountDataAgent = accountDataAgent;
            _accountMapper = accountMapper;
            _logger = logger;
        }

        public async Task<int?> CreateAccount(AccountRequest account)
        {
            var existingCustomersAccounts = await _accountDataAgent.GetAccountsByCustomerId(account.CustomerId);

            var accountObject = _accountMapper.MapToDomain(account);

            var createdAccountId = await _accountDataAgent.CreateAccount(accountObject);

            _logger.Information($"Account created. Id - {createdAccountId}");

            return createdAccountId;
        }

        public async Task<List<AccountResponse>> GetAllAccounts()
        {
            var accounts = await _accountDataAgent.GetAllAccounts();

            _logger.Information($"Accounts count - {accounts.Count}");

            return accounts.Select(x => _accountMapper.MapToResponse(x)).ToList();
        }

        public async Task<AccountResponse> GetAccountById(int id)
        {
            var account = await _accountDataAgent.GetAccountById(id);

            _logger.Information($"Account retrieved. Id - {id}");

            return account == null ? null : _accountMapper.MapToResponse(account);
        }

        public async Task<List<AccountResponse>> GetAccountsByCustomerId(int id)
        {
            var accounts = await _accountDataAgent.GetAccountsByCustomerId(id);

            _logger.Information($"Customer's accounts retrieved. Count - {accounts.Count}");

            return accounts.Select(x => _accountMapper.MapToResponse(x)).ToList();
        }

        public async Task<AccountResponse> UpdateAccount(int id, AccountRequest account)
        {
            var accountObject = _accountMapper.MapToDomain(account);

            var updatedAccount = await _accountDataAgent.UpdateAccount(id, accountObject);

            if (updatedAccount != null)
            {
                _logger.Information($"Account updated. Id - {updatedAccount.Id}");

                return _accountMapper.MapToResponse(updatedAccount);
            }

            return null;
        }

        public async Task<int?> DeleteAccount(int id)
        {
            var deletedAccountId = await _accountDataAgent.DeleteAccount(id);

            if (deletedAccountId != null)
            {
                _logger.Information($"Account deleted. Id - {deletedAccountId}");

                return deletedAccountId;
            }

            return null;
        }
    }
}