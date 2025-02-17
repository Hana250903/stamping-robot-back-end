﻿using System;
using System.Collections.Generic;

namespace StamingRobot.Repository.Entities;

public partial class Robot : BaseEntity
{
    public string Model { get; set; }

    public string Status { get; set; }

    public string Position { get; set; }

    public int UserId { get; set; }

    public virtual ICollection<StampingSession> StampingSessions { get; set; } = new List<StampingSession>();

    public virtual ICollection<StampingTask> StampingTasks { get; set; } = new List<StampingTask>();

    public virtual User User { get; set; }
}