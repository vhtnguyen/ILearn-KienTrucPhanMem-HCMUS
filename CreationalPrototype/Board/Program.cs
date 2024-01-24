using System;

/*
 Một bàn cờ vua gồm có: 8 hàng (row) và 8 cột (column). Tương ứng với hàng và cột là các ô (cell) được tô màu đen (black) và trắng (white). */

namespace creationalPrototype.Board
{
    public class Program 
    {
        static void Main(string[] args)
        {
            long startTime = DateTimeOffset.Now.ToUnixTimeMilliseconds();

            Board chessBoard = new Board();

            long endTime = DateTimeOffset.Now.ToUnixTimeMilliseconds();

            Console.WriteLine("Time taken to create a board: " + (endTime - startTime) + " millis");

            chessBoard.Print();
        }
    }
}
