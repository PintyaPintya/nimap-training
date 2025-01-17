using System;
using System.Collections.Generic;

namespace SqlQueryPractice.Models;

public partial class Faculty
{
    public int Id { get; set; }

    public string? Namefirst { get; set; }

    public string? Namelast { get; set; }

    public DateOnly? Dob { get; set; }

    public string? EmailId { get; set; }

    public virtual FacultyAddress? FacultyAddress { get; set; }

    public virtual ICollection<FacultyPhone> FacultyPhones { get; set; } = new List<FacultyPhone>();

    public virtual ICollection<FacultyQualification> FacultyQualifications { get; set; } = new List<FacultyQualification>();
}
