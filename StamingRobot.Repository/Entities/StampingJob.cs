using System;
using System.Collections.Generic;

namespace StamingRobot.Repository.Entities;

public partial class StampingJob: BaseEntity
{
    public int StepNumber { get; set; }

    public string Description { get; set; } = null!;

    public int SessionId { get; set; }

    public string Status { get; set; } = null!;

    public StampingJobParameters Parameters { get; set; } = null!;

    public virtual StampingSession Session { get; set; } = null!;

    public virtual ICollection<TaskAssignment> TaskAssignments { get; set; } = new List<TaskAssignment>();

}

public class StampingJobParameters
{
    public float Base { get; set; }

    public float Upperarm { get; set; }

    public float Forearm { get; set; }

    public float Wrist { get; set; }

    public float RotationWrist { get; set; }

    public float Gripper { get; set; }
}