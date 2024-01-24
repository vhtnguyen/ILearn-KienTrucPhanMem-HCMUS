using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FlexibleObject
{
    public class MyObject
    {
        private Dictionary<string, object> _attributes
            = new Dictionary<string, object>();
        private bool _bAddNew = true;


        private static Dictionary<string, MyObject> _sampleObjects
            = new Dictionary<string, MyObject>();


        static MyObject()
        {
            InitSchema("C:\\Users\\Stephen\\source\\repos\\KTPM_review\\flexibleObject\\schema.txt");
            // not a good way to code like this!
        }

        public MyObject()
        {

        }
        public static bool InitSchema(string strFilename)
        {
            try
            {
                StreamReader sr = new StreamReader(strFilename);
                int nClasses = int.Parse(sr.ReadLine());

                for (int i = 0; i < nClasses; i++)
                {
                    AddNewSampleObject(sr);
                }

                sr.Close();
            }
            catch (Exception)
            {
                return false;
            }
            return true;
        }

        private static void AddNewSampleObject(StreamReader sr)
        {
            string  sType = sr.ReadLine();
            int nAttributes = int.Parse(sr.ReadLine());
            MyObject o = new MyObject();
            for (int i = 0; i < nAttributes; i++)
            {
                string sAttributeName = sr.ReadLine();
                string sAttributeType = sr.ReadLine();
                object oValue = CreateObjectFromAttributeType(sAttributeType);
                o[sAttributeName] = oValue;
            }
            MyObject._sampleObjects.Add(sType, o);
        }

        private static object CreateObjectFromAttributeType(string sAttributeType)
        {
            switch (sAttributeType)
            {
                case "int": return (int)0;
                case "double": return (double)0.0;
                case "string": return "";
            }
            return null;
        }

        public MyObject(string strType)
        {
            //InitAttributes_Approach1_Naive(strType);// refactor
            if (MyObject._sampleObjects.ContainsKey(strType))
            {
                CloneAttributesFromObject(MyObject._sampleObjects[strType]);
            }
        }

        private void CloneAttributesFromObject(MyObject myObject)
        {
            this._attributes.Clear();
            foreach (string s in myObject._attributes.Keys)
            {
                this[s] = myObject._attributes[s];
            }
        }

        private void InitAttributes_Approach1_Naive(string strType)
        {
            switch (strType)
            {
                case "Phan So":
                    {
                        this["Tu So"] = (int)0;
                        this["Mau So"] = (int)1;
                        break;
                    };
                case "Sinh Vien":
                    {
                        this["MSSV"] = "";           // Initialize MSSV as an empty string
                        this["Ho"] = "";             // Initialize Ho as an empty string
                        this["Chu lot"] = "";        // Initialize Chu lot as an empty string
                        this["Ten"] = "";            // Initialize Ten as an empty string
                        this["Diem trung binh"] = 0.00; // Initialize Diem trung binh as 0.00 (a double)
                        break;
                    }
            }
        }

        public object GetAttributeValue(string strAttribute)
        {
            if (_attributes.ContainsKey(strAttribute))
                return _attributes[strAttribute];
            return null;
        }


        public bool SetAttributeValue(string strAttribute, object newValue)
        {
            if (_attributes.ContainsKey(strAttribute))
            {
                _attributes[strAttribute] = newValue;
                return true;
            }
            else if (_bAddNew)
            {
                _attributes.Add(strAttribute, newValue);
                return true;
            }
            return false;
        }

        public object this[string strAttribute]
        {
            get
            {
                return GetAttributeValue(strAttribute);
            }
            set
            {
                SetAttributeValue(strAttribute, value);
            }
        }


    }
}