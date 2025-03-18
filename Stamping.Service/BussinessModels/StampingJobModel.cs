using StamingRobot.Repository.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StampingRobot.Service.BussinessModels
{
    public class StampingJobModel : BaseEntity
    {
        public int StepNumber { get; set; }

        public string Description { get; set; } = null!;

        public int SessionId { get; set; }

        public string Status { get; set; } = null!;

        public string Action { get; set; } = null!;
    }
}
