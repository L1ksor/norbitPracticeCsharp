using System;
using System.Collections.Generic;

namespace FinallyTask.Models;

public partial class Worklog
{
    public Guid Id { get; set; }

    public DateOnly WorkDate { get; set; }

    public decimal Hours { get; set; }

    public string? Description { get; set; }

    public Guid TaskId { get; set; }

    public virtual Task Task { get; set; } = null!;
}
