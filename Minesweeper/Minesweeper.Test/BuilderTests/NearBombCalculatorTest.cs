using Microsoft.VisualStudio.TestTools.UnitTesting;
using Minesweeper.Core;
using Minesweeper.Core.Builder;

namespace Minesweeper.Test.BuilderTests
{
    [TestClass]
    public class NearBombCalculatorTest
    {
        [TestMethod]
        public void MyTestMethod()
        {
            var nearBombCalculator = new NearBombCalculator().Calculate(new Cell[12, 15]);
        }
    }
}
