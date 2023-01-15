using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATM_Bank_Final
{
    public class Users
    {
        public string? UserName { get; set; }
        public int Pin { get; set; }
        public List<Account> Accounts { get; set; } = new List<Account>();
    }
}
