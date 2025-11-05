using System;
using System.Data;
using System.Data.SQLite;
using System.IO;

namespace ElevatorProject.Utils
{
    public class Database
    {
        private string connectionString;
        private string dbPath;

        public Database()
        {
            // Database file location
            dbPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "ElevatorData.db");
            connectionString = $"Data Source={dbPath};Version=3;";

            // Create database if doesn't exist
            InitializeDatabase();
        }

        private void InitializeDatabase()
        {
            bool isNewDatabase = !File.Exists(dbPath);

            if (isNewDatabase)
            {
                SQLiteConnection.CreateFile(dbPath);
            }

            // Always create tables (they won't be created if they already exist)
            CreateTables();
        }

        private void CreateTables()
        {
            using (var connection = new SQLiteConnection(connectionString))
            {
                connection.Open();

                // Logs Table - Only essential table for elevator operations
                string createLogsTable = @"
                    CREATE TABLE IF NOT EXISTS Logs (
                        Id INTEGER PRIMARY KEY AUTOINCREMENT,
                        Timestamp TEXT NOT NULL,
                        Date TEXT NOT NULL,
                        Time TEXT NOT NULL,
                        Type TEXT NOT NULL,
                        Message TEXT NOT NULL,
                        FromFloor INTEGER,
                        ToFloor INTEGER,
                        State TEXT
                    )";

                using (var command = new SQLiteCommand(createLogsTable, connection))
                {
                    command.ExecuteNonQuery();
                }

                connection.Close();
            }
        }

        // ==================== INSERT METHODS ====================

        public void SaveLog(string type, string message, int? fromFloor = null, int? toFloor = null, string state = null)
        {
            try
            {
                using (var connection = new SQLiteConnection(connectionString))
                {
                    connection.Open();

                    string query = @"
                        INSERT INTO Logs (Timestamp, Date, Time, Type, Message, FromFloor, ToFloor, State)
                        VALUES (@timestamp, @date, @time, @type, @message, @fromFloor, @toFloor, @state)";

                    using (var command = new SQLiteCommand(query, connection))
                    {
                        DateTime now = DateTime.Now;
                        command.Parameters.AddWithValue("@timestamp", now.ToString("yyyy-MM-dd HH:mm:ss"));
                        command.Parameters.AddWithValue("@date", now.ToString("yyyy-MM-dd"));
                        command.Parameters.AddWithValue("@time", now.ToString("HH:mm:ss"));
                        command.Parameters.AddWithValue("@type", type);
                        command.Parameters.AddWithValue("@message", message);
                        command.Parameters.AddWithValue("@fromFloor", fromFloor.HasValue ? (object)fromFloor.Value : DBNull.Value);
                        command.Parameters.AddWithValue("@toFloor", toFloor.HasValue ? (object)toFloor.Value : DBNull.Value);
                        command.Parameters.AddWithValue("@state", state ?? (object)DBNull.Value);

                        command.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show($"Error saving log: {ex.Message}");
            }
        }

        // ==================== QUERY METHODS ====================

        public DataTable GetAllLogs()
        {
            DataTable dt = new DataTable();
            try
            {
                using (var connection = new SQLiteConnection(connectionString))
                {
                    connection.Open();
                    string query = "SELECT * FROM Logs ORDER BY Id DESC";

                    using (var adapter = new SQLiteDataAdapter(query, connection))
                    {
                        adapter.Fill(dt);
                    }
                }
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show($"Error getting logs: {ex.Message}");
            }
            return dt;
        }

        public DataTable GetLogsByDate(DateTime date)
        {
            DataTable dt = new DataTable();
            try
            {
                using (var connection = new SQLiteConnection(connectionString))
                {
                    connection.Open();
                    string query = "SELECT * FROM Logs WHERE Date = @date ORDER BY Id DESC";

                    using (var command = new SQLiteCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@date", date.ToString("yyyy-MM-dd"));

                        using (var adapter = new SQLiteDataAdapter(command))
                        {
                            adapter.Fill(dt);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show($"Error getting logs by date: {ex.Message}");
            }
            return dt;
        }

        public DataTable GetLogsByType(string type)
        {
            DataTable dt = new DataTable();
            try
            {
                using (var connection = new SQLiteConnection(connectionString))
                {
                    connection.Open();
                    string query = "SELECT * FROM Logs WHERE Type = @type ORDER BY Id DESC";

                    using (var command = new SQLiteCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@type", type);

                        using (var adapter = new SQLiteDataAdapter(command))
                        {
                            adapter.Fill(dt);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show($"Error getting logs by type: {ex.Message}");
            }
            return dt;
        }

        public DataTable GetTodaysLogs()
        {
            return GetLogsByDate(DateTime.Today);
        }

        // ==================== STATISTICS METHODS ====================

        public int GetTotalLogs()
        {
            try
            {
                using (var connection = new SQLiteConnection(connectionString))
                {
                    connection.Open();
                    string query = "SELECT COUNT(*) FROM Logs";

                    using (var command = new SQLiteCommand(query, connection))
                    {
                        return Convert.ToInt32(command.ExecuteScalar());
                    }
                }
            }
            catch
            {
                return 0;
            }
        }

        public string GetDatabasePath()
        {
            return dbPath;
        }

        public void ClearAllData()
        {
            try
            {
                using (var connection = new SQLiteConnection(connectionString))
                {
                    connection.Open();

                    using (var command = new SQLiteCommand("DELETE FROM Logs", connection))
                    {
                        command.ExecuteNonQuery();
                    }
                }

                System.Windows.Forms.MessageBox.Show("All data cleared successfully!", "Success");
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show($"Error clearing data: {ex.Message}");
            }
        }
    }
}