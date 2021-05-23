using System;
using System.Collections.Generic;

#nullable disable

namespace EntityFrameWorkExample.OrgModel
{
    public partial class TransactionE
    {
        public int? TrainId { get; set; }
        public int? FromAcc { get; set; }
        public int? ToAcc { get; set; }
        public double? Amount { get; set; }
        public string Remarks { get; set; }
    }
}
