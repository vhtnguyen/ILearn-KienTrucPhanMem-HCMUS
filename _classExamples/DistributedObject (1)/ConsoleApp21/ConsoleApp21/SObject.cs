using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleApp21
{
    using System;
    using System.Collections.Generic;

    public class SObject
    {
        public Dictionary<string, string> attributes =
            new Dictionary<string, string>();
        private bool bAutoAddNew= true;
        private int iD; // handle

        public int ID { get => iD; set => iD = value; }

        public SObject()
        {
            iD = SObjectManager.Register(this);
        }

        // Method to get the value of an attribute by name
        public string GetAttributeValue(string attributeName)
        {
            if (attributes.ContainsKey(attributeName))
            {
                return attributes[attributeName];
            }
            else
            {
                return string.Empty;
            }
        }


        public string SetAttributeValue(string attributeName, string strValue)
        {
            if (attributes.ContainsKey(attributeName))
            {
                string strOldValue = attributes[attributeName];
                attributes[attributeName]= strValue;
                return strOldValue;
            }
            else if (bAutoAddNew)
            {
                attributes.Add(attributeName, strValue);
                return String.Empty;
            }
            return String.Empty;
        }

        public virtual bool ExecuteMethod(string methodName, string inputParams, ref string outputParams)
        {
            outputParams = String.Empty;
            return false;
        }
    }
}