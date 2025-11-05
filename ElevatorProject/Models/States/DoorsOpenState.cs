namespace ElevatorProject.Models.States
{
    public class DoorOpenState : ElevatorState
    {
        public DoorOpenState(ElevatorController controller) : base(controller) { }

        public override void MoveToFloor(int floor)
        {
            controller.Logger.Log($"Closing doors to move to floor {floor}", "STATE");
            controller.QueueFloorRequest(floor);
            controller.CloseDoorsInternal();
        }

        public override void OpenDoors()
        {
            controller.Logger.Log("Doors already open", "STATE");
        }

        public override void CloseDoors()
        {
            controller.Logger.Log("Closing doors...", "STATE");
            controller.CloseDoorsInternal();
        }

        public override void ArriveAtFloor(int floor)
        {
            controller.Logger.Log("Already at floor", "STATE");
        }

        public override void EmergencyStop()
        {
            controller.Logger.Log("Emergency stop!", "EMERGENCY");
            controller.EmergencyStopInternal();
        }

        public override string GetStateName()
        {
            return "DoorOpen";
        }
    }
}