using System;
using System.Collections.Generic;

#nullable disable

namespace EntityFrameWorkExample.OrgModel
{
    public partial class EmpSalary
    {
        public string TranscNum { get; set; }
        public int? EmpId { get; set; }
        public int? SalId { get; set; }
        public DateTime? Date { get; set; }

        public virtual Employee Emp { get; set; }
        public virtual Salary Sal { get; set; }
    }
}
