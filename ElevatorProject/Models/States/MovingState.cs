namespace ElevatorProject.Models.States
{
    public class MovingState : ElevatorState
    {
        public MovingState(ElevatorController controller) : base(controller) { }

        public override void MoveToFloor(int floor)
        {
            controller.Logger.Log($"Already moving. Floor {floor} queued", "STATE");
            controller.QueueFloorRequest(floor);
        }

        public override void OpenDoors()
        {
            controller.Logger.Log("Can't open doors while moving", "STATE");
        }

        public override void CloseDoors()
        {
            controller.Logger.Log("Doors already closed", "STATE");
        }

        public override void ArriveAtFloor(int floor)
        {
            controller.Logger.Log($"Arrived at floor {floor}", "STATE");
            controller.ArriveAtFloorInternal(floor);
        }

        public override void EmergencyStop()
        {
            controller.Logger.Log("Emergency stop while moving!", "EMERGENCY");
            controller.EmergencyStopInternal();
        }

        public override string GetStateName()
        {
            return "Moving";
        }
    }
}