using StamingRobot.Repository.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StampingRobot.Service.BussinessModels
{
    public class StampModel : BaseEntity
    {
        public string Type { get; set; }

        public string Size { get; set; }

        public string InkColor { get; set; }
    }
}
