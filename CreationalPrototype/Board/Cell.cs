using System;
using System.Threading;

namespace creationalPrototype.Board
{
    public class Cell : ICloneable
    {
        private string color;
        private string coordinate;


        public Cell(string color)
        {
            // Do more time to create a cell
            this.color = color;
            try
            {
                Thread.Sleep(10);
            }
            catch (ThreadInterruptedException e)
            {
                Console.WriteLine(e.StackTrace);
            }
        }

        public void SetCoordinate(string coordinate)
        {
            this.coordinate = coordinate;
        }

        public override string ToString()
        {
            return $"Cell [color={color}, coordinate={coordinate}]";
        }

        public object? Clone()
        {
            try
            {
                return MemberwiseClone();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.StackTrace);
            }
            return null;
        }
    }
}
