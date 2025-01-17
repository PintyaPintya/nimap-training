using System;
using System.Collections.Generic;

namespace SqlQueryPractice.Models;

public partial class StudentQualification
{
    public int Id { get; set; }

    public int? StudentId { get; set; }

    public string? Name { get; set; }

    public string? College { get; set; }

    public string? University { get; set; }

    public string? Marks { get; set; }

    public int? Year { get; set; }

    public virtual Student? Student { get; set; }
}
