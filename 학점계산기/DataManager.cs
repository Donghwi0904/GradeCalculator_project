using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace 학점계산기
{
    class DataManager
    {
        public static List<User> Users = new List<User>();

        static DataManager()
        {
            Load();
        }
        public static void Load()
        {
            try
            {
                string usersOutput = File.ReadAllText(@"./Users.xml");
                XElement usersXElement = XElement.Parse(usersOutput);
                Users = (from item in usersXElement.Descendants("user")
                         select new User()
                         {
                             Id = item.Element("id").Value,
                             Name = item.Element("name").Value,
                             GPA = double.Parse(item.Element("gpa").Value)
                         }).ToList<User>();
            }
            catch (FileNotFoundException exception)
            {
                Save();
            }
        }

        public static void Save()
        {
            string usersOutput = "";
            usersOutput += "<users>\n";
            foreach (var item in Users)
            {
                usersOutput += "<user>\n";
                usersOutput += "    <id>" + item.Id + "</id>\n";
                usersOutput += "    <name>" + item.Name + "</name>\n";
                usersOutput += "    <gpa>" + item.GPA + "</gpa>\n";
                usersOutput += "</user>\n";
            }
            usersOutput += "</users>";

            File.WriteAllText(@"./Users.xml", usersOutput);
        }
    }
}
