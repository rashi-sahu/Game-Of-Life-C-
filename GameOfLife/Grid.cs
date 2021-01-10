using System;
using System.Collections.Generic;

namespace GameOfLife
{
     class Grid
     {
        private int row;
        private int column;
        private List<List<int>> grid;

        public Grid(List<List<int>> grid)
        {
            this.row = grid.Count;
            this.column = grid[0].Count;
            this.grid = grid;
        }

        public void Print()
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

        public List<List<int>> NextGeneration()
        {
            this.grid = ExpandGrid();

            return this.grid;
        }

        private List<List<int>> ExpandGrid()
        {
            if (grid.Count > 0)
            {
                List<List<int>> expandedGrid = new List<List<int>>();
                for (int i = 0; i < grid.Count + 2; i++)
                {
                    List<int> row = new List<int>();
                    for (int j = 0; j < grid[0].Count + 2; j++)
                    {
                        row.Add(0);
                    }
                    expandedGrid.Add(row);
                }

                for (int i = 1; i < expandedGrid.Count - 1; i++)
                {
                    for (int j = 1; j < expandedGrid[0].Count - 1; j++)
                    {
                        expandedGrid[i][j] = grid[i - 1][j - 1];
                    }
                }
                return expandedGrid;
            }
            else
            {
                return new List<List<int>>();
            }
        }
     }
}
