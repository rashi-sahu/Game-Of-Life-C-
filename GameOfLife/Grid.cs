namespace GameOfLife
{
    using System;
    using System.Collections.Generic;

    public class Grid
     {
        private int row;
        private int column;
        private List<List<int>> grid;

        public Grid(List<List<int>> grid)
        {
            this.row = grid.Count;
            this.column = grid.Count != 0 ? grid[0].Count : 0;
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
                        {
                            Console.Write(".");
                        }
                        else
                        {
                            Console.Write("*");
                        }
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
            this.column = grid.Count != 0 ? grid[0].Count : 0;
            List<List<int>> gridCopy = GenerateDeepCopyOfGrid();
            this.grid = CalculateNextGenerationCells(gridCopy);
            List<List<int>> nextGenerationGrid = CompressGrid();

            return nextGenerationGrid;
        }

        private List<List<int>> ExpandGrid()
        {
            if (grid.Count > 0)
            {
                List<List<int>> expandedGrid = new List<List<int>>();
                for (int i = 0; i < grid.Count + 2; i++)
                {
                    List<int> expandedGridRows = new List<int>();
                    for (int j = 0; j < grid[0].Count + 2; j++)
                    {
                        expandedGridRows.Add(0);
                    }

                    expandedGrid.Add(expandedGridRows);
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
                    {
                        grid[l][m] = 0;
                    }
                    else if ((gridCopy[l][m] == 1) && (aliveNeighbours > 3))
                    {
                        grid[l][m] = 0;
                    }
                    else if ((gridCopy[l][m] == 0) && (aliveNeighbours == 3))
                    {
                        grid[l][m] = 1;
                    }
                    else
                    {
                        grid[l][m] = gridCopy[l][m];
                    }
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

        private List<List<int>> CompressGrid()
        {
            this.grid = DeleteFromTop();
            this.grid = DeleteFromBottom();
            this.grid = DeleteFromLeft();
            this.grid = DeleteFromRight();
            return this.grid;
        }

        private List<List<int>> DeleteFromTop()
        {
            List<List<int>> gridCopy = GenerateDeepCopyOfGrid();

            for (int i = 0; i < this.grid.Count; i++)
            {
                for (int j = 0; j < this.grid[0].Count; j++)
                {
                    if (this.grid[i][j] == 1)
                    {
                        return gridCopy;
                    }
                }

                gridCopy.RemoveAt(0);
            }

            return gridCopy;
        }

        private List<List<int>> DeleteFromBottom()
        {
            List<List<int>> gridCopy = GenerateDeepCopyOfGrid();

            for (int i = this.grid.Count - 1; i >= 0; i--)
            {
                for (int j = this.grid[0].Count - 1; j >= 0; j--)
                {
                    if (this.grid[i][j] == 1)
                    {
                        return gridCopy;
                    }
                }

                gridCopy.RemoveAt(gridCopy.Count - 1);
            }

            return gridCopy;
        }

        private List<List<int>> DeleteFromLeft()
        {
            List<List<int>> gridCopy = GenerateDeepCopyOfGrid();
            if (grid.Count > 0)
            {
                int columnsToBeRemoved = FindColumnFromLeftToRemoveFromGrid();

                for (int j = 0; j < columnsToBeRemoved; j++)
                {
                    for (int i = 0; i < this.grid.Count; i++)
                    {
                        gridCopy[i].RemoveAt(0);
                    }
                }

                return gridCopy;
            }
            else
            {
                return new List<List<int>>();
            }
        }

        private List<List<int>> DeleteFromRight()
        {
            List<List<int>> gridCopy = GenerateDeepCopyOfGrid();
            if (grid.Count > 0)
            {
                int columnsToBeRemoved = FindColumnFromRightToRemoveFromGrid();
                for (int j = this.grid[0].Count - 1; j > columnsToBeRemoved; j--)
                {
                    for (int i = this.grid.Count - 1; i >= 0; i--)
                    {
                        gridCopy[i].RemoveAt(gridCopy[0].Count - 1);
                    }
                }

                return gridCopy;
            }
            else
            {
                return new List<List<int>>();
            }
        }

        private int FindColumnFromLeftToRemoveFromGrid()
        {
            for (int j = 0; j < this.grid[0].Count; j++)
            {
                for (int i = 0; i < this.grid.Count; i++)
                {
                    if (this.grid[i][j] == 1)
                    {
                        return j;
                    }
                }
            }

            return this.grid[0].Count;
        }

        private int FindColumnFromRightToRemoveFromGrid()
        {
            for (int j = this.grid[0].Count - 1; j >= 0; j--)
            {
                for (int i = this.grid.Count - 1; i >= 0; i--)
                {
                    if (this.grid[i][j] == 1)
                    {
                        return j;
                    }
                }
            }

            return -1;
        }
     }
}
