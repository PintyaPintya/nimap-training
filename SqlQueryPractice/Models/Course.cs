using System;
using System.Collections.Generic;

namespace SqlQueryPractice.Models;

public partial class Course
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public int? Duration { get; set; }

    public string? Summery { get; set; }

    public virtual ICollection<CourseBatch> CourseBatches { get; set; } = new List<CourseBatch>();

    public virtual ICollection<CourseModule> CourseModules { get; set; } = new List<CourseModule>();
}
