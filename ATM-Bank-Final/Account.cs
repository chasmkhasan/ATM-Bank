using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATM_Bank_Final
{
    public class Account
    {
        public string AccountName { get; set; }
        public double Balance { get; set; }
        public List<Transaction> Transactions { get; set; }
        public Account()
        {
            Transactions = new List<Transaction>();
        }

    }
}
