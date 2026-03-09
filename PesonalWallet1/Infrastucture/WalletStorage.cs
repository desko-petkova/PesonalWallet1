using PesonalWallet1.Domain.Entities;

namespace PesonalWallet1.Infrastucture
{
    public class WalletStorage
    {
        public List<Account> Accounts { get; set; } = new List<Account>();

        public List<Transation> Transactions { get; set; } = new List<Transation>();

    }
}
