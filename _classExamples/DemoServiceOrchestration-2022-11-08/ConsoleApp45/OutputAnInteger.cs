using System;

namespace ConsoleApp45
{
    internal class OutputAnInteger : MyFunction
    {
        public override VariableDictionary Execute(VariableDictionary input)
        {
            int x = int.Parse(input["v1"]);
            Console.WriteLine(x.ToString());
            VariableDictionary output = new VariableDictionary();
            return output;
        }
    }
}