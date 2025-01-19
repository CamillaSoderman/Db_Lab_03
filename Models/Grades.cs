using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Db_Lab_03.Models
{
    public class Grades
    {
        public int GradeId { get; set; }
        public int EmployeeId { get; set; }

        public int StudentId { get; set; }

        public int CourseId { get; set; }
        public int Grade { get; set; }
        public DateTime GradeDate { get; set; }

        public virtual Student Student { get; set; } = null!;

    }
    
}
