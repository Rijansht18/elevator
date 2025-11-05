using System;
using System.Drawing;
using System.Windows.Forms;
using ElevatorProject.Models.States;
using ElevatorProject.Utils;
using Timer = System.Windows.Forms.Timer;

namespace ElevatorProject.Models
{
    public class ElevatorController : IDisposable
    {
        private readonly Elevator elevator;
        private readonly Panel elevatorPanel;
        private readonly Label displayLabel;
        private readonly Timer moveTimer;
        private readonly Logger logger;

        private ElevatorState currentState;
        private int? queuedFloorRequest;

        // Movement
        private int targetFloor;
        private int currentY;
        private int targetY;
        private readonly int floor0Y = 380;
        private readonly int floor1Y = 40;
        private const int MOVE_SPEED = 3;

        // Doors
        private Panel elevatorDoorLeft;
        private Panel elevatorDoorRight;
        private Panel floor0DoorLeft;
        private Panel floor0DoorRight;
        private Panel floor1DoorLeft;
        private Panel floor1DoorRight;

        private readonly Timer doorTimer;
        private readonly Timer autoCloseTimer;
        private int doorOpenWidth;
        private int floor0DoorOpenWidth;
        private int floor1DoorOpenWidth;
        private const int MAX_DOOR_OPEN = 120;
        private const int DOOR_SPEED = 8;
        private bool isOpeningDoors;
        private bool isClosingDoors;
        private bool doorsOpen;

        private const int DOOR_WIDTH = 120;
        private const int DOOR_HEIGHT = 280;

        public Logger Logger => logger;
        public int CurrentFloor => elevator.CurrentFloor;

        public ElevatorController(Panel panel, Label display, Logger log, Panel floor0DoorsContainer, Panel floor1DoorsContainer)
        {
            elevator = new Elevator();
            elevatorPanel = panel;
            displayLabel = display;
            logger = log;

            currentState = new IdleState(this);

            InitializeDoors(floor0DoorsContainer, floor1DoorsContainer);

            // Timers
            moveTimer = new Timer { Interval = 20 };
            moveTimer.Tick += MoveElevatorTick;

            doorTimer = new Timer { Interval = 16 };
            doorTimer.Tick += DoorAnimationTick;

            autoCloseTimer = new Timer { Interval = 3000 };
            autoCloseTimer.Tick += AutoCloseDoors;

            // Events
            elevator.FloorChanged += OnFloorChanged;
            elevator.MovementCompleted += OnMovementCompleted;

            // Initial position
            currentY = floor0Y;
            elevatorPanel.Top = currentY;

            ResetAllDoors();

            logger.Log("Elevator initialized at Floor 0", "SYSTEM");
            UpdateDisplay($"FLOOR {elevator.CurrentFloor}");
        }

        private void InitializeDoors(Panel floor0DoorsContainer, Panel floor1DoorsContainer)
        {
            CreateElevatorDoors();

            if (floor0DoorsContainer != null)
            {
                foreach (Control control in floor0DoorsContainer.Controls)
                {
                    if (control.Name == "floor0DoorLeft") floor0DoorLeft = control as Panel;
                    if (control.Name == "floor0DoorRight") floor0DoorRight = control as Panel;
                }
            }

            if (floor1DoorsContainer != null)
            {
                foreach (Control control in floor1DoorsContainer.Controls)
                {
                    if (control.Name == "floor1DoorLeft") floor1DoorLeft = control as Panel;
                    if (control.Name == "floor1DoorRight") floor1DoorRight = control as Panel;
                }
            }
        }

