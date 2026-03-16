using NUnit.Framework;
using PersonalWallet.Domain.Entitys;
using PersonalWallet.Domain.Enums;
using PersonalWallet.Domain.ValueObjects;
using PersonalWallet.Infrastructure;

namespace PersonalWallet.Tests
{
    [TestFixture]
    public class RepositoryJsonTests
    {
        private string filePath = null!;

        private FileStorage storage = null!;
        private FileAccountRepository repository = null!;
        private FileTransactionRepository repo = null!;

        [SetUp]
        public void Setup()
        {
            filePath = Path.Combine(Path.GetTempPath(), $"{Guid.NewGuid()}.json");
            storage = new FileStorage(filePath);
            repository = new FileAccountRepository(storage);
            repo = new FileTransactionRepository(storage);
        }

        [TearDown]
        public void TearDown()
        {
            if (File.Exists(filePath))
                File.Delete(filePath);
        }

        // ============================= FileStorage.cs ========================

        [Test]
        public void Load_Should_Return_Empty_Storage_When_File_Does_Not_Exist()
        {
            var storage = new FileStorage(filePath);

            var result = storage.Load();

            Assert.That(result, Is.Not.Null);
            Assert.That(result.NextId, Is.EqualTo(1));
            Assert.That(result.Accounts, Is.Not.Null);
            Assert.That(result.Transactions, Is.Not.Null);
            Assert.That(result.Accounts.Count, Is.EqualTo(0));
            Assert.That(result.Transactions.Count, Is.EqualTo(0));
        }

        [Test]
        public void Save_And_Load_Should_Persist_Data()
        {
            var storage = new FileStorage(filePath);
            var data = new WalletStorage();
            data.NextId = 5;

            storage.Save(data);

            var loaded = storage.Load();

            Assert.That(loaded.NextId, Is.EqualTo(5));
        }


        // ============================= FileAccountRepository.cs ========================

    

        [Test]
        public void Save_Should_Add_New_Account_When_Id_Is_Zero()
        {
            var account = new Account(0, "Cash", AccountType.Cash, new Money(100));

            repository.Save(account);

            var all = repository.GetAll();

            Assert.That(all.Count, Is.EqualTo(1));
            Assert.That(all[0].Id, Is.EqualTo(1));
            Assert.That(all[0].Name, Is.EqualTo("Cash"));
            Assert.That(all[0].Balance.Amount, Is.EqualTo(100));
        }

        [Test]
        public void Save_Should_Update_Existing_Account()
        {
            repository.Save(new Account(0, "Cash", AccountType.Cash, new Money(100)));
            var existing = repository.GetAll()[0];

            existing.Deposit(new Money(50));
            repository.Save(existing);

            var updated = repository.GetById(existing.Id);

            Assert.That(updated.Balance.Amount, Is.EqualTo(150));
        }

        [Test]
        public void GetById_Should_Return_Account_When_Found()
        {
            repository.Save(new Account(0, "Bank", AccountType.Bank, new Money(200)));

            var account = repository.GetById(1);

            Assert.That(account.Name, Is.EqualTo("Bank"));
        }

        [Test]
        public void GetById_Should_Throw_When_Not_Found()
        {
            Assert.Throws<Exception>(() => repository.GetById(999));
        }

        [Test]
        public void GetAll_Should_Return_All_Accounts()
        {
            repository.Save(new Account(0, "Cash", AccountType.Cash, new Money(100)));
            repository.Save(new Account(0, "Bank", AccountType.Bank, new Money(200)));

            var all = repository.GetAll();

            Assert.That(all.Count, Is.EqualTo(2));
        }
        // ============================= FileTransactionRepository.cs ========================

        [Test]
        public void Save_Should_Add_New_Transaction_And_Generate_Id()
        {
            var transaction = new Transaction(
                0,
                1,
                TransactionType.Income,
                new Money(50),
                new DateTime(2026, 1, 1));

            repo.Save(transaction);

            var all = repo.GetByAccount(1);

            Assert.That(all.Count, Is.EqualTo(1));
            Assert.That(all[0].Id, Is.EqualTo(1));
            Assert.That(all[0].Amount.Amount, Is.EqualTo(50));
        }

        [Test]
        public void Save_Should_Throw_When_Transaction_Is_Null()
        {
            Assert.Throws<ArgumentNullException>(() => repo.Save(null!));
        }

        [Test]
        public void GetByAccount_Should_Return_Only_Transactions_For_Given_Account()
        {
            repo.Save(new Transaction(0, 1, TransactionType.Income, new Money(10), DateTime.Now));
            repo.Save(new Transaction(0, 1, TransactionType.Expense, new Money(5), DateTime.Now));
            repo.Save(new Transaction(0, 2, TransactionType.Income, new Money(100), DateTime.Now));

            var result = repo.GetByAccount(1);

            Assert.That(result.Count, Is.EqualTo(2));
            Assert.That(result.All(t => t.AccountId == 1), Is.True);
        }

        [Test]
        public void GetByAccount_Should_Return_Empty_List_When_No_Transactions()
        {
            var result = repo.GetByAccount(999);

            Assert.That(result, Is.Not.Null);
            Assert.That(result.Count, Is.EqualTo(0));
        }
    }
}
