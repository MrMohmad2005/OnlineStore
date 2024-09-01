using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datebase
{
    internal abstract class Products_Comments : Database
    {
        /// <summary>
        /// the owner of this item
        /// </summary>
        public string OwnerID {  get; set; }
        /// <summary>
        /// the evaluation of this item
        /// </summary>
        public string Evaluation {  get; set; }

        public Products_Comments(string name, string id) : base(name, id) { }
        public Products_Comments(string name, string id, string ownerid) : this(name, id) { OwnerID = ownerid; }
        public Products_Comments(string name, string id, string ownerid, string evaluation) : this(name, id, ownerid) { Evaluation = evaluation; }
    }
}
