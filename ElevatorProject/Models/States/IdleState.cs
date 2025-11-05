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
                controller.OpenDoorsInternal();
                return;
            }

            controller.Logger.Log($"Moving from floor {controller.CurrentFloor} to floor {floor}", "MOVEMENT");
            controller.MoveToFloorInternal(floor);
        }

        public override void OpenDoors()
        {
            controller.Logger.Log("Opening doors from idle state", "DOOR");
            controller.OpenDoorsInternal();
        }

        public override void CloseDoors()
        {
            controller.Logger.Log("Doors already closed in idle state", "DOOR");
        }

        public override void ArriveAtFloor(int floor)
        {
            controller.Logger.Log("Cannot arrive while idle", "STATE");
        }

        public override void EmergencyStop()
        {
            controller.Logger.Log("Emergency stop activated", "EMERGENCY");
            controller.EmergencyStopInternal();
        }

        public override string GetStateName()
        {
            return "Idle";
        }
    }
}