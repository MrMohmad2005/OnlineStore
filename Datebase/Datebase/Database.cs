using System.Runtime.CompilerServices;

namespace Datebase
{
    public class Database
    {
        /// <summary>
        /// this is the path of the database
        /// </summary>
        public string Path { get; set; }
        /// <summary>
        /// you will not need it, it's just for inheret.
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// you will not need it, it's just for inheret.
        /// </summary>
        public string ID { get; set; }
        public Database(string name)
        {
            Name = name;
            Path = Directory.GetParent(AppDomain.CurrentDomain.BaseDirectory).Parent.Parent.Parent.Parent.FullName;
        }
        public Database(string name, string path) : this(name)
        {
            Path = path;
        }
        public Database(string name, string id, string path) : this(name, id) 
        {
            Path += path + "\\" + name;
        }
    }
}