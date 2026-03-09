using PesonalWallet1.Domain.Enums;
using PesonalWallet1.Domain.ValueObjects;
namespace PesonalWallet1.Domain.Entities
{
    public class Transation
    {
        public int Id { get; private set; }
        public int AccountId { get; private set; }
        public TransactionType Type { get; private set; }
        public Money Amount { get; private set; }
        public DateTime Date { get; private set; }

        public Transation() { } //JSON

        public Transation(int id, int accountId, TransactionType type, Money amount, DateTime date)
        {
            if (id <= 0) throw new ArgumentException("Id must be positive");
            if (accountId <= 0) throw new ArgumentException("AccountId must be positive");
            Id = id;
            AccountId = accountId;
            Type = type;
            Amount = amount;
            Date = date;
        }
    }
}
