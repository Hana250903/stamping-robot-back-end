﻿using StamingRobot.Repository.Entities;
using StampingRobot.Service.BussinessModels;
using System.ComponentModel.DataAnnotations;

namespace StampingRobot.API.ViewModels.RequestModels
{
    public class CreateStampingJobRequestModel
    {
        [Required(ErrorMessage = "StepNumber must be in sequence!")]
        public int StepNumber { get; set; }

        [Required(ErrorMessage = "Discription not empty!")]
        public string Description { get; set; } = null!;

        public int SessionId { get; set; }

        public string Action { get; set; } = null!;
    }

    public class UpdateStampingJobRequestModel
    {
        public string Description {  set; get; } = null!;

        public string Status { get; set; } = null!;

        public string Action { get; set; } = null!;
    }
}
