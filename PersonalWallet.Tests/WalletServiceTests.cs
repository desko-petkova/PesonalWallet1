//using NUnit.Framework;
//using PesonalWallet1.Domain.Enums;
//using PesonalWallet1.Infrastucture;

//namespace PersonalWallet.Tests
//{
//    [TestFixture]
//    public class WalletServiceTests
//    {
//        private string filePath = null!;
//        private FileStorage storage = null!;
//        private FileAccountRepository accountRepo = null!;
//        private FileTransactionRepository transactionRepo = null!;
//        private WalletService service = null!;

//        [SetUp]
//        public void Setup()
//        {
//            filePath = Path.Combine(Path.GetTempPath(), $"{Guid.NewGuid()}.json");
//            storage = new FileStorage(filePath);
//            accountRepo = new FileAccountRepository(storage);
//            transactionRepo = new FileTransactionRepository(storage);
//            service = new WalletService(accountRepo, transactionRepo);
//        }

//        [TearDown]
//        public void TearDown()
//        {
//            if (File.Exists(filePath))
//                File.Delete(filePath);
//        }

//        [Test]
//        public void CreateAccount_Should_Save_New_Account()
//        {
//            service.CreateAccount("Cash", AccountType.Cash, 100);

//            var accounts = service.GetAccounts();

//            Assert.That(accounts.Count, Is.EqualTo(1));
//            Assert.That(accounts[0].Name, Is.EqualTo("Cash"));
//            Assert.That(accounts[0].Balance.Amount, Is.EqualTo(100));
//        }

//        [Test]
//        public void CreateTransaction_Income_Should_Increase_Balance_And_Save_Transaction()
//        {
//            service.CreateAccount("Cash", AccountType.Cash, 100);
//            var account = service.GetAccounts()[0];

//            service.CreateTransaction(account.Id, TransactionType.Income, 50);

//            var updated = service.GetAccounts()[0];
//            var transactions = service.GetTransactions(account.Id);

//            Assert.That(updated.Balance.Amount, Is.EqualTo(150));
//            Assert.That(transactions.Count, Is.EqualTo(1));
//            Assert.That(transactions[0].Type, Is.EqualTo(TransactionType.Income));
//        }

//        [Test]
//        public void CreateTransaction_Expense_Should_Decrease_Balance_And_Save_Transaction()
//        {
//            service.CreateAccount("Cash", AccountType.Cash, 100);
//            var account = service.GetAccounts()[0];

//            service.CreateTransaction(account.Id, TransactionType.Expense, 40);

//            var updated = service.GetAccounts()[0];
//            var transactions = service.GetTransactions(account.Id);

//            Assert.That(updated.Balance.Amount, Is.EqualTo(60));
//            Assert.That(transactions.Count, Is.EqualTo(1));
//            Assert.That(transactions[0].Type, Is.EqualTo(TransactionType.Expense));
//        }

//        [Test]
//        public void CreateTransaction_Expense_Should_Throw_When_Balance_Is_Not_Enough()
//        {
//            service.CreateAccount("Cash", AccountType.Cash, 100);
//            var account = service.GetAccounts()[0];

//            Assert.Throws<InvalidOperationException>(() =>
//                service.CreateTransaction(account.Id, TransactionType.Expense, 101));
//        }

//        [Test]
//        public void GetTransactions_Should_Return_Only_Transactions_For_Given_Account()
//        {
//            service.CreateAccount("Cash", AccountType.Cash, 100);
//            service.CreateAccount("Bank", AccountType.Bank, 200);

//            var accounts = service.GetAccounts();
//            var first = accounts[0];
//            var second = accounts[1];

//            service.CreateTransaction(first.Id, TransactionType.Income, 10);
//            service.CreateTransaction(first.Id, TransactionType.Expense, 5);
//            service.CreateTransaction(second.Id, TransactionType.Income, 20);

//            var firstTransactions = service.GetTransactions(first.Id);

//            Assert.That(firstTransactions.Count, Is.EqualTo(2));
//            Assert.That(firstTransactions.All(t => t.AccountId == first.Id), Is.True);
//        }
//    }
//}
