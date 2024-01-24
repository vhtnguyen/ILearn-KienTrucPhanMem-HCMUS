using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleApp21
{
    public class CObject
    {
        protected int ID;
        public string this[string strAttributeName]
        {
            get
            {
                return GetAttributeValue(strAttributeName);
            }
            set
            {
                SetAttributeValue(strAttributeName, value);
            }
        }

       
        protected string  GetAttributeValue(string strAttributeName)
        {
            return CObjectManager.GetAttributeValue(ID, strAttributeName);
        }
        protected string SetAttributeValue(string strAttributeName, string newValue)
        {
            return CObjectManager.SetAttributeValue(ID, strAttributeName, newValue);
        }

        protected bool ExecuteMethod(string strMethodName, string inputParams, ref string outputParams) 
        {
            return CObjectManager.ExecuteRemoteMethod(ID, strMethodName, 
                inputParams, ref outputParams);
        }

    }
}