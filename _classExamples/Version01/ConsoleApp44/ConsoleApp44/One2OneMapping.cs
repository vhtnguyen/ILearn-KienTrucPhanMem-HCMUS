using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleApp44
{
    public class One2OneMapping : MappingEngine
    {
        public override bool Execute(
            MyObject sourceObject, 
            string[] sourceAttributeNames, // 1 thuộc tính
            MyObject targetObject, 
            string[] targetAttributeNames) // 1 thuộc tính
        {
            if (sourceAttributeNames.Length != 1)
                return false;
            if (targetAttributeNames.Length != 1)
                return false;

            try
            {
                targetObject[targetAttributeNames[0]]
                    = sourceObject[sourceAttributeNames[0]];
            }
            catch(Exception)
            {
                return false;
            }
            return true;
        }
    }
}