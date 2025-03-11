namespace StampingRobot.API.ViewModels.RequestModels
{
    public class RobotRequestModel
    {
        
        public string Name { get; set; } = null!;

        public string Model { get; set; } = null!;
    }

    public class UpdateRobotRequestModel
    {
        public string Name { get; set; } = null!;

        public string Status { get; set; } = null!;
    }
}
