using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datebase
{
    internal class Costomer : User
    {
        public Costomer(string name, string id) : base(name, id)
        {
            Path += "\\Costomers";
        }
    }
}
