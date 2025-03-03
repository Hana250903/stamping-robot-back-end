using StamingRobot.Repository.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StampingRobot.Service.BussinessModels
{
    public class StampingJobParametersModel
    {
        public float Base { get; set; }

        public float Upperarm { get; set; }

        public float Forearm { get; set; }

        public float Wrist { get; set; }

        public float RotationWrist { get; set; }

        public float Gripper { get; set; }
    }
}
