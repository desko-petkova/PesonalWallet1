using PesonalWallet1.Domain.Entities;
using PesonalWallet1.Domain.Enums;
using PesonalWallet1.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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


    }
}
