using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleApp45
{
    public class VariableDictionary
    {
        
        public Dictionary<string, string> variables = new Dictionary<string, string>();
        public bool bAddNew = true;
        public string this[string strVarName]
        {
            get
            {
                if (variables.ContainsKey(strVarName))
                    return variables[strVarName];
                return "";
            }
            set
            {
                if (variables.ContainsKey(strVarName))
                    variables[strVarName] = value;
                else
                    variables.Add(strVarName, value);
            }
        }
    }
}