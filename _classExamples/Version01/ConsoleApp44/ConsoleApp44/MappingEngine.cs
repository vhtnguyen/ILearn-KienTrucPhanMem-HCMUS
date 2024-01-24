using System;
using System.Collections.Generic;

namespace ConsoleApp44
{
    public class MappingEngine
    {
        public virtual bool Execute(
            MyObject sourceObject, 
            string[] sourceAttributeNames, 
            MyObject targetObject, 
            string[] targetAttributeNames)
        {
            return true;
        }

        private static Dictionary<string, MappingEngine> instances = new Dictionary<string, MappingEngine>();

        static MappingEngine()
        {            
            instances.Add("ConcatenateStringsMapping", new ConcatenateStringsMapping());
            instances.Add("One2OneMapping", new One2OneMapping());
            instances.Add("CopyAllMapping", new CopyAllMapping());
        }

        internal static MappingEngine FromName(string strEngineName)
        {
            if (instances.ContainsKey(strEngineName))
                return instances[strEngineName];
            return null;
        }


    }
}