using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datebase
{
    /// <summary>
    /// all methods that you will need to manage our seak database is here, creat a database is a static method and all the other methods are working with an instans of thes class.
    /// </summary>
    internal class DatabaseManager
    {
        /// <summary>
        /// the database you are managing.
        /// </summary>
        public Database Database { get; set; }
        public DatabaseManager(string name) { Database = new Database(name); }

        static void Creatdirs(string path, string name)
        {
            Directory.CreateDirectory(path + "\\" + name);
            Directory.CreateDirectory(path + "\\" + name + "\\Users");
            Directory.CreateDirectory(path + "\\" + name + "\\Users\\Costomers");
            Directory.CreateDirectory(path + "\\" + name + "\\Users\\Seller");
            Directory.CreateDirectory(path + "\\" + name + "\\Products");
            Directory.CreateDirectory(path + "\\" + name + "\\Products\\Photos");
            Directory.CreateDirectory(path + "\\" + name + "\\Products\\Coppons");
        }
        public static Database CreatDateBase(string path, string name)
        {
            Creatdirs(path, name);
            return new Database(path, name);
        }
        public static Database CreatDateBase(string path, string name, string id)
        {
            Creatdirs(path, name);
            return new Database(path, name, id);
        }
    }
}
