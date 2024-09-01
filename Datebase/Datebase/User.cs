using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Datebase
{
    internal abstract class User : Database
    {
        public User(string name, string id) : base(name, id)
        {
            Path += "\\Users";
        }
    }
}
