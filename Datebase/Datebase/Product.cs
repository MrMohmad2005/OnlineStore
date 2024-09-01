using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datebase
{
    internal class Product : Products_Comments
    {
        public string PhotosDir { get; set; }
        public string Coppons {  get; set; }
        public Product(string name, string id) : base(name, id) { PhotosDir = Path + "\\Phots"; Coppons = Path + "\\Coppons"; Path += "\\Products"; }
        public Product(string name, string id, string ownerid) : base(name, id, ownerid) { PhotosDir = Path + "\\Phots"; Coppons = Path + "\\Coppons"; Path += "\\Products"; }
        public Product(string name, string id, string ownerid, string evaluation) :base(name, id, ownerid, evaluation) { PhotosDir = Path + "\\Phots"; Coppons = Path + "\\Coppons"; Path += "\\Products"; }

    }
}
