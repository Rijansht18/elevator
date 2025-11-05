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
        private readonly Elevator _elevator;
        private readonly Panel _elevatorPanel;
        private readonly Label _displayLabel;
        private readonly Timer _moveTimer;
        private readonly Logger _logger;

        private ElevatorState _currentState;
        private int? _queuedFloorRequest;

        // Movement - remove readonly from fields that change
        private int _targetFloor;
        private int _currentY;
        private int _targetY; // Removed readonly
        private readonly int _floor0Y = 380;
        private readonly int _floor1Y = 40;
        private const int MOVE_SPEED = 20;

        // Doors - remove readonly from fields that change
        private Panel _elevatorDoorLeft;
        private Panel _elevatorDoorRight;
        private Panel _floor0DoorLeft;
        private Panel _floor0DoorRight;
        private Panel _floor1DoorLeft;
        private Panel _floor1DoorRight;

        private readonly Timer _doorTimer;
        private readonly Timer _autoCloseTimer;
        private int _doorOpenWidth;
        private int _floor0DoorOpenWidth;
        private int _floor1DoorOpenWidth;
        private const int MAX_DOOR_OPEN = 120;
        private const int DOOR_SPEED = 8;
        private bool _isOpeningDoors;
        private bool _isClosingDoors;
        private bool _doorsOpen;

        private const int DOOR_WIDTH = 120;
        private const int DOOR_HEIGHT = 280;

        public Logger Logger => _logger;
        public int CurrentFloor => _elevator.CurrentFloor;

        public ElevatorController(Panel panel, Label display, Logger log, Panel floor0DoorsContainer, Panel floor1DoorsContainer)
        {
            _elevator = new Elevator();
            _elevatorPanel = panel;
            _displayLabel = display;
            _logger = log;

            _currentState = new IdleState(this);

            InitializeDoors(floor0DoorsContainer, floor1DoorsContainer);

            // Timers with object initialization
            _moveTimer = new Timer { Interval = 20 };
            _moveTimer.Tick += MoveElevatorTick;

            _doorTimer = new Timer { Interval = 16 };
            _doorTimer.Tick += DoorAnimationTick;

            _autoCloseTimer = new Timer { Interval = 3000 };
            _autoCloseTimer.Tick += AutoCloseDoors;

            // Events
            _elevator.FloorChanged += OnFloorChanged;
            _elevator.MovementCompleted += OnMovementCompleted;

            // Initial position
            _currentY = _floor0Y;
            _elevatorPanel.Top = _currentY;

            ResetAllDoors();

            _logger.Log("Elevator initialized at Floor 0", "SYSTEM");
            UpdateDisplay($"FLOOR {_elevator.CurrentFloor}");
        }

        private void InitializeDoors(Panel floor0DoorsContainer, Panel floor1DoorsContainer)
        {
            CreateElevatorDoors();

            if (floor0DoorsContainer != null)
            {
                foreach (Control control in floor0DoorsContainer.Controls)
                {
                    if (control.Name == "floor0DoorLeft") _floor0DoorLeft = control as Panel;
                    if (control.Name == "floor0DoorRight") _floor0DoorRight = control as Panel;
                }
            }

            if (floor1DoorsContainer != null)
            {
                foreach (Control control in floor1DoorsContainer.Controls)
                {
                    if (control.Name == "floor1DoorLeft") _floor1DoorLeft = control as Panel;
                    if (control.Name == "floor1DoorRight") _floor1DoorRight = control as Panel;
                }
            }
        }

        private void CreateElevatorDoors()
        {
            _elevatorPanel.Controls.Clear();

            _elevatorDoorLeft = new Panel
            {
                Name = "elevatorDoorLeft",
                BackColor = Color.FromArgb(149, 165, 166),
                Size = new Size(DOOR_WIDTH, DOOR_HEIGHT),
                Location = new Point(0, 0)
            };

            _elevatorDoorRight = new Panel
            {
                Name = "elevatorDoorRight",
                BackColor = Color.FromArgb(149, 165, 166),
                Size = new Size(DOOR_WIDTH, DOOR_HEIGHT),
                Location = new Point(DOOR_WIDTH, 0)
            };

            _elevatorPanel.Controls.Add(_elevatorDoorLeft);
            _elevatorPanel.Controls.Add(_elevatorDoorRight);
        }

        // Public methods
        public void GoToFloor(int floor)
        {
            _logger.Log($"User requested floor {floor}", "USER");
            _currentState.MoveToFloor(floor);
        }

        public void ManualOpenDoors()
        {
            _logger.Log("User manually opening doors", "USER");
            _currentState.OpenDoors();
        }

        public void ManualCloseDoors()
        {
            _logger.Log("User manually closing doors", "USER");
            _currentState.CloseDoors();
        }

        // Internal methods
        public void SetState(ElevatorState newState)
        {
            _currentState = newState;
            _logger.Log($"State: {newState.GetStateName()}", "STATE");
        }

        public void QueueFloorRequest(int floor)
        {
            _queuedFloorRequest = floor;
            _logger.Log($"Queued floor {floor}", "QUEUE");
        }

        public void MoveToFloorInternal(int floor)
        {
            if (_elevator.IsMoving) return;

            _logger.Log($"Moving to floor {floor}", "MOVEMENT");
            _targetFloor = floor;

            if (_elevator.CurrentFloor == _targetFloor)
            {
                OpenDoorsInternal();
                return;
            }

            if (_doorsOpen)
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
            if (_isOpeningDoors || _doorsOpen) return;

            _logger.Log($"Opening doors at floor {_elevator.CurrentFloor}", "DOOR");
            SetState(new DoorOpenState(this));

            _isOpeningDoors = true;
            _isClosingDoors = false;
            _autoCloseTimer.Stop();
            _doorTimer.Start();
        }

        public void CloseDoorsInternal()
        {
            if (_isClosingDoors || !_doorsOpen) return;

            _logger.Log($"Closing doors at floor {_elevator.CurrentFloor}", "DOOR");
            SetState(new ClosingDoorsState(this));

            _isClosingDoors = true;
            _isOpeningDoors = false;
            _autoCloseTimer.Stop();
            _doorTimer.Start();
        }

        public void ArriveAtFloorInternal(int floor)
        {
            _logger.Log($"Arrived at floor {floor}", "ARRIVAL");
            OpenDoorsInternal();
        }

        private void StartMovement()
        {
            _autoCloseTimer.Stop();
            _targetY = (_targetFloor == 0) ? _floor0Y : _floor1Y;

            UpdateDisplay($"MOVING TO {_targetFloor}", Color.Yellow);
            _elevator.MoveToFloor(_targetFloor);
            _moveTimer.Start();
        }

        private void MoveElevatorTick(object sender, EventArgs e)
        {
            int direction = _targetY < _currentY ? -1 : 1;
            _currentY += direction * MOVE_SPEED;

            bool reachedTarget = (direction == -1 && _currentY <= _targetY) ||
                               (direction == 1 && _currentY >= _targetY);

            if (reachedTarget)
            {
                _currentY = _targetY;
                _moveTimer.Stop();
                _elevatorPanel.Top = _currentY;
                _elevator.OnArrivedAtFloor(_targetFloor);
            }
            else
            {
                _elevatorPanel.Top = _currentY;
            }
        }

        private void DoorAnimationTick(object sender, EventArgs e)
        {
            if (_isOpeningDoors)
            {
                if (_doorOpenWidth < MAX_DOOR_OPEN)
                {
                    _doorOpenWidth += DOOR_SPEED;
                }
                else
                {
                    _doorsOpen = true;
                    _isOpeningDoors = false;
                    _doorTimer.Stop();
                    _logger.Log("Doors fully opened", "DOOR");
                    UpdateDisplay($"FLOOR {_elevator.CurrentFloor} - OPEN", Color.Lime);
                    _autoCloseTimer.Start();
                }
            }
            else if (_isClosingDoors)
            {
                if (_doorOpenWidth > 0)
                {
                    _doorOpenWidth -= DOOR_SPEED;
                }
                else
                {
                    _doorsOpen = false;
                    _isClosingDoors = false;
                    _doorTimer.Stop();
                    _logger.Log("Doors fully closed", "DOOR");
                    UpdateDisplay($"FLOOR {_elevator.CurrentFloor}");

                    ProcessQueuedRequest();
                }
            }

            UpdateAllDoorPositions();
        }

        private void UpdateAllDoorPositions()
        {
            // Elevator doors
            if (_elevatorDoorLeft != null) _elevatorDoorLeft.Left = -_doorOpenWidth;
            if (_elevatorDoorRight != null) _elevatorDoorRight.Left = DOOR_WIDTH + _doorOpenWidth;

            // Floor doors
            if (_elevator.CurrentFloor == 0)
            {
                if (_floor0DoorLeft != null) _floor0DoorLeft.Left = -_doorOpenWidth;
                if (_floor0DoorRight != null) _floor0DoorRight.Left = DOOR_WIDTH + _doorOpenWidth;
            }
            else if (_elevator.CurrentFloor == 1)
            {
                if (_floor1DoorLeft != null) _floor1DoorLeft.Left = -_doorOpenWidth;
                if (_floor1DoorRight != null) _floor1DoorRight.Left = DOOR_WIDTH + _doorOpenWidth;
            }
        }

        private void ResetAllDoors()
        {
            _doorOpenWidth = 0;
            _floor0DoorOpenWidth = 0;
            _floor1DoorOpenWidth = 0;
            UpdateAllDoorPositions();
        }

        private void AutoCloseDoors(object sender, EventArgs e)
        {
            _autoCloseTimer.Stop();
            if (_doorsOpen && !_isClosingDoors)
            {
                _logger.Log("Auto-closing doors", "DOOR");
                CloseDoorsInternal();
            }
        }

        private void ProcessQueuedRequest()
        {
            if (_queuedFloorRequest.HasValue)
            {
                int floor = _queuedFloorRequest.Value;
                _queuedFloorRequest = null;
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
            _logger.Log($"Now at floor {floor}", "ARRIVAL");
        }

        private void OnMovementCompleted(object sender, EventArgs e)
        {
            SetState(new ArrivedState(this));
            _currentState.ArriveAtFloor(_elevator.CurrentFloor);
        }

        private void UpdateDisplay(string text, Color? color = null)
        {
            if (_displayLabel.InvokeRequired)
            {
                _displayLabel.Invoke(new Action(() =>
                {
                    _displayLabel.Text = text;
                    _displayLabel.ForeColor = color ?? Color.Lime;
                }));
            }
            else
            {
                _displayLabel.Text = text;
                _displayLabel.ForeColor = color ?? Color.Lime;
            }
        }

        public void Dispose()
        {
            _moveTimer?.Dispose();
            _doorTimer?.Dispose();
            _autoCloseTimer?.Dispose();
        }
    }
}