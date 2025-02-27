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
        public string StepNumber { get; set; }

        public string Description { get; set; }

        public int SessionId { get; set; }
    }
}
