﻿using System;
using System.Collections.Generic;

namespace Db_Lab_03.Models;


public partial class Role
    {
    public int RoleId { get; set; }
    public string RoleName { get; set; } = null!;
    public virtual ICollection<Employee> Employees { get; set; } = new List<Employee>();
}
