using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleApp21
{
    public class CObjectManager
    {
        internal static int CreateRemoteObject(string TypeName)
        {
            return SObjectManager.CreateObject(TypeName);
        }

        internal static bool ExecuteRemoteMethod(int ID, string strMethodName, string inputParams, ref string outputParams)
        {
            return SObjectManager.ExecuteRemoteMethod(ID, strMethodName, inputParams, ref outputParams);   
        }

        internal static string GetAttributeValue(int ID, string strAttributeName)
        {
            return SObjectManager.GetAttributeValue(ID, strAttributeName);
        }

        internal static string SetAttributeValue(int ID, string strAttributeName, string  newValue)
        {
            return SObjectManager.SetAttributeValue(ID, strAttributeName, newValue);
        }
    }
}