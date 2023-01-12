using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATM_Bank_Final
{
    public class Transaction
    {
        public string type { get; set; }
        public double amount { get; set; }
        public string accountName { get; set; }
        public DateTime timestamp { get; set; }
    }
}
