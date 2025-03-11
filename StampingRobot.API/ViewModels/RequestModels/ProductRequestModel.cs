namespace StampingRobot.API.ViewModels.RequestModels
{
    public class ProductRequestModel
    {
        public string Name { get; set; } = null!;

        public string Dimensions { get; set; } = null!;

        public string Material { get; set; } = null!;

        public int? StampId { get; set; }
    }
}
