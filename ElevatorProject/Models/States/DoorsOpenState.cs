namespace ElevatorProject.Models.States
{
    public class DoorOpenState : ElevatorState
    {
        public DoorOpenState(ElevatorController controller) : base(controller) { }

        public override void MoveToFloor(int floor)
        {
            controller.Logger.Log($"Closing doors to move to floor {floor}", "DOOR");
            controller.QueueFloorRequest(floor);
            controller.CloseDoorsInternal();
        }

        public override void OpenDoors()
        {
            controller.Logger.Log("Doors already open", "DOOR");
        }

        public override void CloseDoors()
        {
            controller.Logger.Log("Closing doors manually", "DOOR");
            controller.CloseDoorsInternal();
        }

        public override void ArriveAtFloor(int floor)
        {
            controller.Logger.Log("Already arrived at floor", "ARRIVAL");
        }


        public override string GetStateName()
        {
            return "DoorsOpen";
        }
    }
}