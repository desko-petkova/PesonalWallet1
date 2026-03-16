using PesonalWallet1.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PesonalWallet1.Application
{
    public interface IAccountRepository
    {
        IReadOnlyList<Account> GetAll();
        Account GetById(int id);
        void Save(Account account);
    }
}
