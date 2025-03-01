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
        public string Name { get; set; } = null!;

        public string Dimensions { get; set; } = null!;

        public string Material { get; set; } = null!;

        public int? StampId { get; set; }
    }
}
