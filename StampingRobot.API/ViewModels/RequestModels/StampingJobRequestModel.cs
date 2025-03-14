﻿using StamingRobot.Repository.Entities;
using StampingRobot.Service.BussinessModels;

namespace StampingRobot.API.ViewModels.RequestModels
{
    public class CreateStampingJobRequestModel
    {
        public int StepNumber { get; set; }

        public string Description { get; set; } = null!;

        public int SessionId { get; set; }

        public StampingJobParameters Parameters { get; set; } = null!;
    }

    public class UpdateStampingJobRequestModel
    {
        public string Description {  set; get; } = null!;

        public string Status { get; set; } = null!;

        public StampingJobParameters Parameters { get; set; } = null!;
    }

    public class Parameters
    {
        public float Base { get; set; }

        public float Upperarm { get; set; }

        public float Forearm { get; set; }

        public float Wrist { get; set; }

        public float RotationWrist { get; set; }

        public float Gripper { get; set; }
    }
}
