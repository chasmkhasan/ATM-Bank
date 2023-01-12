using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATM_Bank_Final
{
    public class Account
    {
        public string accountName { get; set; }
        public double balance { get; set; }
        public List<Transaction> transactions { get; set; }
        public Account()
        {
            transactions = new List<Transaction>();
        }

    }
}
