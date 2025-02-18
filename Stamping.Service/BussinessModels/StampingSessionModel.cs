using StamingRobot.Repository.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StampingRobot.Service.BussinessModels
{
    public class StampingSessionModel : BaseEntity
    {
        public int Quantity { get; set; }

        public string Status { get; set; }

        public DateTime CreatedAt { get; set; }

        public int UserId { get; set; }

        public int RobotId { get; set; }

        public int ProductId { get; set; }

        public int? TaskAssignmentId { get; set; }
    }
}
