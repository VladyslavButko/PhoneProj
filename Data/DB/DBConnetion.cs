using MySql.Data.MySqlClient;
namespace PhoneMysql.Data.DB
{
    public class DBConnection
    {
        private static DBConnection instance;
        private MySqlConnection connection;
        private string connectionString;

        private DBConnection(string server, string database, string userId, string password)
        {
            InitializeConnection(server, database, userId, password);
        }

        public static DBConnection GetInstance(string server, string database, string userId, string password)
        {
            if (instance == null)
            {
                instance = new DBConnection(server, database, userId, password);
            }
            return instance;
        }

        private void InitializeConnection(string server, string database, string userId, string password)
        {
            try
            {
                connectionString = $"Server={server};Database={database};Uid={userId};Pwd={password};";
                connection = new MySqlConnection(connectionString);
            }
            catch (Exception ex)
            {
                Console.WriteLine("ERROR initializing connection: " + ex.Message);
            }
        }

        public bool OpenConnection()
        {
            try
            {
                connection.Open();
                return true;
            }
            catch (MySqlException ex)
            {
                Console.WriteLine("ERROR when try to open connection: " + ex.Message);
                return false;
            }
        }

        public bool CloseConnection()
        {
            try
            {
                connection.Close();
                return true;
            }
            catch (MySqlException ex)
            {
                Console.WriteLine("ERROR when try to close connection: " + ex.Message);
                return false;
            }
        }

        public MySqlConnection GetConnection()
        {
            return connection;
        }
    }
}
