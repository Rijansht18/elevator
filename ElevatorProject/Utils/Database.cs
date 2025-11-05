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
                CreateTables();
            }
        }

        private void CreateTables()
        {
            using (var connection = new SQLiteConnection(connectionString))
            {
                connection.Open();

                // Logs Table
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

                // Trips Table
                string createTripsTable = @"
                    CREATE TABLE IF NOT EXISTS Trips (
                        TripId INTEGER PRIMARY KEY AUTOINCREMENT,
                        StartFloor INTEGER NOT NULL,
                        EndFloor INTEGER NOT NULL,
                        StartTime TEXT NOT NULL,
                        EndTime TEXT,
                        Duration INTEGER,
                        Status TEXT DEFAULT 'Completed'
                    )";

                // Emergency Events Table
                string createEmergencyTable = @"
                    CREATE TABLE IF NOT EXISTS EmergencyEvents (
                        EventId INTEGER PRIMARY KEY AUTOINCREMENT,
                        Timestamp TEXT NOT NULL,
                        Floor INTEGER,
                        Message TEXT,
                        Resolved TEXT DEFAULT 'No'
                    )";

                using (var command = new SQLiteCommand(connection))
                {
                    command.CommandText = createLogsTable;
                    command.ExecuteNonQuery();

                    command.CommandText = createTripsTable;
                    command.ExecuteNonQuery();

                    command.CommandText = createEmergencyTable;
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

        public int StartTrip(int startFloor, int endFloor)
        {
            try
            {
                using (var connection = new SQLiteConnection(connectionString))
                {
                    connection.Open();

                    string query = @"
                        INSERT INTO Trips (StartFloor, EndFloor, StartTime, Status)
                        VALUES (@startFloor, @endFloor, @startTime, 'In Progress');
                        SELECT last_insert_rowid();";

                    using (var command = new SQLiteCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@startFloor", startFloor);
                        command.Parameters.AddWithValue("@endFloor", endFloor);
                        command.Parameters.AddWithValue("@startTime", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));

                        return Convert.ToInt32(command.ExecuteScalar());
                    }
                }
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show($"Error starting trip: {ex.Message}");
                return -1;
            }
        }

        public void CompleteTrip(int tripId)
        {
            try
            {
                using (var connection = new SQLiteConnection(connectionString))
                {
                    connection.Open();

                    string getStartQuery = "SELECT StartTime FROM Trips WHERE TripId = @tripId";
                    DateTime startTime;

                    using (var cmd = new SQLiteCommand(getStartQuery, connection))
                    {
                        cmd.Parameters.AddWithValue("@tripId", tripId);
                        var result = cmd.ExecuteScalar();
                        if (result != null)
                        {
                            startTime = DateTime.Parse(result.ToString());
                        }
                        else
                        {
                            return;
                        }
                    }

                    DateTime endTime = DateTime.Now;
                    int duration = (int)(endTime - startTime).TotalSeconds;

                    string query = @"
                        UPDATE Trips 
                        SET EndTime = @endTime, Duration = @duration, Status = 'Completed'
                        WHERE TripId = @tripId";

                    using (var command = new SQLiteCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@endTime", endTime.ToString("yyyy-MM-dd HH:mm:ss"));
                        command.Parameters.AddWithValue("@duration", duration);
                        command.Parameters.AddWithValue("@tripId", tripId);

                        command.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show($"Error completing trip: {ex.Message}");
            }
        }

        public void SaveEmergency(int floor, string message)
        {
            try
            {
                using (var connection = new SQLiteConnection(connectionString))
                {
                    connection.Open();

                    string query = @"
                        INSERT INTO EmergencyEvents (Timestamp, Floor, Message)
                        VALUES (@timestamp, @floor, @message)";

                    using (var command = new SQLiteCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@timestamp", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                        command.Parameters.AddWithValue("@floor", floor);
                        command.Parameters.AddWithValue("@message", message);

                        command.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show($"Error saving emergency: {ex.Message}");
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

        public DataTable GetAllTrips()
        {
            DataTable dt = new DataTable();
            try
            {
                using (var connection = new SQLiteConnection(connectionString))
                {
                    connection.Open();
                    string query = "SELECT * FROM Trips ORDER BY TripId DESC";

                    using (var adapter = new SQLiteDataAdapter(query, connection))
                    {
                        adapter.Fill(dt);
                    }
                }
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show($"Error getting trips: {ex.Message}");
            }
            return dt;
        }

        public DataTable GetAllEmergencies()
        {
            DataTable dt = new DataTable();
            try
            {
                using (var connection = new SQLiteConnection(connectionString))
                {
                    connection.Open();
                    string query = "SELECT * FROM EmergencyEvents ORDER BY EventId DESC";

                    using (var adapter = new SQLiteDataAdapter(query, connection))
                    {
                        adapter.Fill(dt);
                    }
                }
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show($"Error getting emergencies: {ex.Message}");
            }
            return dt;
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

        public int GetTotalTrips()
        {
            try
            {
                using (var connection = new SQLiteConnection(connectionString))
                {
                    connection.Open();
                    string query = "SELECT COUNT(*) FROM Trips WHERE Status = 'Completed'";

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

        public int GetEmergencyCount()
        {
            try
            {
                using (var connection = new SQLiteConnection(connectionString))
                {
                    connection.Open();
                    string query = "SELECT COUNT(*) FROM EmergencyEvents";

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

                    using (var command = new SQLiteCommand(connection))
                    {
                        command.CommandText = "DELETE FROM Logs";
                        command.ExecuteNonQuery();

                        command.CommandText = "DELETE FROM Trips";
                        command.ExecuteNonQuery();

                        command.CommandText = "DELETE FROM EmergencyEvents";
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