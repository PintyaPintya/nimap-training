using System;
using System.Collections.Generic;

namespace SqlQueryPractice.Models;

public partial class Student
{
    public int Id { get; set; }

    public string? Namefirst { get; set; }

    public string? Namelast { get; set; }

    public DateOnly? Dob { get; set; }

    public string? EmailId { get; set; }

    public virtual ICollection<BatchStudent> BatchStudents { get; set; } = new List<BatchStudent>();

    public virtual StudentAddress? StudentAddress { get; set; }

    public virtual ICollection<StudentCard> StudentCards { get; set; } = new List<StudentCard>();

    public virtual ICollection<StudentOrder> StudentOrders { get; set; } = new List<StudentOrder>();

    public virtual ICollection<StudentPhone> StudentPhones { get; set; } = new List<StudentPhone>();

    public virtual ICollection<StudentQualification> StudentQualifications { get; set; } = new List<StudentQualification>();
}
