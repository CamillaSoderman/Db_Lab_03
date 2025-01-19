using System;
using System.Collections.Generic;

namespace Db_Lab_03.Models;

public partial class Employee
{
    public int EmployeeId { get; set; }

    public string EmpFirstName { get; set; } = null!;
    public string EmpLastName { get; set; } = null!;

    public int RoleId { get; set; }
    public DateTime EmploymentDate { get; set; }
    public int Salary { get; set; }


    public virtual ICollection<Enrolment> Enrolments { get; set; } = new List<Enrolment>();

    public virtual Role Role { get; set; } = null!;


}
