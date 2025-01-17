using System;
using System.Collections.Generic;

namespace SqlQueryPractice.Models;

public partial class Module
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public int? Duration { get; set; }

    public virtual ICollection<CourseModule> CourseModules { get; set; } = new List<CourseModule>();
}
