using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using GameOfLife;

namespace GameOfLifeTests
{
    [TestClass]
    public class GridTests
    {
        [TestMethod]
        public void ShouldReturnCompressedNextGenerationGrid()
        {
            List<List<int>> inputGrid = new List<List<int>>();
            inputGrid.Add(new List<int>() { 0, 0, 0, 0, 0 });
            inputGrid.Add(new List<int>() { 0, 0, 1, 0, 0 });
            inputGrid.Add(new List<int>() { 0, 0, 1, 0, 0 });
            inputGrid.Add(new List<int>() { 0, 0, 1, 0, 0 });
            inputGrid.Add(new List<int>() { 0, 0, 0, 0, 0 });

            List<List<int>> expectedGrid = new List<List<int>>(){
                new List<int>() {1, 1, 1}
            };

            Grid grid = new Grid(inputGrid);
            List<List<int>> actualGrid = grid.NextGeneration();

            Assert.AreEqual(expectedGrid.Count, actualGrid.Count);
            CollectionAssert.AreEqual(expectedGrid[0], actualGrid[0]);
        }

        [TestMethod]
        public void ShouldReturnEmptyNextGenerationForEmptyInputGrid()
        {
            List<List<int>> inputGrid = new List<List<int>>();

            Grid grid = new Grid(inputGrid);
            List<List<int>> actualGrid = grid.NextGeneration();

            Assert.AreEqual(0, actualGrid.Count);
        }

        [TestMethod]
        public void ShouldReturnNextGenerationGrid()
        {
            List<List<int>> inputGrid = new List<List<int>>();
            inputGrid.Add(new List<int>() { 1, 0, 0, 0, 1 });
            inputGrid.Add(new List<int>() { 0, 0, 1, 0, 0 });
            inputGrid.Add(new List<int>() { 0, 1, 1, 0, 0 });
            inputGrid.Add(new List<int>() { 0, 1, 1, 0, 0 });

            List<List<int>> expectedGrid = new List<List<int>>(){
                new List<int>() { 0, 1, 1 },
                new List<int>() { 0, 0, 1 },
                new List<int>() { 1, 1, 0 }
            };

            Grid grid = new Grid(inputGrid);
            List<List<int>> actualGrid = grid.NextGeneration();

            Assert.AreEqual(expectedGrid.Count, actualGrid.Count);
            CollectionAssert.AreEqual(expectedGrid[0], actualGrid[0]);
            CollectionAssert.AreEqual(expectedGrid[1], actualGrid[1]);
            CollectionAssert.AreEqual(expectedGrid[2], actualGrid[2]);
        }
    }
}
