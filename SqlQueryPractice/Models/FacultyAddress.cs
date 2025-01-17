using System;
using System.Collections.Generic;

namespace SqlQueryPractice.Models;

public partial class FacultyAddress
{
    public int Id { get; set; }

    public int FacultyId { get; set; }

    public string? Address { get; set; }

    public virtual Faculty Faculty { get; set; } = null!;
}
