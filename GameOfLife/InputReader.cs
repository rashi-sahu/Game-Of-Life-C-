﻿namespace GameOfLife
{
    using System;
    using System.Collections.Generic;
    using System.IO;

    internal class InputReader
    {
        public List<List<int>> Read2DListFromFile()
        {
            string path = Path.Combine(Directory.GetCurrentDirectory(), "\\GameOfLife\\GameOfLife\\Input.txt");
            string[] text = null;
            try
            {
                text = File.ReadAllLines(path);
            }
            catch (Exception ex)
            {
                Console.Write(ex.Message);
                Console.ReadKey();
                Environment.Exit(-1);
            }

            List<List<int>> grid = ConvertStringArrayTo2DIntegerList(text);

            return grid;
        }

        private List<List<int>> ConvertStringArrayTo2DIntegerList(string[] text)
        {
            int cell = 0;
            List<List<int>> grid = new List<List<int>>();
            foreach (string lines in text)
            {
                List<int> row = new List<int>();
                foreach (char charater in lines)
                {
                    cell = charater - '0';
                    if (cell == 0 || cell == 1)
                    {
                        row.Add(cell);
                    }
                    else
                    {
                        return new List<List<int>>();
                    }
                }

                grid.Add(row);
            }

            return grid;
        }
    }
}
