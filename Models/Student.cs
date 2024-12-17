using System;
using System.Collections.Generic;

namespace Db_Lab_03.Models;

public partial class Student
{
    public int StudentId { get; set; }

    public string? SfirstName { get; set; }

    public string? SlastName { get; set; }

    public string? StudentNsn { get; set; }

    public string? Sadress { get; set; }
}
