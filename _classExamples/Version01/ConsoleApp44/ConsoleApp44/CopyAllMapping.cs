using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleApp44
{
    public class CopyAllMapping : MappingEngine
    {
        public override bool Execute(MyObject sourceObject, string[] sourceAttributeNames, MyObject targetObject, string[] targetAttributeNames)
        {
            if (sourceAttributeNames.Length == 0)
                return false; // true?

            if (sourceAttributeNames.Length != targetAttributeNames.Length)
                return false;
            try
            {

                int n = sourceAttributeNames.Length;
                for (int i = 0; i < n; i++)
                    targetObject[targetAttributeNames[i]]
                        = sourceObject[sourceAttributeNames[i]];
            }
            catch(Exception)
            {
                return false;
            }
            return true;
        }
    }
}