using System;
using System.Collections.Generic;

namespace SqlQueryPractice.Models;

public partial class FacultyQualification
{
    public int Id { get; set; }

    public int? FacultyId { get; set; }

    public string? Name { get; set; }

    public string? College { get; set; }

    public string? University { get; set; }

    public string? Marks { get; set; }

    public int? Year { get; set; }

    public virtual Faculty? Faculty { get; set; }
}
