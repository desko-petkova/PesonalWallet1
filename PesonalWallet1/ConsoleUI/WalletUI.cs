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
            var account = walletService.GetAccounts();

            try
            {
                if(account.Count == 0)
                {
                    Console.WriteLine("No accounts found");
                }
                foreach(var acc  in account)
                {
                    Console.WriteLine($"{acc.Id} | {acc.Name} |" +
                        $"{acc.Type} | {acc.Balance.Amount}");
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            Console.ReadLine();
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
            Console.Write("Name: ");
            string name = Console.ReadLine();
            Console.WriteLine("Type:");
            Console.WriteLine("Cash: 0");
            Console.WriteLine("Bank: 1");
            Console.WriteLine("DebitCard: 2");
            Console.WriteLine("VirtualCard: 3");
            Console.WriteLine("SavingBank: 4");
            Console.Write("Choos type: ");
            int type =int.Parse(Console.ReadLine());
            var typeAccount = (AccountType)type;
            Console.Write("Initial amount: ");
             decimal amaunt = decimal.Parse(Console.ReadLine());
            try
            {
                walletService.CreateAccount(name, typeAccount, amaunt);
                Console.WriteLine("New account created!");
            }catch (Exception ex) { 
                Console.WriteLine(ex.Message); 
            }          
            Console.ReadLine();

        }
    }
}
