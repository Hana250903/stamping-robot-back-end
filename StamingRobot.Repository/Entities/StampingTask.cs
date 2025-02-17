﻿using System;
using System.Collections.Generic;

namespace StamingRobot.Repository.Entities;

public partial class StampingTask: BaseEntity
{
    public string Status { get; set; }

    public string ImageCaptured { get; set; }

    public int RobotId { get; set; }

    public int ProcessId { get; set; }

    public int? TaskAssignmentId { get; set; }

    public virtual StampingProcess Process { get; set; }

    public virtual Robot Robot { get; set; }

    public virtual TaskAssignment TaskAssignment { get; set; }
}