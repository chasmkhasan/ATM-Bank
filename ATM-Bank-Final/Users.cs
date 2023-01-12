using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATM_Bank_Final
{
    public class Users
    {
        public string userName { get; set; }
        public int pin { get; set; }
        public List<Account> accounts { get; set; }
    }
}
