namespace ConsoleApp45
{
    internal class MultiplyTwoIntegers : MyFunction
    {
        public override VariableDictionary Execute(VariableDictionary input)
        {
            int x = int.Parse(input["v1"]);
            int y = int.Parse(input["v2"]);
            VariableDictionary output = new VariableDictionary();
            output["v1"] = (x * y).ToString();
            return output;
        }
    }
}