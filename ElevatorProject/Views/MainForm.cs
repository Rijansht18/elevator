using System;
using System.Windows.Forms;
using ElevatorProject.Models;
using ElevatorProject.Utils;

namespace ElevatorProject
{
    public partial class MainForm : Form
    {
        private ElevatorController _controller;
        private Logger _logger;
        private Database _database;

        public MainForm()
        {
            InitializeComponent();
            InitializeApplication();
        }

        private void InitializeApplication()
        {
            try
            {
                // Initialize database
                _database = new Database();

                // Initialize logger
                _logger = new Logger(dgvLogs);

                // Initialize elevator controller
                _controller = new ElevatorController(
                    pnlElevator,
                    lblDisplay,
                    _logger,
                    pnlFloor0Doors,
                    pnlFloor1Doors
                );

                // Connect all button events
                ConnectButtonEvents();

                _logger.Log("Application initialized successfully", "SYSTEM");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Failed to initialize application: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ConnectButtonEvents()
        {
            // Floor buttons inside elevator
            btnFloor0.Click += (s, e) => SafeAction(() => _controller.GoToFloor(0));
            btnFloor1.Click += (s, e) => SafeAction(() => _controller.GoToFloor(1));

            // Call buttons on floors
            btnCall0.Click += (s, e) => SafeAction(() => _controller.GoToFloor(0));
            btnCall1.Click += (s, e) => SafeAction(() => _controller.GoToFloor(1));

            // Door control buttons
            btnOpenDoors.Click += (s, e) => SafeAction(() => _controller.ManualOpenDoors());
            btnCloseDoors.Click += (s, e) => SafeAction(() => _controller.ManualCloseDoors());

            // Log buttons
            btnShowLog.Click += (s, e) => SafeAction(() => _logger.ShowLogs());
            btnClearLogs.Click += (s, e) => SafeAction(() => ClearLogs());
        }

        private void ClearLogs()
        {
            try
            {
                var result = MessageBox.Show(
                    "Are you sure you want to clear all logs from UI and database?",
                    "Clear Logs",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question
                );

                if (result == DialogResult.Yes)
                {
                    // Clear from database
                    _database.ClearAllData();

                    // Clear from UI
                    _logger.ClearLogs();

                    _logger.Log("All logs cleared successfully", "SYSTEM");
                }
            }
            catch (Exception ex)
            {
                _logger.Log($"Error clearing logs: {ex.Message}", "ERROR");
                MessageBox.Show($"Failed to clear logs: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void SafeAction(Action action)
        {
            try
            {
                action?.Invoke();
            }
            catch (Exception ex)
            {
                _logger.Log($"Error in action: {ex.Message}", "ERROR");
            }
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            _logger.Log("Elevator Control System Started", "SYSTEM");
            _logger.Log("Ready for operation - Floor 0", "STATE");
        }

        // Empty event handlers with proper naming
        private void BtnFloor1_Click(object sender, EventArgs e) { }
        private void LblDisplay_Click(object sender, EventArgs e) { }
        private void GrpControls_Enter(object sender, EventArgs e) { }
        private void PnlShaft_Paint(object sender, PaintEventArgs e) { }
        private void DgvLogs_CellContentClick(object sender, DataGridViewCellEventArgs e) { }
        private void BtnFloor0_Click(object sender, EventArgs e) { }
        private void BtnOpenDoors_Click(object sender, EventArgs e) { }
        private void Floor0DoorRight_Paint(object sender, PaintEventArgs e) { }
    }
}