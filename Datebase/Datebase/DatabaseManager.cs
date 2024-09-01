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
        public DatabaseManager(string name) { Path = Directory.GetParent(AppDomain.CurrentDomain.BaseDirectory).Parent.Parent.Parent.Parent.FullName + "\\" + name; }
        public DatabaseManager(string name, string path) : this(name) { Path = path; }
        static void Creatdirs(string path, string name)
        {
            string Database = path + "\\" + name;
            string[] dirs = { "", "\\Costomers", "\\Seller", "\\Products", "\\Comments" };
            for (int i = 0; i < dirs.Length; i++)
            {
                Directory.CreateDirectory(Database + dirs[i] + Console.ReadLine());
                if (i > 0)
                {
                    using (FileStream fs = File.Create(Database + dirs[i] + @"\counter.txt")) 
                    {
                        using (StreamWriter streamWriter = new StreamWriter(Database + dirs[i] + @"\counter.txt"))
                        { streamWriter.WriteLine("0"); }
                    }
                }
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
        /// <summary>
        /// هي الدالة من شان تنسخ الملفات من أي مكان علكمبيوتر لأي مكان تاني، راح نستخدمها من شان نسخ الملفات من الجمبيوتر يلي عنا لقاعدة البيانات تبعنا.
        /// </summary>
        /// <param name="sourceFIlePath">الملف يلي بدنا ننسخو</param>
        /// <param name="path">المكان يلي بدي أنسخو لعندو</param>
        public void AddFile(string sourceFIlePath, string path)
        {
            string last = ".";
            {
                string[] s = path.Split("\\");
                string[] ss = s[s.Length - 1].Split(".");
                last += ss[ss.Length - 1];
            }
            File.Copy(sourceFIlePath, path + last);
        }
        /// <summary>
        /// الدالة المستخدمة لإضافة مستخدم للقاعدة.
        /// بالنسبة للملف النصي للمستخدم وللتاجر زللمنتج راح يكون ترتيب السطور هو أنو أول سطر للاسم والتاني للعنوان.
        /// </summary>
        /// <param name="username">اسم المستخدم</param>
        /// <param name="type">نوع المستخدم إذا كان مستخدم عادي أو تاجر
        /// للسنتخدم العادي بتكتب : Costomers
        /// للتاجر بتكتب Seller
        /// </param>
        public void AddUserInfo(string username, string type)
        {
            string id = File.ReadLines(Path + "\\" + type + "\\counter.txt").First();
            Directory.CreateDirectory(Path + "\\" + type + "\\" + id);
            using (FileStream fs = File.Create(Path + "\\" + type + "\\" + id + "info.txt")) { }
            using (FileStream fs = File.Create(Path + "\\" + type + "\\" + id + "comments.txt")) { }
            using (StreamWriter streamWriter = new StreamWriter(Path + "\\" + type + "\\" + id + "info.txt"))
            {
                streamWriter.WriteLine(username);
                streamWriter.WriteLine(id);
            }
            string[] s = { id };
            File.WriteAllLines(Path + "\\" + type + "\\counter.txt", s);
        }
        public void AddUserInfo(string username, string type, string selfie)
        {
            AddUserInfo(username, type);
            AddFile(selfie, Path +  "\\" + type + "\\" + (int.Parse(File.ReadLines(Path + "\\" + type + "\\counter.txt").First()) - 1));
        }
    }
}