        private void CreateElevatorDoors()
        {
            elevatorPanel.Controls.Clear();

            elevatorDoorLeft = new Panel();
            elevatorDoorLeft.Name = "elevatorDoorLeft";
            elevatorDoorLeft.BackColor = Color.FromArgb(149, 165, 166);
            elevatorDoorLeft.Size = new Size(DOOR_WIDTH, DOOR_HEIGHT);
            elevatorDoorLeft.Location = new Point(0, 0);

            elevatorDoorRight = new Panel();
            elevatorDoorRight.Name = "elevatorDoorRight";
            elevatorDoorRight.BackColor = Color.FromArgb(149, 165, 166);
            elevatorDoorRight.Size = new Size(DOOR_WIDTH, DOOR_HEIGHT);
            elevatorDoorRight.Location = new Point(DOOR_WIDTH, 0);

            elevatorPanel.Controls.Add(elevatorDoorLeft);
            elevatorPanel.Controls.Add(elevatorDoorRight);
        }

        // Public methods
        public void GoToFloor(int floor)
        {
            logger.Log($"User requested floor {floor}", "USER");
            currentState.MoveToFloor(floor);
        }

        public void ManualOpenDoors()
        {
            logger.Log("User manually opening doors", "USER");
            currentState.OpenDoors();
        }

        public void ManualCloseDoors()
        {
            logger.Log("User manually closing doors", "USER");
            currentState.CloseDoors();
        }

        public void EmergencyStop()
        {
            logger.Log("User triggered emergency stop", "USER");
            currentState.EmergencyStop();
        }

        // Internal methods
        public void SetState(ElevatorState newState)
        {
            currentState = newState;
            logger.Log($"State: {newState.GetStateName()}", "STATE");
        }

        public void QueueFloorRequest(int floor)
        {
            queuedFloorRequest = floor;
            logger.Log($"Queued floor {floor}", "QUEUE");
        }

        public void MoveToFloorInternal(int floor)
        {
            if (elevator.IsMoving) return;

            logger.Log($"Moving to floor {floor}", "MOVEMENT");
            targetFloor = floor;

            if (elevator.CurrentFloor == targetFloor)
            {
                OpenDoorsInternal();
                return;
            }

            if (doorsOpen)
            {
                QueueFloorRequest(floor);
                CloseDoorsInternal();
                return;
            }

            SetState(new MovingState(this));
            StartMovement();
        }

        public void OpenDoorsInternal()
        {
            if (isOpeningDoors || doorsOpen) return;

            logger.Log($"Opening doors at floor {elevator.CurrentFloor}", "DOOR");
            SetState(new DoorOpenState(this));

            isOpeningDoors = true;
            isClosingDoors = false;
            autoCloseTimer.Stop();
            doorTimer.Start();
        }

        public void CloseDoorsInternal()
        {
            if (isClosingDoors || !doorsOpen) return;

            logger.Log($"Closing doors at floor {elevator.CurrentFloor}", "DOOR");
            SetState(new ClosingDoorsState(this));

            isClosingDoors = true;
            isOpeningDoors = false;
            autoCloseTimer.Stop();
            doorTimer.Start();
        }

        public void ArriveAtFloorInternal(int floor)
        {
            logger.Log($"Arrived at floor {floor}", "ARRIVAL");
            OpenDoorsInternal();
        }

        public void EmergencyStopInternal()
        {
            SetState(new EmergencyState(this));

            moveTimer.Stop();
            doorTimer.Stop();
            autoCloseTimer.Stop();

            isOpeningDoors = false;
            isClosingDoors = false;
            doorsOpen = false;

            logger.Log("EMERGENCY STOP ACTIVATED", "EMERGENCY");
            UpdateDisplay("EMERGENCY", Color.Red);
        }

        private void StartMovement()
        {
            autoCloseTimer.Stop();
            targetY = (targetFloor == 0) ? floor0Y : floor1Y;

            UpdateDisplay($"MOVING TO {targetFloor}", Color.Yellow);
            elevator.MoveToFloor(targetFloor);
            moveTimer.Start();
        }

        private void MoveElevatorTick(object sender, EventArgs e)
        {
            int direction = targetY < currentY ? -1 : 1;
            currentY += direction * MOVE_SPEED;

            bool reachedTarget = (direction == -1 && currentY <= targetY) ||
                               (direction == 1 && currentY >= targetY);

            if (reachedTarget)
            {
                currentY = targetY;
                moveTimer.Stop();
                elevatorPanel.Top = currentY;
                elevator.OnArrivedAtFloor(targetFloor);
            }
            else
            {
                elevatorPanel.Top = currentY;
            }
        }

