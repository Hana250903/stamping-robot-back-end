﻿using System;
using System.Collections.Generic;

namespace StamingRobot.Repository.Entities;

public partial class StampingProcess: BaseEntity
{
    public string StepNumber { get; set; }

    public string Description { get; set; }

    public int SessionId { get; set; }

    public virtual StampingSession Session { get; set; }

    public virtual ICollection<StampingTask> StampingTasks { get; set; } = new List<StampingTask>();
}