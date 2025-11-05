namespace ElevatorProject.Models.States
{
    public class EmergencyState : ElevatorState
    {
        public EmergencyState(ElevatorController controller) : base(controller) { }

        public override void MoveToFloor(int floor)
        {
            controller.Logger.Log("Emergency active - can't move", "EMERGENCY");
        }

        public override void OpenDoors()
        {
            controller.Logger.Log("Emergency active - can't open doors", "EMERGENCY");
        }

        public override void CloseDoors()
        {
            controller.Logger.Log("Emergency active - can't close doors", "EMERGENCY");
        }

        public override void ArriveAtFloor(int floor)
        {
            controller.Logger.Log("Emergency active - can't arrive", "EMERGENCY");
        }

        public override void EmergencyStop()
        {
            controller.Logger.Log("Already in emergency mode", "EMERGENCY");
        }

        public override string GetStateName()
        {
            return "Emergency";
        }
    }
}