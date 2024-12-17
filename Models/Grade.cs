using System;
using System.Collections.Generic;

namespace Db_Lab_03.Models;

public partial class Grade
{
    public int GradeId { get; set; }

    public string? CourseName { get; set; }

    public string? SfirstName { get; set; }

    public string? SlastName { get; set; }

    public string? EmployeeName { get; set; }

    public DateOnly? ReportDate { get; set; }

    public string? Grade1 { get; set; }

    public virtual Course? CourseNameNavigation { get; set; }

    public virtual Employee? EmployeeNameNavigation { get; set; }
}
