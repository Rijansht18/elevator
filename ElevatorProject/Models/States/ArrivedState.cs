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
            controller.Logger.Log("Opening doors...", "STATE");
            controller.OpenDoorsInternal();
        }

        public override void CloseDoors()
        {
            controller.Logger.Log("Skipping door open", "STATE");
            // Just transition back to idle without opening
            controller.SetState(new IdleState(controller));
        }

        public override void ArriveAtFloor(int floor)
        {
            controller.Logger.Log("Already arrived", "STATE");
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