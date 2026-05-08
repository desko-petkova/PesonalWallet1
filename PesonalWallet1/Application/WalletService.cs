using PesonalWallet1.Domain.Entities;
using PesonalWallet1.Domain.Enums;
using PesonalWallet1.Domain.ValueObjects;


namespace PesonalWallet1.Application
{
    public class WalletService
    {
        private readonly IAccountRepository accountRepository;
        private readonly ITransactionRepository transactionRepository;

        public WalletService(IAccountRepository accountRepo, ITransactionRepository transactionRepo)
        {
            this.accountRepository = accountRepo;
            this.transactionRepository = transactionRepo;
        }

        public void CreateAccount(string name, AccountType type, decimal balance)
        {
            var account = new Account(
                0,
                name, 
                type, 
                new Money(balance)
                );

            accountRepository.Save(account);
        }

        public IReadOnlyList<Account> GetAccounts()
        {
            return accountRepository.GetAll();
        }
        public IReadOnlyList<PesonalWallet1.Domain.Entities.Transation> GetTransactions(int accountId)
        {
            return transactionRepository.GetByAccountId(accountId);
        }

        public void CreateTransaction(int accountId, TransactionType type, decimal amount)
        {
            var account = accountRepository.GetById(accountId);

            var money = new Money(amount);

            if (type == TransactionType.Income)
            {
                account.Deposit(money);
            }
            else
            {
                account.Withdraw(money);
            }

            accountRepository.Save(account);

            var transaction = new PesonalWallet1.Domain.Entities.Transation(
                0,
                accountId,
                type,
                money,
                DateTime.Now);

            transactionRepository.Save(transaction);
        }

    }
}
