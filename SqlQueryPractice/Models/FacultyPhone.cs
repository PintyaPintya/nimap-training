using System;
using System.Collections.Generic;

namespace SqlQueryPractice.Models;

public partial class FacultyPhone
{
    public int Id { get; set; }

    public int? FacultyId { get; set; }

    public string? Number { get; set; }

    public virtual Faculty? Faculty { get; set; }
}
