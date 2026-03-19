using PesonalWallet1.Domain.Entities;

namespace PesonalWallet1.Application
{
    public interface ITransactionRepository
    {
        IReadOnlyList<Transation> GetByAccountId(int id);
        void Save(Transation transaction);
    }
}
