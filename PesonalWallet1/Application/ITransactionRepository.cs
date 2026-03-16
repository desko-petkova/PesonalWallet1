using PesonalWallet1.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PesonalWallet1.Application
{
    public interface ITransactionRepository
    {
        IReadOnlyList<Transation> GetByAccountId(int id);
        void Save(Transation transaction);
    }
}
