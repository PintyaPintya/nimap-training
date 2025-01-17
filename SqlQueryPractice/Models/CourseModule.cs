using System;
using System.Collections.Generic;

namespace SqlQueryPractice.Models;

public partial class CourseModule
{
    public int Id { get; set; }

    public int? CourseId { get; set; }

    public int? ModuleId { get; set; }

    public virtual Course? Course { get; set; }

    public virtual Module? Module { get; set; }
}
