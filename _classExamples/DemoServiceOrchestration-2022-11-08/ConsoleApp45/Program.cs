using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp45
{
    class Program
    {
        static void Main(string[] args)
        {
            /*            MyProgram program = new MyProgram();
                        string sPath = Console.ReadLine();
                        program.LoadProgramFromScript(sPath);
                        program.ExecuteProgram();
                        program.DisplayAllVariables();*/

            MyProgram program = new MyProgram();
            //string sPath = Console.ReadLine();

//            MyCompositeFunction func10 = new MyCompositeFunction();
            //func10.LoadProgramFromScript(@"d:\Demo0001.script");
//            MyFunction.AddFunction("Max3Integers", func10);

            program.LoadProgramFromScript(@"d:\Demo0001.script.txt");// @"c:\TempDemo\script1.txt");
            program.ExecuteProgram();
            program.DisplayAllVariables();
        }
    }
}
