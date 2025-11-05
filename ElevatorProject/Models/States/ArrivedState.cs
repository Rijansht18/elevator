namespace ElevatorProject.Models.States
{
    public class ArrivedState : ElevatorState
    {
        public ArrivedState(ElevatorController controller) : base(controller) { }

        public override void MoveToFloor(int floor)
        {
            controller.Logger.Log($"Floor {floor} queued", "STATE");
            controller.QueueFloorRequest(floor);
        }

        public override void OpenDoors()
        {
            controller.Logger.Log("Doors already opening automatically", "STATE");
        }

        public override void CloseDoors()
        {
            controller.Logger.Log("Can't close doors - they need to open first after arrival", "STATE");
        }

        public override void ArriveAtFloor(int floor)
        {
            // This automatically opens doors when arriving
            controller.Logger.Log("Arrived at floor, opening doors automatically", "ARRIVAL");
            controller.OpenDoorsInternal();
        }

        public override void EmergencyStop()
        {
            controller.Logger.Log("Emergency stop!", "EMERGENCY");
            controller.EmergencyStopInternal();
        }

        public override string GetStateName()
        {
            return "Arrived";
        }
    }
}