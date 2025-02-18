using StamingRobot.Repository.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StampingRobot.Service.BussinessModels
{
    public class RobotModel : BaseEntity
    {
        public string Model { get; set; }

        public string Status { get; set; }

        public string Position { get; set; }

        public int UserId { get; set; }
    }
}
