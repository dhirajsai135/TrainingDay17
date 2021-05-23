using System;
using System.Collections.Generic;

#nullable disable

namespace EntityFrameWorkExample.OrgModel
{
    public partial class Employee
    {
        public Employee()
        {
            EmpSalaries = new HashSet<EmpSalary>();
        }

        public int EmpId { get; set; }
        public string Name { get; set; }
        public int? Age { get; set; }
        public string Phone { get; set; }
        public string Gender { get; set; }
        public string Email { get; set; }

        public virtual ICollection<EmpSalary> EmpSalaries { get; set; }
    }
}
