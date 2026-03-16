using PesonalWallet1.Application;
using PesonalWallet1.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PesonalWallet1.Infrastucture
{
    public class FileAccountRepository : IAccountRepository
    {
        private readonly FileStorage storage;

        public FileAccountRepository(FileStorage storage)
        {
            this.storage = storage;
        }

        public IReadOnlyList<Account> GetAll()
        {
            var db = storage.Load();
            return db.Accounts;
        }

        public Account GetById(int id)
        {
            var db = storage.Load();

            foreach (var account in db.Accounts)
            {
                if (account.Id == id)
                {
                    return account;
                }
            }

            throw new Exception("Account not found");
        }

        public void Save(Account account)
        {
            var db = storage.Load();

            if(account.Id == 0)
            {
                var newAccount = new Account(
                    //int id, string name, AccountType type, Money balance
                    db.NextId++,
                    account.Name,
                    account.Type,
                    account.Balance
                    );
                db.Accounts.Add(newAccount);
            }
            else
            {
                bool found = false;
                for (int i = 0; i < db.Accounts.Count; i++)
                {
                    if (db.Accounts[i].Id == account.Id)
                    {
                        db.Accounts[i] = account;
                        found = true;
                        break;
                    }
                }
                if (!found)
                {
                    throw new Exception("Account not found");
                }
            }

            storage.Save(db);

        }
    }
}
