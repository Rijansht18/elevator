using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace ElevatorProject.Utils
{
    public class Logger
    {
        private readonly DataGridView _grid;
        private DataTable _table;

        public Logger(DataGridView dataGrid)
        {
            _grid = dataGrid;
            InitializeDataTable();
            ConfigureGridAppearance();
        }

        private void InitializeDataTable()
        {
            _table = new DataTable();
            _table.Columns.Add("Time", typeof(string));
            _table.Columns.Add("Message", typeof(string));
            _grid.DataSource = _table;
        }

        private void ConfigureGridAppearance()
        {
            // Clear any existing columns
            _grid.Columns.Clear();

            // Set basic properties
            _grid.BackgroundColor = Color.FromArgb(44, 62, 80);
            _grid.BorderStyle = BorderStyle.None;
            _grid.EnableHeadersVisualStyles = false;

            // Configure columns
            _grid.AutoGenerateColumns = false;

            // Time column
            DataGridViewTextBoxColumn timeColumn = new DataGridViewTextBoxColumn
            {
                HeaderText = "Time",
                DataPropertyName = "Time",
                Width = 80,
                ReadOnly = true
            };
            _grid.Columns.Add(timeColumn);

            // Message column
            DataGridViewTextBoxColumn messageColumn = new DataGridViewTextBoxColumn
            {
                HeaderText = "Message",
                DataPropertyName = "Message",
                AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill,
                ReadOnly = true
            };
            _grid.Columns.Add(messageColumn);

            // Header style
            _grid.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(52, 73, 94);
            _grid.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            _grid.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            _grid.ColumnHeadersHeight = 30;

            // Row style
            _grid.DefaultCellStyle.BackColor = Color.FromArgb(44, 62, 80);
            _grid.DefaultCellStyle.ForeColor = Color.White;
            _grid.DefaultCellStyle.Font = new Font("Segoe UI", 8.5F);
            _grid.DefaultCellStyle.SelectionBackColor = Color.FromArgb(52, 152, 219);
            _grid.DefaultCellStyle.SelectionForeColor = Color.White;

            // Grid lines
            _grid.GridColor = Color.FromArgb(60, 60, 60);

            // Row height
            _grid.RowTemplate.Height = 22;
        }

        public void Log(string message, string type = "INFO")
        {
            string timestamp = DateTime.Now.ToString("HH:mm:ss");

            if (_grid.InvokeRequired)
            {
                _grid.Invoke(new Action(() =>
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
            _table.Rows.Add(timestamp, $"[{type}] {message}");

            // Auto-scroll to bottom
            if (_grid.Rows.Count > 0)
            {
                _grid.FirstDisplayedScrollingRowIndex = _grid.Rows.Count - 1;
            }
        }

        public void ClearLogs()
        {
            if (_grid.InvokeRequired)
            {
                _grid.Invoke(new Action(() =>
                {
                    _table.Rows.Clear();
                }));
            }
            else
            {
                _table.Rows.Clear();
            }
        }

        public void ShowLogs()
        {
            string logInfo = $"Total Log Entries: {_table.Rows.Count}\n\n" +
                           "Log Types:\n" +
                           "• SYSTEM - System initialization\n" +
                           "• STATE - State changes\n" +
                           "• DOOR - Door operations\n" +
                           "• MOVEMENT - Elevator movement\n" +
                           "• ARRIVAL - Floor arrivals\n" +
                           "• USER - User actions";

            MessageBox.Show(logInfo, "Elevator Logs Information",
                          MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}