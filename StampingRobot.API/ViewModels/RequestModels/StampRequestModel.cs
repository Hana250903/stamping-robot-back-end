namespace StampingRobot.API.ViewModels.RequestModels
{
    public class StampRequestModel
    {
        public string Type { get; set; } = null!;

        public string Size { get; set; } = null!;

        public string InkColor { get; set; } = null!;
    }
}
