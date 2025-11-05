using System;
using System.Data;
using System.Windows.Forms;

namespace ElevatorProject.Utils
{
    public class Logger
    {
        private DataGridView grid;
        private DataTable table;

        public Logger(DataGridView dataGrid)
        {
            grid = dataGrid;
            table = new DataTable();
            table.Columns.Add("Time", typeof(string));
            table.Columns.Add("Message", typeof(string));
            grid.DataSource = table;

            // Auto-scroll to bottom when new logs are added
            table.RowChanged += (s, e) =>
            {
                if (grid.Rows.Count > 0)
                    grid.FirstDisplayedScrollingRowIndex = grid.Rows.Count - 1;
            };
        }

        public void Log(string message, string type = "INFO")
        {
            string timestamp = DateTime.Now.ToString("HH:mm:ss");

            // Invoke on UI thread if needed
            if (grid.InvokeRequired)
            {
                grid.Invoke(new Action(() =>
                {
                    table.Rows.Add(timestamp, $"[{type}] {message}");
                }));
            }
            else
            {
                table.Rows.Add(timestamp, $"[{type}] {message}");
            }
        }

        public void ShowLogs()
        {
            MessageBox.Show($"Total log entries: {table.Rows.Count}\n\nCheck the table below for detailed logs.",
                          "Elevator Logs",
                          MessageBoxButtons.OK,
                          MessageBoxIcon.Information);
        }
    }
}