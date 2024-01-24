using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleApp21
{
    public class SFraction : SObject
    {
        public bool IsPositive()
        {
            int numerator, denominator;
            numerator = int.Parse(this.GetAttributeValue("Numerator"));
            denominator = int.Parse(this.GetAttributeValue("Denominator"));
            return numerator * denominator > 0;
        }

        public double GetValue()

        {
            int numerator, denominator;
            numerator = int.Parse(this.GetAttributeValue("Numerator"));
            denominator = int.Parse(this.GetAttributeValue("Denominator"));
            return 1.0*numerator / denominator;
        }

        public bool IsGreaterThan(double x)
        {
            return GetValue() > x;
        }
        public override bool ExecuteMethod(string methodName, string inputParams, ref string outputParams)
        {
            outputParams = String.Empty;
            
            switch(methodName)
            {
                case "Is Positive":
                    outputParams = IsPositive().ToString();
                    return true;                    
                case "Get Value":
                    outputParams = GetValue().ToString();
                    return true;
                case "Is Greater Than":
                    double x = double.Parse(inputParams);
                    outputParams = IsGreaterThan(x).ToString();
                    return true;
            }
            return base.ExecuteMethod(methodName, inputParams, ref outputParams);
        }
    }
}