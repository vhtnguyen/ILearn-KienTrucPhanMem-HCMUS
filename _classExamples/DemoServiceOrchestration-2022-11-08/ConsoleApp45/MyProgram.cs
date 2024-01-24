using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleApp45
{
    public class MyProgram
    {
        private MyCompositeFunction processor = new MyCompositeFunction();
        public void DisplayAllVariables()
        {
            processor.DisplayAllVariables();
        }

        public bool ExecuteProgram()
        {
            processor.Execute(new VariableDictionary());
            return true;
        }

        public bool LoadProgramFromScript(string strFileName)
        {
            return processor.LoadProgramFromScript(strFileName);
        }
    }
}