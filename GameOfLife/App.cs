using System;
using System.Threading;
using System.Collections.Generic;

namespace GameOfLife
{
    class App
    {
        static void Main(string[] args)
        {
            InputReader inputReader = new InputReader();
            List<List<int>> nextGenerationGrid = inputReader.Read2DListFromFile();
            if (nextGenerationGrid.Count == 0)
            {
                Console.Write("Input pattern is wrong. Please give the correct input");
                Console.ReadKey();
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
                    Console.Write("Program Ended because next generation is an empty grid");
                    Console.ReadKey();
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
