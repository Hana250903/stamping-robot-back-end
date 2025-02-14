using System;
using System.Collections.Generic;

namespace StamingRobot.Repository.Entities;

public partial class Product : BaseEntity
{
    public string Name { get; set; }

    public string Dimensions { get; set; }

    public string Material { get; set; }

    public int StampId { get; set; }

    public virtual Stamp Stamp { get; set; }

    public virtual ICollection<StampingSession> StampingSessions { get; set; } = new List<StampingSession>();
}