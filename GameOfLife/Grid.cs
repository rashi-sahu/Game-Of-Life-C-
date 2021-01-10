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
            this.row = this.grid.Count;
            this.column = this.grid[0].Count;
            List<List<int>> gridCopy = GenerateDeepCopyOfGrid();
            this.grid = CalculateNextGenerationCells(gridCopy);

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

        private List<List<int>> GenerateDeepCopyOfGrid()
        {
            List<List<int>> gridCopy = new List<List<int>>();
            for (int index = 0; index < grid.Count; index++)
            {
                gridCopy.Add(new List<int>(this.grid[index]));
            }
            return gridCopy;
        }

        private List<List<int>> CalculateNextGenerationCells(List<List<int>> gridCopy)
        {
            for (int l = 0; l < this.row; l++)
            {
                for (int m = 0; m < this.column; m++)
                {
                    int aliveNeighbours = CountAliveNeighbours(gridCopy, l, m);
                    if ((gridCopy[l][m] == 1) && (aliveNeighbours < 2))
                        grid[l][m] = 0;

                    else if ((gridCopy[l][m] == 1) && (aliveNeighbours > 3))
                        grid[l][m] = 0;

                    else if ((gridCopy[l][m] == 0) && (aliveNeighbours == 3))
                        grid[l][m] = 1;

                    else
                        grid[l][m] = gridCopy[l][m];
                }
            }

            return grid;
        }

        private int CountAliveNeighbours(List<List<int>> gridCopy, int x, int y)
        {
            int aliveNeighbours = 0;

            if (this.row > 0)
            {
                for (int i = -1; i <= 1; i++)
                {
                    for (int j = -1; j <= 1; j++)
                    {
                        if (CheckValidCell(x + i, y + j))
                        {
                            aliveNeighbours += gridCopy[x + i][y + j];
                        }
                    }
                }
                aliveNeighbours -= gridCopy[x][y];
            }

            return aliveNeighbours;
        }

        private bool CheckValidCell(int x, int y)
        {
            if (x >= 0 && x < this.row && y >= 0 && y < this.column)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
