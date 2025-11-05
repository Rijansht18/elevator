using System;
using System.Data;
using System.Drawing;
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
            InitializeDataTable();
            ConfigureGridAppearance();
        }

        private void InitializeDataTable()
        {
            table = new DataTable();
            table.Columns.Add("Time", typeof(string));
            table.Columns.Add("Message", typeof(string));
            grid.DataSource = table;
        }

        private void ConfigureGridAppearance()
        {
            // Clear any existing columns
            grid.Columns.Clear();

            // Set basic properties
            grid.BackgroundColor = Color.FromArgb(44, 62, 80);
            grid.BorderStyle = BorderStyle.None;
            grid.EnableHeadersVisualStyles = false;

            // Configure columns
            grid.AutoGenerateColumns = false;

            // Time column
            DataGridViewTextBoxColumn timeColumn = new DataGridViewTextBoxColumn();
            timeColumn.HeaderText = "Time";
            timeColumn.DataPropertyName = "Time";
            timeColumn.Width = 80;
            timeColumn.ReadOnly = true;
            grid.Columns.Add(timeColumn);

            // Message column
            DataGridViewTextBoxColumn messageColumn = new DataGridViewTextBoxColumn();
            messageColumn.HeaderText = "Message";
            messageColumn.DataPropertyName = "Message";
            messageColumn.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            messageColumn.ReadOnly = true;
            grid.Columns.Add(messageColumn);

            // Header style
            grid.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(52, 73, 94);
            grid.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            grid.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            grid.ColumnHeadersHeight = 30;

            // Row style
            grid.DefaultCellStyle.BackColor = Color.FromArgb(44, 62, 80);
            grid.DefaultCellStyle.ForeColor = Color.White;
            grid.DefaultCellStyle.Font = new Font("Segoe UI", 8.5F);
            grid.DefaultCellStyle.SelectionBackColor = Color.FromArgb(52, 152, 219);
            grid.DefaultCellStyle.SelectionForeColor = Color.White;

            // Grid lines
            grid.GridColor = Color.FromArgb(60, 60, 60);

            // Row height
            grid.RowTemplate.Height = 22;
        }

        public void Log(string message, string type = "INFO")
        {
            string timestamp = DateTime.Now.ToString("HH:mm:ss");

            if (grid.InvokeRequired)
            {
                grid.Invoke(new Action(() =>
                {
                    AddLogEntry(timestamp, message, type);
                }));
            }
            else
            {
                AddLogEntry(timestamp, message, type);
            }
        }

        private void AddLogEntry(string timestamp, string message, string type)
        {
            table.Rows.Add(timestamp, $"[{type}] {message}");

            // Auto-scroll to bottom
            if (grid.Rows.Count > 0)
            {
                grid.FirstDisplayedScrollingRowIndex = grid.Rows.Count - 1;
            }
        }

        public void ShowLogs()
        {
            string logInfo = $"Total Log Entries: {table.Rows.Count}\n\n" +
                           "Log Types:\n" +
                           "• SYSTEM - System initialization\n" +
                           "• STATE - State changes\n" +
                           "• DOOR - Door operations\n" +
                           "• MOVEMENT - Elevator movement\n" +
                           "• ARRIVAL - Floor arrivals\n" +
                           "• USER - User actions\n" +
                           "• EMERGENCY - Emergency events";

            MessageBox.Show(logInfo, "Elevator Logs Information",
                          MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}