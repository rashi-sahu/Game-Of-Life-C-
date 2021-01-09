using Microsoft.VisualStudio.TestTools.UnitTesting;
using GameOfLife;

namespace GameOfLifeTests
{
    [TestClass]
    public class ProgramTests
    {
        [TestMethod]
        public void ShouldPrintHelloWorld()
        {
            string expectedOutput = Program.HelloWorld();
            Assert.AreSame("Helo World!", expectedOutput);
        }
    }
}
