using StamingRobot.Repository.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StampingRobot.Service.BussinessModels
{
    public class StampingTaskModel : BaseEntity
    {
        public string Status { get; set; }

        public string ImageCaptured { get; set; }

        public int RobotId { get; set; }

        public int ProcessId { get; set; }

        public int? TaskAssignmentId { get; set; }
    }
}
