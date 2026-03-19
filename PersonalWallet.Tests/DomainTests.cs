using NUnit.Framework;
using PesonalWallet1.Domain.Entities;
using PesonalWallet1.Domain.Enums;
using PesonalWallet1.Domain.ValueObjects;

namespace PersonalWallet.Tests
{
    [TestFixture]
    public class DomainTests
    {
        // ============================== Money.cs ===================================
        [Test]
        public void Constructor_Should_Set_Amount_When_Valid()
        {
            var money = new Money(25.50m);

            Assert.That(money.Amount, Is.EqualTo(25.50m));
        }

        [Test]
        public void Constructor_Should_Throw_When_Amount_Is_Negative()
        {
            Assert.Throws<ArgumentException>(() => new Money(-1));
        }

        [Test]
        public void Add_Should_Return_New_Money_With_Sum()
        {
            var left = new Money(10);
            var right = new Money(5);

            var result = left.Add(right);

            Assert.That(result.Amount, Is.EqualTo(15));
        }

        [Test]
        public void Subtract_Should_Return_New_Money_When_Result_Is_Valid()
        {
            var left = new Money(10);
            var right = new Money(4);

            var result = left.Substract(right);

            Assert.That(result.Amount, Is.EqualTo(6));
        }

        [Test]
        public void Subtract_Should_Throw_When_Result_Would_Be_Negative()
        {
            var left = new Money(10);
            var right = new Money(11);

            Assert.Throws<InvalidOperationException>(() => left.Substract(right));
        }

        // ============================== Account.cs ===================================

        [Test]
        public void Constructor_Should_Create_Account_When_Data_Is_Valid()
        {
            var account = new Account(1, "Cash", AccountType.Cash, new Money(100));

            Assert.That(account.Id, Is.EqualTo(1));
            Assert.That(account.Name, Is.EqualTo("Cash"));
            Assert.That(account.Type, Is.EqualTo(AccountType.Cash));
            Assert.That(account.Balance.Amount, Is.EqualTo(100));
        }

        [Test]
        public void Constructor_Should_Throw_When_Id_Is_Negative()
        {
            Assert.Throws<ArgumentException>(() =>
                new Account(-1, "Cash", AccountType.Cash, new Money(100)));
        }

        [Test]
        public void Constructor_Should_Throw_When_Name_Is_Empty()
        {
            Assert.Throws<ArgumentException>(() =>
                new Account(1, "", AccountType.Cash, new Money(100)));
        }

        [Test]
        public void Deposit_Should_Increase_Balance()
        {
            var account = new Account(1, "Cash", AccountType.Cash, new Money(100));

            account.Deposit(new Money(25));

            Assert.That(account.Balance.Amount, Is.EqualTo(125));
        }

        [Test]
        public void Deposit_Should_Throw_When_Amount_Is_Zero()
        {
            var account = new Account(1, "Cash", AccountType.Cash, new Money(100));

            Assert.Throws<ArgumentException>(() => account.Deposit(new Money(0)));
        }

        [Test]
        public void Withdraw_Should_Decrease_Balance()
        {
            var account = new Account(1, "Cash", AccountType.Cash, new Money(100));

            account.Withdraw(new Money(40));

            Assert.That(account.Balance.Amount, Is.EqualTo(60));
        }

        [Test]
        public void Withdraw_Should_Throw_When_Amount_Is_Zero()
        {
            var account = new Account(1, "Cash", AccountType.Cash, new Money(100));

            Assert.Throws<ArgumentException>(() => account.Withdraw(new Money(0)));
        }

        [Test]
        public void Withdraw_Should_Throw_When_Balance_Is_Not_Enough()
        {
            var account = new Account(1, "Cash", AccountType.Cash, new Money(100));

            Assert.Throws<InvalidOperationException>(() => account.Withdraw(new Money(101)));
        }

        // ============================== Transaction.cs ===================================

        [Test]
        public void Constructor_Should_Create_Transaction_When_Data_Is_Valid()
        {
            var date = new DateTime(2026, 1, 1);

            var transaction = new PesonalWallet1.Domain.Entities.Transation(
                1,
                2,
                TransactionType.Income,
                new Money(50),
                date);

            Assert.That(transaction.Id, Is.EqualTo(1));
            Assert.That(transaction.AccountId, Is.EqualTo(2));
            Assert.That(transaction.Type, Is.EqualTo(TransactionType.Income));
            Assert.That(transaction.Amount.Amount, Is.EqualTo(50));
            Assert.That(transaction.Date, Is.EqualTo(date));
        }

        [Test]
        public void Constructor_Should_Throw_When_Id_Is_Negative_Transaction()
        {
            Assert.Throws<ArgumentException>(() =>
                new PesonalWallet1.Domain.Entities.Transation(-1, 1, TransactionType.Income, new Money(10), DateTime.Now));
        }

        [Test]
        public void Constructor_Should_Throw_When_AccountId_Is_Not_Positive()
        {
            Assert.Throws<ArgumentException>(() =>
                new PesonalWallet1.Domain.Entities.Transation(1, 0, TransactionType.Income, new Money(10), DateTime.Now));
        }

        [Test]
        public void Constructor_Should_Throw_When_Amount_Is_Zero()
        {
            Assert.Throws<ArgumentException>(() =>
                new PesonalWallet1.Domain.Entities.Transation(1, 1, TransactionType.Income, new Money(0), DateTime.Now));
        }
    }
}
