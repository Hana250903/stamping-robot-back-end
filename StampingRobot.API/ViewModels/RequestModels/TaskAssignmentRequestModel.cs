namespace StampingRobot.API.ViewModels.RequestModels
{
    public class CreateTaskAssignmentRequestModel
    {
        public int JobId { get; set; }

        public string Status { get; set; } = null!;

        public string ImageCaptured { get; set; } = null!;

        public string Details { get; set; } = null!;
    }
}
