using System;
using System.Collections.Generic;

namespace StamingRobot.Repository.Entities;

public partial class Product : BaseEntity
{
    public string Name { get; set; } = null!;

    public string Dimensions { get; set; } = null!;

    public string Material { get; set; } = null!;

    public int? StampId { get; set; }

    public virtual Stamp? Stamp { get; set; }

    public virtual ICollection<StampingSession> StampingSessions { get; set; } = new List<StampingSession>();
}