using StamingRobot.Repository.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StampingRobot.Service.BussinessModels
{
    public class TaskAssignmentModel : BaseEntity
    {
        public int JobId { get; set; }

        public string Status { get; set; } = null!;

        public string ImageCaptured { get; set; } = null!;

        public string Details { get; set; } = null!;
    }
}
