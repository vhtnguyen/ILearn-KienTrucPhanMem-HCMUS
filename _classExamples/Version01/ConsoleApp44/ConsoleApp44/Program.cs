using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp44
{
    class Program
    {
        static void Main(string[] args)
        {
            MyObject sourceObject = new MyObject();
            MyObject targetObject = new MyObject();
            sourceObject["First Name"] = "A";
            sourceObject["Last Name"] = "Nguyen";
            sourceObject["Middle Name"] = "Van";
            sourceObject["GPA"] = 4.0;

            /*            targetObject["Ho va ten sinh vien"] = sourceObject["Last Name"] + " " +
                            sourceObject["Middle Name"] + " " +
                            sourceObject["First Name"];*/

            MappingManager mappingManager = new MappingManager();
            /* mappingManager.AddRule(
                 new string[] { "Last Name", "Middle Name", "First Name" },
                 new string[] { "Ho va ten sinh vien" },
                 "ConcatenateStringsMapping"
                 );

             mappingManager.AddRule(new string[] { "Last Name", "Middle Name" },
                                    new string[] { "Ho va chu lot" },
                                    "ConcatenateStringsMapping");
             //new ConcatenateStringsMapping());
             mappingManager.AddRule(new string[] { "First Name" },
                                    new string[] { "Ten" },
                                    "One2OneMapping");
                                     //new One2OneMapping());
             mappingManager.AddRule(new string[] { "Credit" },
                                    new string[] { "So tin chi" },
                                    "One2OneMapping");
             //new One2OneMapping());

             mappingManager.AddRule(new string[] { "Latitude" },
                                    new string[] { "Vĩ độ" },
                                    "One2OneMapping");
             //new One2OneMapping());*/

            mappingManager.LoadRulesFromFile(@"c:\Test\ConsoleApp19\rules.txt"); // not good
            mappingManager.MapObjectToObject(sourceObject, targetObject);
            string[] strNames = targetObject.GetAllAttributeNames();
            for (int i = 0; i < strNames.Length; i++)
                Console.WriteLine(strNames[i]+": "+targetObject[strNames[i]].ToString());            
        }
    }
}
