using PesonalWallet1.Application;
using PesonalWallet1.Domain.Enums;

namespace PesonalWallet1.ConsoleUI
{
    public class WalletUI
    {
        private readonly WalletService walletService;
        public WalletUI(WalletService walletService)
        {
            this.walletService = walletService;
        }
        public void Run()
        {
            bool running = true;

            while (running)
            {

                Console.Clear();
                Console.WriteLine("==== Wallet System ====");
                Console.WriteLine("1. Create account");
                Console.WriteLine("2. Add income");
                Console.WriteLine("3. Add expense");
                Console.WriteLine("4. Show accounts");
                Console.WriteLine("5. Show transactions");
                Console.WriteLine("x. Exit");

                Console.Write("Choose: ");
                string input = Console.ReadLine();

                switch (input)
                {
                    case "1":
                        CreateAccount();
                        break;
                    case "2":
                        AddTransaction(TransactionType.Income);
                        break;
                    case "3":
                        AddTransaction(TransactionType.Expense);
                        break;
                    case "4":
                        ShowAccount();
                        break;
                    case "5":
                        ShowTransaction();
                        break;
                    case "x":
                        running = false;
                        break;
                }
            }


        }

        private void ShowAccount()
        {
            throw new NotImplementedException();
        }

        private void AddTransaction(TransactionType income)
        {
            throw new NotImplementedException();
        }

      

        private void ShowTransaction()
        {
            throw new NotImplementedException();
        }

        private void CreateAccount()
        {
            throw new NotImplementedException();
        }
    }
}
