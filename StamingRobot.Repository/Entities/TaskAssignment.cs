using System;
using System.Collections.Generic;

namespace StamingRobot.Repository.Entities;

public partial class TaskAssignment: BaseEntity
{
    public DateTime TimeStamp { get; set; }

    public string Action { get; set; }

    public string Details { get; set; }

    public virtual ICollection<StampingSession> StampingSessions { get; set; } = new List<StampingSession>();

    public virtual ICollection<StampingTask> StampingTasks { get; set; } = new List<StampingTask>();
}