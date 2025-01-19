using System;
using System.Collections.Generic;

namespace Db_Lab_03.Models;

public partial class Enrolment
{
    public int EnrolmentId { get; set; }

    public int CourseId { get; set; }

    public int StudentId { get; set; }

    public int EmployeeId { get; set; }

  
    public virtual Course Course { get; set; } = null!;

    public virtual Employee Employee { get; set; } = null!;

    public virtual Student Student { get; set; } = null!;
   
}