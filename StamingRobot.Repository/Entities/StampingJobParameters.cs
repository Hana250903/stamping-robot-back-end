using System;
using System.Collections.Generic;

namespace StamingRobot.Repository.Entities;

public partial class StampingJobParameters: BaseEntity
{
    public int JobId { get; set; }

    public float Base { get; set; }

    public float Upperarm { get; set; }

    public float Forearm { get; set; }

    public float Wrist { get; set; }

    public float RotationWrist { get; set; }

    public float Gripper { get; set; }

    public virtual StampingJob StampingJob { get; set; } = null!;
}