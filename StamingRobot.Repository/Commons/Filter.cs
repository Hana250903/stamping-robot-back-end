using StamingRobot.Repository.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StamingRobot.Repository.Commons
{
    public class FilterRobot
    {
        public string? Name { get; set; }

    }

    public class FilterUser
    {
        public Role? Role { get; set; }

        public bool? IsDelete { get; set; }
    }

    public class FilterStamp
    {
        public string? Type { get; set; }

        public string? Size { get; set; }

        public string? InkColor { get; set; }
    }

    public class FilterTaskAssignment
    {
        public DateTime? TimeStamp { get; set; }
        //public string? Action { get; set; }
        //public string? Details { get; set; }
    }

    public class FilterSession
    {
        public string? Status { get; set; }
    }
}
