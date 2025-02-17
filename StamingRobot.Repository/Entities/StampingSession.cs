﻿using System;
using System.Collections.Generic;

namespace StamingRobot.Repository.Entities;

public partial class StampingSession: BaseEntity
{
    public int Quantity { get; set; }

    public string Status { get; set; }

    public DateTime CreatedAt { get; set; }

    public int UserId { get; set; }

    public int RobotId { get; set; }

    public int ProductId { get; set; }

    public int? TaskAssignmentId { get; set; }

    public virtual Product Product { get; set; }

    public virtual Robot Robot { get; set; }

    public virtual ICollection<StampingProcess> StampingProcesses { get; set; } = new List<StampingProcess>();

    public virtual TaskAssignment TaskAssignment { get; set; }

    public virtual User User { get; set; }
}