﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpecFlowProjectAutomationDemo.Models
{
    internal class WithdrawAmountRequest
    {
        public string AccountNumber { get; set; }
        public decimal Amount { get; set; }
    }
}
