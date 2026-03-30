//using Microsoft.Data.SqlClient;
//using PesonalWallet1.Application;
//using PesonalWallet1.Domain.Entities;
//using PesonalWallet1.Domain.Enums;
//using PesonalWallet1.Domain.ValueObjects;

//namespace PersonalWallet.Infrastructure.SQL
//{
//    public class SqlTransactionRepository : ITransactionRepository
//    {
//        private readonly WalletDbContext context;

//        public SqlTransactionRepository(WalletDbContext context)
//        {
//            this.context = context;
//        }

//        public void Save(Transaction transaction)
//        {
//            if (transaction == null)
//            {
//                throw new ArgumentNullException(nameof(transaction));
//            }

//            var cmd = new SqlCommand(
//                @"INSERT INTO Transactions (AccountId, Type, Amount, Date)
//                  VALUES (@accountId, @type, @amount, @date)",
//                context.Connection);

//            cmd.Parameters.AddWithValue("@accountId", transaction.AccountId);
//            cmd.Parameters.AddWithValue("@type", (int)transaction.Type);
//            cmd.Parameters.AddWithValue("@amount", transaction.Amount.Amount);
//            cmd.Parameters.AddWithValue("@date", transaction.Date);

//            cmd.ExecuteNonQuery();
//        }

//        public IReadOnlyList<Transaction> GetByAccount(int accountId)
//        {
//            var cmd = new SqlCommand(
//                @"SELECT Id, AccountId, Type, Amount, Date
//                  FROM Transactions
//                  WHERE AccountId = @accountId
//                  ORDER BY Date ASC",
//                context.Connection);

//            cmd.Parameters.AddWithValue("@accountId", accountId);

//            using var reader = cmd.ExecuteReader();

//            List<Transaction> transactions = new List<Transaction>();

//            while (reader.Read())
//            {
//                var transaction = new Transaction(
//                    reader.GetInt32(0),
//                    reader.GetInt32(1),
//                    (TransactionType)reader.GetInt32(2),
//                    new Money(reader.GetDecimal(3)),
//                    reader.GetDateTime(4));

//                transactions.Add(transaction);
//            }

//            return transactions;
//        }
//    }
//}
