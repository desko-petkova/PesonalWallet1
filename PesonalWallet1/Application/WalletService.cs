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



    }
}
