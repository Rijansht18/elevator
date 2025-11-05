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
            InitializeElevator();
        }

        private void InitializeElevator()
        {
            logger = new Logger(dgvLogs);
            controller = new ElevatorController(pnlElevator, lblDisplay, logger, pnlFloor0Doors, pnlFloor1Doors);

            // Connect buttons
            btnFloor0.Click += (s, e) => controller.GoToFloor(0);
            btnFloor1.Click += (s, e) => controller.GoToFloor(1);
            btnCall0.Click += (s, e) => controller.GoToFloor(0);

            btnCall1.Click += (s, e) => controller.GoToFloor(1);
            btnShowLog.Click += (s, e) => logger.ShowLogs();
            btnEmergency.Click += (s, e) => controller.EmergencyStop();

            
        
        
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            logger.Log("Elevator system started - Larger UI with enhanced controls");
        }

        private void btnFloor1_Click(object sender, EventArgs e)
        {

        }

        private void btnEmergency_Click(object sender, EventArgs e)
        {

        }

        private void lblDisplay_Click(object sender, EventArgs e)
        {

        }

        private void grpControls_Enter(object sender, EventArgs e)
        {

        }

        private void pnlShaft_Paint(object sender, PaintEventArgs e)
        {

        }

        private void dgvLogs_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnFloor0_Click(object sender, EventArgs e)
        {

        }

        private void btnOpenDoors_Click(object sender, EventArgs e)
        {

        }

        private void floor0DoorRight_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}