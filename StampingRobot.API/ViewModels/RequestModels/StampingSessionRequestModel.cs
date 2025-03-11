namespace StampingRobot.API.ViewModels.RequestModels
{
    public class CreateStampingSessionRequestModel
    {
        public int Quantity { get; set; }

        public int? RobotId { get; set; }

        public int? ProductId { get; set; }
    }

    public class UpdateStampingSessionRequestModel
    {
        public int Quantity { get; set; }

        public string Status { get; set; } = null!;

        public int? RobotId { get; set; }

        public int? ProductId { get; set; }
    }
}
