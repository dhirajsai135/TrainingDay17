using System;
using System.Collections.Generic;

#nullable disable

namespace EntityFrameWorkExample.OrgModel
{
    public partial class Account
    {
        public string AccNumber { get; set; }
        public string Name { get; set; }
        public double? Balance { get; set; }
        public string Status { get; set; }
    }
}
