using System;
using System.Collections.Generic;

namespace StamingRobot.Repository.Entities;

public partial class Stamp: BaseEntity
{
    public string Type { get; set; }

    public string Size { get; set; }

    public string InkColor { get; set; }

    public virtual ICollection<Product> Products { get; set; } = new List<Product>();
}