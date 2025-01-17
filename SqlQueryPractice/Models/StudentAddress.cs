using System;
using System.Collections.Generic;

namespace SqlQueryPractice.Models;

public partial class StudentAddress
{
    public int Id { get; set; }

    public int StudentId { get; set; }

    public string Address { get; set; } = null!;

    public virtual Student Student { get; set; } = null!;
}
