using System;
using System.Collections.Generic;

namespace SqlQueryPractice.Models;

public partial class StudentOrder
{
    public int Id { get; set; }

    public int? StudentId { get; set; }

    public DateOnly? Orderdate { get; set; }

    public int? Amount { get; set; }

    public virtual Student? Student { get; set; }
}
