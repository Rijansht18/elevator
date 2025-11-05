namespace ElevatorProject.Models.States
{
    public class IdleState : ElevatorState
    {
        public IdleState(ElevatorController controller) : base(controller) { }

        public override void MoveToFloor(int floor)
        {
            if (floor == controller.CurrentFloor)
            {
                controller.Logger.Log("Already at floor " + floor, "STATE");
                return;
            }

            controller.Logger.Log($"Going from floor {controller.CurrentFloor} to floor {floor}", "STATE");
            controller.MoveToFloorInternal(floor);
        }

        public override void OpenDoors()
        {
            controller.Logger.Log("Can't open doors in idle", "STATE");
        }

        public override void CloseDoors()
        {
            controller.Logger.Log("Doors already closed", "STATE");
        }

        public override void ArriveAtFloor(int floor)
        {
            controller.Logger.Log("Error: Can't arrive while idle", "STATE");
        }

        public override void EmergencyStop()
        {
            controller.Logger.Log("Emergency stop!", "EMERGENCY");
            controller.EmergencyStopInternal();
        }

        public override string GetStateName()
        {
            return "Idle";
        }
    }
}