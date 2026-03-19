using PesonalWallet1.Domain.Entities;

namespace PesonalWallet1.Infrastucture
{
    public class WalletStorage
    {
        public int NextId { get; set; } = 1;
        public List<Account> Accounts { get; set; } = new();

        public List<Transation> Transactions { get; set; } = new();

    }
}
