using System;
using System.Collections.Generic;

namespace StamingRobot.Repository.Entities;

public partial class TaskAssignment: BaseEntity
{
    public int JobId { get; set; }

    public string Status { get; set; } = null!;

    public string ImageCaptured { get; set; } = null!;

    public string Details { get; set; } = null!;

    public virtual StampingJob StampingJob { get; set; } = null!;
}