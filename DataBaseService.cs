using System.Data.SQLite;

namespace professional_ui
{
    public class DatabaseService
    {
        private readonly string connectionString;

        public DatabaseService(string dbPath)
        {
            connectionString = $"Data Source={dbPath};Version=3;";
        }

        public bool TestConnection()
        {
            using var conn = new SQLiteConnection(connectionString);
            conn.Open();
            return conn.State == System.Data.ConnectionState.Open;
        }
    }
}
