using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleApp44
{
    public class AttributeList
    {
        private Dictionary<string, object> attributes = new Dictionary<string, object>();
        public bool bAutoAddNew = true;

        public object this[string strAttributeName]
        {
            get
            {
                if (attributes.ContainsKey(strAttributeName))
                    return attributes[strAttributeName];
                else
                    return null;
            }
            set
            {
                if (attributes.ContainsKey(strAttributeName))
                {
                    attributes[strAttributeName] = value;
                }
                else if (bAutoAddNew)
                {
                    attributes.Add(strAttributeName, value);
                }
            }
        }

        internal string[] GetAllAttributeNames()
        {
            return attributes.Keys.ToArray();
        }

        internal bool ContainAttribute(string strName)
        {
            return attributes.ContainsKey(strName);
        }
    }
}