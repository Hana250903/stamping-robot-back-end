using StamingRobot.Repository.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StampingRobot.Service.BussinessModels
{
    public class ProductModel : BaseEntity
    {
        public string Name { get; set; }

        public string Dimensions { get; set; }

        public string Material { get; set; }

        public int StampId { get; set; }
    }
}
