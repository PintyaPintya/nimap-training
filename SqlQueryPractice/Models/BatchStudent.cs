using System;
using System.Collections.Generic;

namespace SqlQueryPractice.Models;

public partial class BatchStudent
{
    public int Id { get; set; }

    public int? BatchId { get; set; }

    public int? StudentId { get; set; }

    public virtual CourseBatch? Batch { get; set; }

    public virtual Student? Student { get; set; }
}
