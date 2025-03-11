using StamingRobot.Repository.Entities;
using StamingRobot.Repository.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StampingRobot.Service.BussinessModels
{
    public class RobotModel : BaseEntity
    {
        public string Name { get; set; } = null!;

        public string Model { get; set; } = null!;

        public string Status { get; set; } = null!;

        public int? UserId { get; set; }
    }
}
