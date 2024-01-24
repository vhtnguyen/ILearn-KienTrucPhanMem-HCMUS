using System;
using System.Collections.Generic;
using System.Drawing;

namespace creationalPrototype.Board
{
    public class CellFactory
    {
        private static readonly Dictionary<Color, Cell> CELL_CACHE = new Dictionary<Color, Cell>();

        private CellFactory()
        {

        }

        public static Cell GetCell(Color color)
        {
            if (!CELL_CACHE.ContainsKey(color))
            {
                Cell cell = new Cell(color.ToString());
                CELL_CACHE.Add(color, cell);
            }
            return (Cell)CELL_CACHE[color].Clone();
        }
    }
}
