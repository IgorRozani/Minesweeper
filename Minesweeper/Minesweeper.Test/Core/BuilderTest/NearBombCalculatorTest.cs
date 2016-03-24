using FluentAssertions;
using Minesweeper.Core;
using Minesweeper.Core.Builder;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Minesweeper.Test.Core.BuilderTest
{
    [TestFixture]
    public class NearBombCalculatorTest
    {
        private Cell[,] sourceCells;
        private Cell[,] expectedCells;
        private NearBombCalculator nearBombCalculator;

        [SetUp]
        public void InitializeTests()
        {
            sourceCells = new Cell[3, 3];
            sourceCells[0, 0] = new Cell();
            sourceCells[0, 1] = new Cell();
            sourceCells[0, 2] = new Cell();
            sourceCells[1, 0] = new Cell();
            sourceCells[1, 1] = new Cell();
            sourceCells[1, 2] = new Cell();
            sourceCells[2, 0] = new Cell();
            sourceCells[2, 1] = new Cell();
            sourceCells[2, 2] = new Cell();

            expectedCells = new Cell[3, 3];
            expectedCells[0, 0] = new Cell();
            expectedCells[0, 1] = new Cell();
            expectedCells[0, 2] = new Cell();
            expectedCells[1, 0] = new Cell();
            expectedCells[1, 1] = new Cell();
            expectedCells[1, 2] = new Cell();
            expectedCells[2, 0] = new Cell();
            expectedCells[2, 1] = new Cell();
            expectedCells[2, 2] = new Cell();

            nearBombCalculator = new NearBombCalculator();
        }

        [Test]
        public void NearBombCalculatorCalculateABombInFirstPosition()
        {
            sourceCells[0, 0].SetBomb();

            expectedCells[0, 0].SetBomb();
            expectedCells[0, 1].SetQuantityBombsNear(1);
            expectedCells[1, 0].SetQuantityBombsNear(1);
            expectedCells[1, 1].SetQuantityBombsNear(1);

            
            var calculateCells = nearBombCalculator.Calculate(sourceCells);
            calculateCells.ShouldBeEquivalentTo(expectedCells);
        }
    }
}
