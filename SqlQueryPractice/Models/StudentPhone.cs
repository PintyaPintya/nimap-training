using System;
using System.Collections.Generic;

namespace SqlQueryPractice.Models;

public partial class StudentPhone
{
    public int Id { get; set; }

    public int? StudentId { get; set; }

    public string? Number { get; set; }

    public bool? IsActive { get; set; }

    public virtual Student? Student { get; set; }
}
