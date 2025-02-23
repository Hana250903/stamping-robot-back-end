namespace StampingRobot.API.ViewModels.RequestModels
{
    public class TaskAssignmentRequestModel
    {
        public DateTime TimeStamp { get; set; }
        public string Action { get; set; } = null!;
        public string Details { get; set; } = null!;
    }
}
