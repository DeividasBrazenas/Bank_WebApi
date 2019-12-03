namespace Bank.Services.DataAgents.Account
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Domain.Objects.Account;
    using Mappers.Accounts;
    using Repositories.Account;

    public class AccountDataAgent : IAccountDataAgent
    {
        private readonly IAccountRepository _accountRepository;
        private readonly IAccountMapper _accountMapper;

        public AccountDataAgent(IAccountRepository accountRepository, IAccountMapper accountMapper)
        {
            _accountRepository = accountRepository;
            _accountMapper = accountMapper;
        }

        public Task<int?> CreateAccount(Account account)
        {
            var accountEntity = _accountMapper.MapToEntity(account);

            return _accountRepository.Add(accountEntity);
        }

        public async Task<List<Account>> GetAllAccounts()
        {
            var accounts = await _accountRepository.GetAll();

            return accounts.Select(x => _accountMapper.MapToDomain(x)).ToList();
        }

        public async Task<Account> GetAccountById(int id)
        {
            var account = await _accountRepository.GetById(id);

            return account == null ? null : _accountMapper.MapToDomain(account);
        }

        public async Task<List<Account>> GetAccountsByCustomerId(int id)
        {
            var accounts = await _accountRepository.GetAccountsByCustomerId(id);

            return accounts.Select(x => _accountMapper.MapToDomain(x)).ToList();
        }

        public async Task<Account> UpdateAccount(int id, Account account)
        {
            var accountEntity = _accountMapper.MapToEntity(account);

            var updatedAccount = await _accountRepository.Update(id, accountEntity);

            return updatedAccount == null ? null : _accountMapper.MapToDomain(updatedAccount);
        }

        public Task<int?> DeleteAccount(int id)
        {
            return _accountRepository.Delete(id);
        }
    }
}