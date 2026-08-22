using System;
using System.Collections.Generic;

namespace FinallyTask.Models;

public partial class Project
{
    public string Code { get; set; } = null!;

    public string Name { get; set; } = null!;

    public bool IsActive { get; set; }

    public virtual ICollection<Task> Tasks { get; set; } = new List<Task>();
}
