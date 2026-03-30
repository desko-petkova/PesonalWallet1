//using Microsoft.Data.SqlClient;

//namespace PersonalWallet.Infrastructure.SQL
//{
//    public class WalletDbContext
//    {
//        private readonly SqlConnection connection;

//        public SqlConnection Connection => connection;

//        public WalletDbContext(string connectionString)
//        {
//            connection = new SqlConnection(connectionString);
//            connection.Open();
//        }

//        public void Dispose()
//        {
//            connection.Dispose();
//        }
//    }
//}
