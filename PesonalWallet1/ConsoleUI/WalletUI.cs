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

        private void AddTransaction(TransactionType type)
        {
            Console.Write("Account Id: ");
            string accountInput = Console.ReadLine();

            Console.Write("Amount: ");
            string amountInput = Console.ReadLine();

            if (!int.TryParse(accountInput, out int accountId))
            {
                Console.WriteLine("Invalid account id.");
                Pause();
                return;
            }

            if (!decimal.TryParse(amountInput, out decimal amount))
            {
                Console.WriteLine("Invalid amount.");
                Pause();
                return;
            }

            try
            {

                walletService.CreateTransaction(accountId, type, amount);
                Console.WriteLine("Transaction added successfully.");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            Pause();
        }
        private static void Pause()
        {
            Console.WriteLine();
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
        }

        private void ShowTransaction()
        {
            Console.Write("Account Id: ");
            string accountInput = Console.ReadLine();
            if (!int.TryParse(accountInput, out int accountId))
            {
                Console.WriteLine("Invalid account id.");
                Pause();
                return;
            }

            var transactions = walletService.GetTransactions(accountId);

            foreach (var t in transactions)
            {
                Console.WriteLine($"{t.Id} {t.Type} {t.Amount.Amount} {t.Date}");
            }

            Pause();
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
