using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp21
{
    internal class SObjectManager
    {
        private static Dictionary<int, SObject> objects = 
            new Dictionary<int, SObject>();
        private static int NextAvailableID=1;

        internal static int Register(SObject sObject)
        {
            int ID = SObjectManager.NextAvailableID++;
            objects.Add(ID, sObject);
            return ID;
        }

        public static string GetAttributeValue(int ID, string attributeName)
        {
            SObject o = FindObjectByID(ID);
            if (o != null)
            {
                return o.GetAttributeValue(attributeName);
            }
            return String.Empty;
        }

        public static string SetAttributeValue(int ID, string attributeName, string newValue)
        {
            SObject o = FindObjectByID(ID);
            if (o !=null)
            { 
                return (o.SetAttributeValue(attributeName, newValue));
            }
            return String.Empty;
        }



        private static SObject FindObjectByID(int ID)
        {
            if (objects.ContainsKey(ID))
                return objects[ID];
            return null;
        }


        public static bool ExecuteRemoteMethod(int ID, string methodName,
            string inputParams, ref string outputParams)
        {
            SObject o = FindObjectByID(ID);
            if (o != null)
            {
                return o.ExecuteMethod(methodName, inputParams, ref outputParams);
            }
            return false;
        }

        internal static int CreateObject(string typeName)
        {
            switch (typeName)
            {
                case "SFraction":
                    return new SFraction().ID;
            }
            return 0;
        }
    }
}