        private void DoorAnimationTick(object sender, EventArgs e)
        {
            if (isOpeningDoors)
            {
                if (doorOpenWidth < MAX_DOOR_OPEN)
                {
                    doorOpenWidth += DOOR_SPEED;
                }
                else
                {
                    doorsOpen = true;
                    isOpeningDoors = false;
                    doorTimer.Stop();
                    logger.Log("Doors fully opened", "DOOR");
                    UpdateDisplay($"FLOOR {elevator.CurrentFloor} - OPEN", Color.Lime);
                    autoCloseTimer.Start();
                }
            }
            else if (isClosingDoors)
            {
                if (doorOpenWidth > 0)
                {
                    doorOpenWidth -= DOOR_SPEED;
                }
                else
                {
                    doorsOpen = false;
                    isClosingDoors = false;
                    doorTimer.Stop();
                    logger.Log("Doors fully closed", "DOOR");
                    UpdateDisplay($"FLOOR {elevator.CurrentFloor}");

                    ProcessQueuedRequest();
                }
            }

            UpdateAllDoorPositions();
        }

        private void UpdateAllDoorPositions()
        {
            // Elevator doors
            if (elevatorDoorLeft != null) elevatorDoorLeft.Left = -doorOpenWidth;
            if (elevatorDoorRight != null) elevatorDoorRight.Left = DOOR_WIDTH + doorOpenWidth;

            // Floor doors
            if (elevator.CurrentFloor == 0)
            {
                if (floor0DoorLeft != null) floor0DoorLeft.Left = -doorOpenWidth;
                if (floor0DoorRight != null) floor0DoorRight.Left = DOOR_WIDTH + doorOpenWidth;
            }
            else if (elevator.CurrentFloor == 1)
            {
                if (floor1DoorLeft != null) floor1DoorLeft.Left = -doorOpenWidth;
                if (floor1DoorRight != null) floor1DoorRight.Left = DOOR_WIDTH + doorOpenWidth;
            }
        }

        private void ResetAllDoors()
        {
            doorOpenWidth = 0;
            floor0DoorOpenWidth = 0;
            floor1DoorOpenWidth = 0;
            UpdateAllDoorPositions();
        }

        private void AutoCloseDoors(object sender, EventArgs e)
        {
            autoCloseTimer.Stop();
            if (doorsOpen && !isClosingDoors)
            {
                logger.Log("Auto-closing doors", "DOOR");
                CloseDoorsInternal();
            }
        }

        private void ProcessQueuedRequest()
        {
            if (queuedFloorRequest.HasValue)
            {
                int floor = queuedFloorRequest.Value;
                queuedFloorRequest = null;
                SetState(new MovingState(this));
                MoveToFloorInternal(floor);
            }
            else
            {
                SetState(new IdleState(this));
            }
        }

        private void OnFloorChanged(object sender, int floor)
        {
            UpdateDisplay($"FLOOR {floor}");
            logger.Log($"Now at floor {floor}", "ARRIVAL");
        }

        private void OnMovementCompleted(object sender, EventArgs e)
        {
            SetState(new ArrivedState(this));
            currentState.ArriveAtFloor(elevator.CurrentFloor);
        }

        private void UpdateDisplay(string text, Color? color = null)
        {
            if (displayLabel.InvokeRequired)
            {
                displayLabel.Invoke(new Action(() =>
                {
                    displayLabel.Text = text;
                    displayLabel.ForeColor = color ?? Color.Lime;
                }));
            }
            else
            {
                displayLabel.Text = text;
                displayLabel.ForeColor = color ?? Color.Lime;
            }
        }

        public void Dispose()
        {
            moveTimer?.Dispose();
            doorTimer?.Dispose();
            autoCloseTimer?.Dispose();
        }
    }
}