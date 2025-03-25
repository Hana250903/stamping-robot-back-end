using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace StamingRobot.Repository.Entities;

public partial class StampingJob: BaseEntity
{
    public int StepNumber { get; set; }

    public string Description { get; set; } = null!;

    public int SessionId { get; set; }

    public string Status { get; set; } = null!;

    public string Action { get; set; } = null!;

    [JsonIgnore]
    public virtual StampingSession Session { get; set; } = null!;

    public virtual ICollection<TaskAssignment> TaskAssignments { get; set; } = new List<TaskAssignment>();

}