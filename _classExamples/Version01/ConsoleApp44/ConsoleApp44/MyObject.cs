using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleApp44
{
    public class MyObject
    {
        private AttributeList attributes = new AttributeList();

        public object this[string strAttributeName]
        {
            get
            {
                return attributes[strAttributeName];
            }
            set
            {
                attributes[strAttributeName] = value;
            }
        }

        internal bool ContainAttribute(string strName)
        {
            return attributes.ContainAttribute(strName);
        }

        internal string[] GetAllAttributeNames()
        {
            return attributes.GetAllAttributeNames();
        }
    }
}