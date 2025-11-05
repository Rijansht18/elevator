using System;
using System.Windows.Forms;
using ElevatorProject.Models;
using ElevatorProject.Utils;

namespace ElevatorProject
{
    public partial class MainForm : Form
    {
        private ElevatorController controller;
        private Logger logger;

        public MainForm()
        {
            InitializeComponent();
            InitializeApplication();
        }

        private void InitializeApplication()
        {
            try
            {
                // Initialize logger first
                logger = new Logger(dgvLogs);

                // Initialize elevator controller
                controller = new ElevatorController(
                    pnlElevator,
                    lblDisplay,
                    logger,
                    pnlFloor0Doors,
                    pnlFloor1Doors
                );

                // Connect all button events
                ConnectButtonEvents();

                logger.Log("Application initialized successfully", "SYSTEM");
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
            btnFloor0.Click += (s, e) => SafeAction(() => controller.GoToFloor(0));
            btnFloor1.Click += (s, e) => SafeAction(() => controller.GoToFloor(1));

            // Call buttons on floors
            btnCall0.Click += (s, e) => SafeAction(() => controller.GoToFloor(0));
            btnCall1.Click += (s, e) => SafeAction(() => controller.GoToFloor(1));

            // Door control buttons
            btnOpenDoors.Click += (s, e) => SafeAction(() => controller.ManualOpenDoors());
            btnCloseDoors.Click += (s, e) => SafeAction(() => controller.ManualCloseDoors());

            // Other controls
            btnShowLog.Click += (s, e) => SafeAction(() => logger.ShowLogs());
            btnEmergency.Click += (s, e) => SafeAction(() => controller.EmergencyStop());
        }

        private void SafeAction(Action action)
        {
            try
            {
                action?.Invoke();
            }
            catch (Exception ex)
            {
                logger.Log($"Error in action: {ex.Message}", "ERROR");
            }
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            logger.Log("Elevator Control System Started", "SYSTEM");
            logger.Log("Ready for operation - Floor 0", "STATE");
        }

        // Empty event handlers required by designer
        private void btnFloor1_Click(object sender, EventArgs e) { }
        private void btnEmergency_Click(object sender, EventArgs e) { }
        private void lblDisplay_Click(object sender, EventArgs e) { }
        private void grpControls_Enter(object sender, EventArgs e) { }
        private void pnlShaft_Paint(object sender, PaintEventArgs e) { }
        private void dgvLogs_CellContentClick(object sender, DataGridViewCellEventArgs e) { }
        private void btnFloor0_Click(object sender, EventArgs e) { }
        private void btnOpenDoors_Click(object sender, EventArgs e) { }
        private void floor0DoorRight_Paint(object sender, PaintEventArgs e) { }
    }
}