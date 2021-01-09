using System;
using System.Threading;
using System.Collections.Generic;

namespace GameOfLife
{
    public class Program
    {
        static void Main(string[] args)
        {
            InputReader inputReader = new InputReader();
            List<List<int>> nextGen = inputReader.Read2DListFromFile();
            if (nextGen.Count == 0)
            {
                System.Environment.Exit(-1);
            }
            int counter = 5;
            while (counter > 0)
            {
                Console.Clear();
                PrintGrid printGrid = new PrintGrid();
                printGrid.Print(nextGen);

                counter--;

                Thread.Sleep(1000);
            }
            Console.ReadKey();
        }
    }
}
