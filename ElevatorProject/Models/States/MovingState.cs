namespace ElevatorProject.Models.States
{
    public class MovingState : ElevatorState
    {
        public MovingState(ElevatorController controller) : base(controller) { }

        public override void MoveToFloor(int floor)
        {
            controller.Logger.Log($"Already moving. Floor {floor} queued", "QUEUE");
            controller.QueueFloorRequest(floor);
        }

        public override void OpenDoors()
        {
            controller.Logger.Log("Cannot open doors while moving", "DOOR");
        }

        public override void CloseDoors()
        {
            controller.Logger.Log("Doors already closed while moving", "DOOR");
        }

        public override void ArriveAtFloor(int floor)
        {
            controller.Logger.Log($"Arrived at floor {floor}", "ARRIVAL");
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