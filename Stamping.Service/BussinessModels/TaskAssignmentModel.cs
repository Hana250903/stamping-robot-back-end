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
        public DateTime TimeStamp { get; set; }

        public string Action { get; set; }

        public string Details { get; set; }
    }
}
