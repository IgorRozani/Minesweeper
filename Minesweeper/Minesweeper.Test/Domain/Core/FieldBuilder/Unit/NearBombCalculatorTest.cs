using FluentAssertions;
using Minesweeper.Domain.Core.FieldBuilder;
using Minesweeper.Domain.Model;
using NUnit.Framework;

namespace Minesweeper.Test.Domain.Core.FieldBuilder.Unit
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

        private void AssertValues()
        {
            var calculateCells = nearBombCalculator.Calculate(sourceCells);
            calculateCells.ShouldBeEquivalentTo(expectedCells);
        }

        [Test]
        public void NearBombCalculatorCalculateABombInFirstPosition()
        {
            sourceCells[0, 0].SetBomb();

            expectedCells[0, 0].SetBomb();
            expectedCells[0, 1].SetQuantityBombsNear(1);
            expectedCells[1, 0].SetQuantityBombsNear(1);
            expectedCells[1, 1].SetQuantityBombsNear(1);

            AssertValues();
        }

        [Test]
        public void NearBombCalculatorCalculateABombInLastPosition()
        {
            sourceCells[2, 2].SetBomb();

            expectedCells[2, 2].SetBomb();
            expectedCells[2, 1].SetQuantityBombsNear(1);
            expectedCells[1, 1].SetQuantityBombsNear(1);
            expectedCells[1, 2].SetQuantityBombsNear(1);

            AssertValues();
        }

        [Test]
        public void NearBombCalculatorCalculateABombInTheMiddle()
        {
            sourceCells[1, 1].SetBomb();

            expectedCells[1, 1].SetBomb();
            expectedCells[0, 0].SetQuantityBombsNear(1);
            expectedCells[0, 1].SetQuantityBombsNear(1);
            expectedCells[0, 2].SetQuantityBombsNear(1);
            expectedCells[1, 0].SetQuantityBombsNear(1);
            expectedCells[1, 2].SetQuantityBombsNear(1);
            expectedCells[2, 0].SetQuantityBombsNear(1);
            expectedCells[2, 1].SetQuantityBombsNear(1);
            expectedCells[2, 2].SetQuantityBombsNear(1);

            AssertValues();
        }

        [Test]
        public void NearBombCalculatorCalculateAFieldWith2Bombs()
        {
            sourceCells[0, 0].SetBomb();
            sourceCells[0, 1].SetBomb();

            expectedCells[0, 0].SetBomb();
            expectedCells[0, 1].SetBomb();
            expectedCells[0, 0].SetQuantityBombsNear(1);
            expectedCells[0, 1].SetQuantityBombsNear(1);
            expectedCells[0, 2].SetQuantityBombsNear(1);
            expectedCells[1, 0].SetQuantityBombsNear(2);
            expectedCells[1, 1].SetQuantityBombsNear(2);
            expectedCells[1, 2].SetQuantityBombsNear(1);

            AssertValues();
        }

        [Test]
        public void NearBombCalculatorCalculate8Bombs()
        {
            sourceCells[0, 0].SetBomb();
            sourceCells[0, 1].SetBomb();
            sourceCells[0, 2].SetBomb();
            sourceCells[1, 0].SetBomb();
            sourceCells[1, 2].SetBomb();
            sourceCells[2, 0].SetBomb();
            sourceCells[2, 1].SetBomb();
            sourceCells[2, 2].SetBomb();


            expectedCells[0, 0].SetBomb();
            expectedCells[0, 1].SetBomb();
            expectedCells[0, 2].SetBomb();
            expectedCells[1, 0].SetBomb();
            expectedCells[1, 2].SetBomb();
            expectedCells[2, 0].SetBomb();
            expectedCells[2, 1].SetBomb();
            expectedCells[2, 2].SetBomb();

            expectedCells[0, 0].SetQuantityBombsNear(2);
            expectedCells[0, 1].SetQuantityBombsNear(4);
            expectedCells[0, 2].SetQuantityBombsNear(2);
            expectedCells[1, 0].SetQuantityBombsNear(4);
            expectedCells[1, 1].SetQuantityBombsNear(8);
            expectedCells[1, 2].SetQuantityBombsNear(4);
            expectedCells[2, 0].SetQuantityBombsNear(2);
            expectedCells[2, 1].SetQuantityBombsNear(4);
            expectedCells[2, 2].SetQuantityBombsNear(2);

            AssertValues();
        }

        [Test]
        public void NearBombCalculatorCalculate0Bombs()
        {
            AssertValues();
        }
    }
}
