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
            List<List<int>> nextGenerationGrid = inputReader.Read2DListFromFile();
            if (nextGenerationGrid.Count == 0)
            {
                Environment.Exit(-1);
            }
            int counter = 500000;
            while (counter > 0)
            {
                Console.Clear();
                Grid grid = new Grid(nextGenerationGrid);
                nextGenerationGrid = grid.NextGeneration();
                if (nextGenerationGrid.Count == 0) 
                {
                    Environment.Exit(-1);
                }
                new Grid(nextGenerationGrid).Print();

                counter--;

                Thread.Sleep(1000);
            }
            Console.ReadKey();
        }
    }
}
