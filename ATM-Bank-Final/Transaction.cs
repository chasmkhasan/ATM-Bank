using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATM_Bank_Final
{
    public class Transaction
    {
        public string? Type { get; set; }
        public double Amount { get; set; }
        public string AccountName { get; set; } = string.Empty;
        public DateTime Timestamp { get; set; }
    }
}
