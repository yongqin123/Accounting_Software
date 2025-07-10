using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountingSoftware
{
    public class Account
    {
        public int Id {  get; set; }
        public string name { get; set; }
        public string type { get; set; }
        public double amount { get; set; }

        public Account(int id, string Name, string Type, double Amount) {
            Id = id;
            name = Name;
            type = Type;
            amount = Amount;
        }
     }
}
