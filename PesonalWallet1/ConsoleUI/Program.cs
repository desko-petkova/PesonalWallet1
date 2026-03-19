using PesonalWallet1.Application;
using PesonalWallet1.Infrastucture;

namespace PesonalWallet1.ConsoleUI
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var storage = new FileStorage("wallet.json");

            IAccountRepository accountRepo = new FileAccountRepository(storage);

            ITransactionRepository transactionRepo = new FileTransactionRepository(storage);

            var service = new WalletService(accountRepo, transactionRepo);

            var ui = new WalletUI(service);

            ui.Run();

        }
    }
}
