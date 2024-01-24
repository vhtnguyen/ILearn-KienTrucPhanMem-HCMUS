using System;

namespace ConsoleApp45
{
    internal class InputAnInteger : MyFunction
    {
        public override VariableDictionary Execute(VariableDictionary input)
        {
            int x = int.Parse(Console.ReadLine());
            VariableDictionary output = new VariableDictionary();
            output["v1"] = x.ToString();
            return output;
        }
    }
}