using StampingRobot.Service.BussinessModels;

namespace StampingRobot.API.ViewModels.RequestModels
{
    public class CreateStampingJobRequestModel
    {
        public int StepNumber { get; set; }

        public string Description { get; set; } = null!;

        public int SessionId { get; set; }

        public string Status { get; set; } = null!;

        public StampingJobParametersModel Parameters { get; set; } = null!;
    }
}
