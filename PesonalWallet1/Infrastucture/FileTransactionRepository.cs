using PesonalWallet1.Application;
using PesonalWallet1.Domain.Entities;

namespace PesonalWallet1.Infrastucture
{
    public class FileTransactionRepository : ITransactionRepository
    {
        private readonly FileStorage storage;

        public FileTransactionRepository(FileStorage storage)
        {
            this.storage = storage;
        }

        public void Save(Transation transaction)
        {
            var db = storage.Load();
            var newTransation = new Transation(
                    db.NextId++,
                    transaction.AccountId,
                    transaction.Type,
                    transaction.Amount,
                    transaction.Date
                    );
            db.Transactions.Add(newTransation);

            storage.Save(db);
        }

        public IReadOnlyList<Transation> GetByAccountId(int id)
        {
            var db = storage.Load();

            var result = new List<PesonalWallet1.Domain.Entities.Transation>();

            foreach (var transaction in db.Transactions)
            {
                if (transaction.AccountId == id)
                    result.Add(transaction);
            }
            return result;
        }
    }
}
