namespace ElevatorProject.Models.States
{
    public class ClosingDoorsState : ElevatorState
    {
        public ClosingDoorsState(ElevatorController controller) : base(controller) { }

        public override void MoveToFloor(int floor)
        {
            controller.Logger.Log($"Floor {floor} queued", "STATE");
            controller.QueueFloorRequest(floor);
        }

        public override void OpenDoors()
        {
            controller.Logger.Log("Reopening doors", "STATE");
            controller.OpenDoorsInternal();
        }

        public override void CloseDoors()
        {
            controller.Logger.Log("Doors already closing", "STATE");
        }

        public override void ArriveAtFloor(int floor)
        {
            controller.Logger.Log("Error: Can't arrive while closing doors", "STATE");
        }


        public override string GetStateName()
        {
            return "ClosingDoors";
        }
    }
}