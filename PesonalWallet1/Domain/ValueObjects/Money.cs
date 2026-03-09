using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PesonalWallet1.Domain.ValueObjects
{
    public class Money
    {
        public decimal Amount { get; }

        public Money(decimal amount)
        {
            if (amount < 0) throw new ArgumentException("Amount must be positive");

            Amount = amount;
        }

        public Money Add(Money other)
        {
            return new Money(Amount + other.Amount);
        }

        public Money Substract(Money other)
        {
            decimal result = Amount - other.Amount;

            if (result < 0) throw new ArgumentException("Result must be positive");

            return new Money(result);
        }

    }
}
