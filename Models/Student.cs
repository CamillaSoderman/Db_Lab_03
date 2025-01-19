using System;
using System.Collections.Generic;

namespace Db_Lab_03.Models;

public partial class Student
{
    public int StudentId { get; set; }

    public string SfirstName { get; set; }

    public string SlastName { get; set; }

    public long StudentNsn { get; set; }

    public string? Sadress { get; set; }

    public int ClassId { get; set; }

    public virtual ICollection<Enrolment> Enrolments { get; set; } = new List<Enrolment>();
}
