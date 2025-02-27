using System;
using System.Collections.Generic;

namespace StamingRobot.Repository.Entities;

public partial class StampingSession : BaseEntity
{
    public int Quantity { get; set; }

    public string Status { get; set; } = null!;

    public int? UserId { get; set; }

    public int? RobotId { get; set; }

    public int? ProductId { get; set; }

    public virtual Product? Product { get; set; }

    public virtual Robot? Robot { get; set; }

    public virtual ICollection<StampingJob> StampingJobs { get; set; } = new List<StampingJob>();

    public virtual User? User { get; set; }
}
