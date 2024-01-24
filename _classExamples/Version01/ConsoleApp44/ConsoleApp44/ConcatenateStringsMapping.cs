using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleApp44
{
    public class ConcatenateStringsMapping : MappingEngine
    {
        public override bool Execute(MyObject sourceObject, string[] sourceAttributeNames, MyObject targetObject, string[] targetAttributeNames)
        {
            if (sourceAttributeNames.Length == 0)
                return false;
            if (targetAttributeNames.Length != 1)
                return false;

            try
            {
                string result = (string)sourceObject[sourceAttributeNames[0]];

                int n = sourceAttributeNames.Length;
                for (int i = 1; i < n; i++)
                    result += " " + sourceObject[sourceAttributeNames[i]];

                targetObject[targetAttributeNames[0]] = result;
            }
            catch(Exception)
            {
                return false;
            }
            return true;
        }
    }
}