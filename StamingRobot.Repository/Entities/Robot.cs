using System;
using System.Collections.Generic;

namespace StamingRobot.Repository.Entities;

public partial class Robot : BaseEntity
{
    public string Name { get; set; } = null!;

    public string Model { get; set; } = null!;

    public string Status { get; set; } = null!;

    public int? UserId { get; set; }

    public virtual ICollection<StampingSession> StampingSessions { get; set; } = new List<StampingSession>();

    public virtual User? User { get; set; }
}