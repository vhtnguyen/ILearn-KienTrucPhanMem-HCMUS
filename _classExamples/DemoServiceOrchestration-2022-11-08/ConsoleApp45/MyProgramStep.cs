using System;
using System.Collections.Generic;

namespace ConsoleApp45
{
    public class MyProgramStep
    {
        public string strFunctionName;
        public List<VariableMapping> inputmapping, outputmapping;
        internal VariableDictionary Execute(VariableDictionary input)
        {
            MyFunction func = MyFunction.GetInstance(strFunctionName);
            return func.Execute(input);
        }
    }
}