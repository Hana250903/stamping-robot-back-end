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
        public ModelRobot? Model { get; set; }

        public string? Name { get; set; }

        public RobotStatus? Status { get; set; }

        public bool? Sort { get; set; }

        public bool? IsDelete { get; set; }

    }

    public class FilterUser
    {
        public Role? Role { get; set; }

        public bool? Sort { get; set; }

        public bool? IsDelete { get; set; }
    }

    public class FilterStamp
    {
        public string? Type { get; set; }

        public string? Size { get; set; }

        public string? InkColor { get; set; }

        public bool? IsDelete { get; set; }
    }

    public class FilterTaskAssignment
    {
        public DateTime? StartDate { get; set; }

        public DateTime? EndDate { get; set; }

        public bool? IsDelete { get; set; }
    }


    public class FilterSession
    {
        public StampingSessionStatus? Status { get; set; }

        public bool? Sort { get; set; }

        public bool? IsDelete { get; set; }
    }

    public class FilterStampingJob
    {
        public StampingJobStatus? Status { get; set; }

        public bool? IsDelete { get; set; }
    }

    public class FilterProduct
    {
        public string? Name { get; set; } = null!;

        public string? Material { get; set; } = null!;

        public bool? IsDelete { get; set; }
    }
}
