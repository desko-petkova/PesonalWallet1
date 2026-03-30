//using Microsoft.Data.SqlClient;
//using PesonalWallet1.Application;
//using PesonalWallet1.Domain.Entities;
//using PesonalWallet1.Domain.Enums;
//using PesonalWallet1.Domain.ValueObjects;
//using System.Text;


//namespace PersonalWallet.Infrastructure.SQL
//{
//    public class SqlAccountRepository : IAccountRepository
//    {
//        private readonly WalletDbContext context;

//        public SqlAccountRepository(WalletDbContext context)
//        {
//            this.context = context;
//        }

//        public Account GetById(int id)
//        {
//            var cmd = new SqlCommand(
//                "SELECT Id, Name, Type, Balance FROM Accounts WHERE Id = @id",
//                context.Connection);

//            cmd.Parameters.AddWithValue("@id", id);

//            using var reader = cmd.ExecuteReader();

//            if (!reader.Read())
//            {
//                throw new Exception("Account not found");
//            }

//            return new Account(
//                reader.GetInt32(0),
//                reader.GetString(1),
//                (AccountType)reader.GetInt32(2),
//                new Money(reader.GetDecimal(3)));
//        }

//        public IReadOnlyList<Account> GetAll()
//        {
//            var cmd = new SqlCommand(
//                "SELECT Id, Name, Type, Balance FROM Accounts",
//                context.Connection);

//            using var reader = cmd.ExecuteReader();

//            List<Account> accounts = new List<Account>();

//            while (reader.Read())
//            {
//                var account = new Account(
//                    reader.GetInt32(0),
//                    reader.GetString(1),
//                    (AccountType)reader.GetInt32(2),
//                    new Money(reader.GetDecimal(3)));

//                accounts.Add(account);
//            }

//            return accounts;
//        }

//        public void Save(Account account)
//        {
//            if (account == null)
//            {
//                throw new ArgumentNullException(nameof(account));
//            }

//            if (account.Id == 0)
//            {
//                var insertCmd = new SqlCommand(
//                    @"INSERT INTO Accounts (Name, Type, Balance)
//                      VALUES (@name, @type, @balance)",
//                    context.Connection);

//                insertCmd.Parameters.AddWithValue("@name", account.Name);
//                insertCmd.Parameters.AddWithValue("@type", (int)account.Type);
//                insertCmd.Parameters.AddWithValue("@balance", account.Balance.Amount);

//                insertCmd.ExecuteNonQuery();
//            }
//            else
//            {
//                var updateCmd = new SqlCommand(
//                    @"UPDATE Accounts
//                      SET Name = @name,
//                          Type = @type,
//                          Balance = @balance
//                      WHERE Id = @id",
//                    context.Connection);

//                updateCmd.Parameters.AddWithValue("@id", account.Id);
//                updateCmd.Parameters.AddWithValue("@name", account.Name);
//                updateCmd.Parameters.AddWithValue("@type", (int)account.Type);
//                updateCmd.Parameters.AddWithValue("@balance", account.Balance.Amount);

//                int rowsAffected = updateCmd.ExecuteNonQuery();

//                if (rowsAffected == 0)
//                {
//                    throw new Exception("Account not found.");
//                }
//            }
//        }
//    }
//}
