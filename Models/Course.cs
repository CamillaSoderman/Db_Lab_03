using System;
using System.Collections.Generic;

namespace Db_Lab_03.Models;

public partial class Course
{
    public int CourseId { get; set; }

    public string CourseName { get; set; } = null!;

    public string? EmployeeName { get; set; }

    public virtual Employee? EmployeeNameNavigation { get; set; }

    public virtual ICollection<Grade> Grades { get; set; } = new List<Grade>();
}
