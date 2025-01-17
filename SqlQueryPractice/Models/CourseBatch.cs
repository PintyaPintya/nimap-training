using System;
using System.Collections.Generic;

namespace SqlQueryPractice.Models;

public partial class CourseBatch
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public int? CourseId { get; set; }

    public DateOnly? Starton { get; set; }

    public DateOnly? Endson { get; set; }

    public int? Capacity { get; set; }

    public virtual ICollection<BatchStudent> BatchStudents { get; set; } = new List<BatchStudent>();

    public virtual Course? Course { get; set; }
}
