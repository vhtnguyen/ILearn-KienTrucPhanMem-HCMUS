using System;
using System.Drawing;

namespace creationalPrototype.Board
{
    public class Board
    {
        public const int NO_OF_ROWS = 8;
        public const int NO_OF_COLUMNS = 8;

        private readonly Cell[,] board;

        public Board()
        {
            board = new Cell[NO_OF_ROWS, NO_OF_COLUMNS];
            Cell cell;
            for (int row = NO_OF_ROWS - 1; row >= 0; row--)
            {
                for (int col = NO_OF_COLUMNS - 1; col >= 0; col--)
                {
                    if ((row + col) % 2 == 0)
                    {
                        cell = CellFactory.GetCell(Color.WHITE);
                    }
                    else
                    {
                        cell = CellFactory.GetCell(Color.BLACK);
                    }
                    cell.SetCoordinate($"{row}x{col}");
                    board[row, col] = cell;
                }
            }
        }

        public void Print()
        {
            for (int row = 0; row < NO_OF_ROWS; row++)
            {
                for (int col = 0; col < NO_OF_COLUMNS; col++)
                {
                    Console.Write(board[row, col] + " ");
                }
                Console.WriteLine();
            }
        }
    }
}
