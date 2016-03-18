using Microsoft.VisualStudio.TestTools.UnitTesting;
using Minesweeper.Model;
using Minesweeper.Model.Builder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
