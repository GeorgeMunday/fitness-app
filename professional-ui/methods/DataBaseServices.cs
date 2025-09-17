using System;
using System.Collections.Generic;
using System.Data.SQLite;

namespace professional_ui.methods
{
    public class User
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }

    public class DataBaseServices
    {
        private readonly string connectionString;

        public DataBaseServices()
        {
            string dbPath = @"C:\Users\geoge\OneDrive\Desktop\dbs\new.db";
            connectionString = $"Data Source={dbPath};Version=3;";
        }

        public SQLiteConnection GetConnection()
        {
            return new SQLiteConnection(connectionString);
        }

        public bool loginUser(string username, string password)
        {
            using (var conn = GetConnection())
            {
                conn.Open();
                username = username.Trim();
                password = password.Trim();
                string query = "SELECT COUNT(1) FROM users WHERE username=@username AND password=@password";
                using (var cmd = new SQLiteCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@username", username);
                    cmd.Parameters.AddWithValue("@password", password);
                    int count = Convert.ToInt32(cmd.ExecuteScalar());
                    if (count == 1)
                    {
                        return true;
                    }
                    else
                    {
                        System.Windows.MessageBox.Show("Invalid username or password.");
                        return false;
                    }
                }
            }
        }

        public List<User> getDataByUsername(string username)
        {
            var users = new List<User>();

            using (var conn = GetConnection())
            {
                conn.Open();
                string query = "SELECT username, password, firstname, lastname FROM users WHERE username=@username";
                using (var cmd = new SQLiteCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@username", username.Trim());
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            users.Add(new User
                            {
                                Username = reader["username"].ToString(),
                                Password = reader["password"].ToString(),
                                FirstName = reader["firstname"].ToString(),
                                LastName = reader["lastname"].ToString()
                            });
                        }
                    }
                }
            }

            return users;
        }
    }
}
