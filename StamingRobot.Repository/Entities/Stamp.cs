﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
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