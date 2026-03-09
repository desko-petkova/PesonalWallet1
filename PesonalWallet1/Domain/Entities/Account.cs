using PesonalWallet1.Domain.Enums;
using PesonalWallet1.Domain.ValueObjects;

namespace PesonalWallet1.Domain.Entities
{
    public class Account
    {
        public int Id { get; private set; }
        public string Name { get;private set; } = string.Empty;
        public AccountType Type { get; private set; }
        public Money Balance { get; private set; }
        public Account() { }

        public Account(int id, string name, AccountType type, Money balance)
        {
            if (id <= 0) throw new ArgumentException("Id must be positive");
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentException("Account name is required");

            Id = id;
            Name = name;
            Type = type;
            Balance = balance;
        }

        public void Deposit(Money amount)
        {
           
            Balance = Balance.Add(amount);
        }
        public void Withdraw(Money amount)
        {
            Balance = Balance.Substract(amount);
        }


    }
}
