using System;
using System.Collections.Generic;

#nullable disable

namespace EntityFrameWorkExample.OrgModel
{
    public partial class Salary
    {
        public Salary()
        {
            EmpSalaries = new HashSet<EmpSalary>();
        }

        public int SalId { get; set; }
        public int? BasicSal { get; set; }
        public int? Hra { get; set; }
        public int? Da { get; set; }
        public int? Deduction { get; set; }

        public virtual ICollection<EmpSalary> EmpSalaries { get; set; }
    }
}
