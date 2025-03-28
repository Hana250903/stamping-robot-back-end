﻿using StamingRobot.Repository.Enum;
using System;
using System.Collections.Generic;

namespace StamingRobot.Repository.Entities;

public partial class User: BaseEntity
{
    public string FullName { get; set; }

    public string Phone { get; set; }

    public string Email { get; set; }

    public string? GoogleId { get; set; }

    public string? Password { get; set; }

    public int? CodeOtpEmail { get; set; }

    public string? RefreshToken { get; set; }

    public Role Role { get; set; }

    public virtual ICollection<Robot> Robots { get; set; } = new List<Robot>();

    public virtual ICollection<StampingSession> StampingSessions { get; set; } = new List<StampingSession>();
}