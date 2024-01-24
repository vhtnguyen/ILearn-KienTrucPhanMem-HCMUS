using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleApp45
{
    public class MyFunction
    {
        private static Dictionary<string, MyFunction> functions = 
            new Dictionary<string, MyFunction>();

        static MyFunction()
        {
            functions = new Dictionary<string, MyFunction>();
            functions.Add("InputAnInteger", new InputAnInteger());
            functions.Add("OutputAnInteger", new OutputAnInteger());
            functions.Add("MultiplyTwoIntegers", new MultiplyTwoIntegers());
            functions.Add("MaxTwoIntegers", new MaxTwoIntegers());

        }

        internal static MyFunction GetInstance(string strFunctionName)
        {
            return functions[strFunctionName];
        }

        internal static void AddFunction(string v, MyCompositeFunction f)
        {
            functions.Add(v, f);
        }

        public virtual VariableDictionary Execute(VariableDictionary input)
        {
            return new VariableDictionary();
        }


    }
}