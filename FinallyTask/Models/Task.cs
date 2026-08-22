using System;
using System.Collections.Generic;

namespace FinallyTask.Models;

public partial class Task
{
    public Guid Id { get; set; }

    public string Name { get; set; } = null!;

    public string? Description { get; set; }

    public bool IsActive { get; set; }

    public string CodeProject { get; set; } = null!;

    public virtual Project CodeProjectNavigation { get; set; } = null!;

    public virtual ICollection<Worklog> Worklogs { get; set; } = new List<Worklog>();
}
