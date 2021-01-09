using System;
using System.Collections.Generic;

namespace GameOfLife
{
     class PrintGrid
     {
         public void Print(List<List<int>> grid)
         {
            if (grid.Count > 0)
            {
                foreach (List<int> subList in grid)
                {
                    foreach (int item in subList)
                    {
                        if (item == 0)
                            Console.Write(".");
                        else
                            Console.Write("*");
                    }
                    Console.WriteLine();
                }
            }
            else
            {
                Environment.Exit(-1);
            }
         }
     }
}
