using System;
using System.Collections.Generic;
using System.IO;
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
        /// 
        public string Path { get; set; }
        public DatabaseManager(string name) { Path = Directory.GetParent(AppDomain.CurrentDomain.BaseDirectory).Parent.Parent.Parent.Parent.FullName + "\\" + name }
        public DatabaseManager(string name, string path) : this(name) { Path = path; }
        static void Creatdirs(string path, string name)
        {
            string Database = path + "\\" + name;
            string[] dirs = { "", "\\Users", "\\Costomers", "\\Seller", "\\Products", "\\Comments" };
            for (int i = 0; i < dirs.Length; i++)
            {
                string s = Database;
                if (i < 1)
                {
                    s += dirs[i];
                    Directory.CreateDirectory(s);
                    using (FileStream fs = File.Create(s + "\\counter.txt")) { }
                    using (StreamWriter streamWriter = new StreamWriter(s + "\\counter.txt")) { streamWriter.Write("0"); }
                }
                else Directory.CreateDirectory(s);
            }
        }
        /// <summary>
        /// هي الميثود عنا ألها نسختين, وحدة مع Id والتانية بدونو، هو مالو طعمة فعليا بس حط بالخرج.
        /// هي الدالة مهمتها تساوي قاعدة البيانات بكل الملفات والمجلدات يلي راح تلزم تكون بقلبها من شان نشتغل عليها بعدين.
        /// قبل ما نبلش شغل بالقواعد لازم ننشئ قاهدة ونربطها بالبرنامج من شان يرجعلها بعدين.
        /// </summary>
        /// <param name="path">المسار يلي بدك يكون فيه مجلد القاعدة</param>
        /// <param name="name">اسم القاعدة</param>
        /// <returns>ترجع مسار القاعدة من شان تستعملو بإنشاء كائن القاعدة.</returns>
        public static string CreatDateBase(string path, string name)
        {
            Creatdirs(path, name);
            return path + "\\" + name;
        }
        /// <summary>
        /// نفس أختها بس بتنشئ القاعدة بقلب المسار اللي عم يتم تنفيذ المشروع فيه.
        /// </summary>
        /// <param name="name">اسم القاعدة</param>
        /// <returns></returns>
        public static string CreatDateBase(string name)
        {
            string path = Directory.GetParent(AppDomain.CurrentDomain.BaseDirectory).FullName;
            Creatdirs(path, name);
            return path + "\\" + name;
        }
    }
}
