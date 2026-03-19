using PesonalWallet1.Domain.Entities;

namespace PesonalWallet1.Application
{
    public interface IAccountRepository
    {
        IReadOnlyList<Account> GetAll();
        Account GetById(int id);
        void Save(Account account);
    }
}
