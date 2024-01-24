// See https://aka.ms/new-console-template for more information

using ConsoleApp19;


MyObject sv1 = new MyObject("Sinh Vien");

MyObject sv = new MyObject();
sv["MSSV"] = "20120123";
sv["Ho"] = "Nguyen";
sv["Chu lot"] = "Van";
sv["Ten"] = "A";
sv["DTB"] = (double)(9.87);
Console.WriteLine(sv["Ho"] + " " + sv["Chu lot"] + " " + sv["Ten"]);