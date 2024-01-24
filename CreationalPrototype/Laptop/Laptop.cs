using System;

namespace creationalPrototype.Laptop
{
    public class Laptop : ICloneable
    {
        private string os;
        private string office;
        private string antivirus;
        private string browser;
        private string others;

        public Laptop(string os, string office, string antivirus, string browser, string other)
        {
            this.os = os;
            this.office = office;
            this.antivirus = antivirus;
            this.browser = browser;
            this.others = other;
        }

        public object Clone()
        {
            try
            {
                return base.MemberwiseClone();
            }
            catch (CloneNotSupportedException e)
            {
                Console.WriteLine(e.StackTrace);
            }
            return null;
        }

        public override string ToString()
        {
            return $"Laptop [os={os}, office={office}, antivirus={antivirus}, browser={browser}, others={others}]";
        }

        public void SetOthers(string others)
        {
            this.others = others;
        }
    }
}
