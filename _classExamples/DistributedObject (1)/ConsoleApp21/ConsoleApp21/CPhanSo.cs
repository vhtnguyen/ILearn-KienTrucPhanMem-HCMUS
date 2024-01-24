using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleApp21
{
    public class CPhanSo : CObject
    {
        public CPhanSo()
        {
            this.ID = CObjectManager.CreateRemoteObject("SFraction");
            this.TuSo = 0;
            this.MauSo = 1;
        }

        public CPhanSo(int tuso, int mauso)
        {
            this.ID = CObjectManager.CreateRemoteObject("SFraction");
            this.TuSo = tuso;
            this.MauSo = mauso;
        }

        public int TuSo
        {
            get
            {
                return int.Parse(this.GetAttributeValue("Numerator"));
            }

            set
            {
                this.SetAttributeValue("Numerator", value.ToString());
            }
        }

        public int MauSo
        {
            get
            {
                return int.Parse(this.GetAttributeValue("Denominator"));
            }

            set
            {
                this.SetAttributeValue("Denominator", value.ToString());
            }
        }

        internal double GiaTri()
        {
            string outputParams = String.Empty;
            this.ExecuteMethod("Get Value", String.Empty, ref outputParams);
            return double.Parse(outputParams);
        }

        internal bool GiaTriLonHon(double x)
        {
            string outputParams = String.Empty;
            this.ExecuteMethod("Is Greater Than", x.ToString(), ref outputParams);
            return bool.Parse(outputParams);
        }
    }
}