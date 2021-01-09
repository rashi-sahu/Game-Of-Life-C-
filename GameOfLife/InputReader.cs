using System.Collections.Generic;
using System.IO;

namespace GameOfLife
{
    class InputReader
    {
        private const string Path = @"D:\GameOfLife\GameOfLife\Input.txt";

        public List<List<int>> Read2DListFromFile()
        {
            string[] text = File.ReadAllLines(Path);
            List<List<int>> grid = ConvertStringArrayTo2DIntegerList(text);

            return grid;
        }

        private List<List<int>> ConvertStringArrayTo2DIntegerList(string[] text)
        {
            List<List<int>> grid = new List<List<int>>();
            foreach (string lines in text)
            {
                List<int> row = new List<int>();
                foreach (char charater in lines)
                {
                    row.Add(charater - '0');
                }
                grid.Add(row);
            }

            return grid;
        }
    }
}
