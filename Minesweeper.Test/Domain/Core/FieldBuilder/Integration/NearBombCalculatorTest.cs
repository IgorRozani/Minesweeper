using FluentAssertions;
using Minesweeper.Domain.Core.FieldBuilder;
using Minesweeper.Domain.Core.Helper;
using Minesweeper.Domain.Interface;
using Minesweeper.Domain.Model;
using NUnit.Framework;

namespace Minesweeper.Test.Domain.Core.FieldBuilder.Integration
{
    [TestFixture]
    public class NearBombCalculatorTest
    {
        private Cell[,] _sourceCells;
        private Cell[,] _expectedCells;
        private NearBombCalculator _nearBombCalculator;

        [SetUp]
        public void InitializeTests()
        {
            _sourceCells = new Cell[3, 3];
            _sourceCells[0, 0] = new Cell();
            _sourceCells[0, 1] = new Cell();
            _sourceCells[0, 2] = new Cell();
            _sourceCells[1, 0] = new Cell();
            _sourceCells[1, 1] = new Cell();
            _sourceCells[1, 2] = new Cell();
            _sourceCells[2, 0] = new Cell();
            _sourceCells[2, 1] = new Cell();
            _sourceCells[2, 2] = new Cell();

            _expectedCells = new Cell[3, 3];
            _expectedCells[0, 0] = new Cell();
            _expectedCells[0, 1] = new Cell();
            _expectedCells[0, 2] = new Cell();
            _expectedCells[1, 0] = new Cell();
            _expectedCells[1, 1] = new Cell();
            _expectedCells[1, 2] = new Cell();
            _expectedCells[2, 0] = new Cell();
            _expectedCells[2, 1] = new Cell();
            _expectedCells[2, 2] = new Cell();

            IIdentifyCellsAround identifyCellsAround = new IdentifyCellsAround();

            _nearBombCalculator = new NearBombCalculator(identifyCellsAround);
        }

        private void AssertValues()
        {
            var calculateCells = _nearBombCalculator.Calculate(_sourceCells);
            calculateCells.ShouldBeEquivalentTo(_expectedCells);
        }

        [Test]
        public void NearBombCalculatorCalculateABombInFirstPosition()
        {
            _sourceCells[0, 0].SetBomb();

            _expectedCells[0, 0].SetBomb();
            _expectedCells[0, 1].SetQuantityBombsNear(1);
            _expectedCells[1, 0].SetQuantityBombsNear(1);
            _expectedCells[1, 1].SetQuantityBombsNear(1);

            AssertValues();
        }

        [Test]
        public void NearBombCalculatorCalculateABombInLastPosition()
        {
            _sourceCells[2, 2].SetBomb();

            _expectedCells[2, 2].SetBomb();
            _expectedCells[2, 1].SetQuantityBombsNear(1);
            _expectedCells[1, 1].SetQuantityBombsNear(1);
            _expectedCells[1, 2].SetQuantityBombsNear(1);

            AssertValues();
        }

        [Test]
        public void NearBombCalculatorCalculateABombInTheMiddle()
        {
            _sourceCells[1, 1].SetBomb();

            _expectedCells[1, 1].SetBomb();
            _expectedCells[0, 0].SetQuantityBombsNear(1);
            _expectedCells[0, 1].SetQuantityBombsNear(1);
            _expectedCells[0, 2].SetQuantityBombsNear(1);
            _expectedCells[1, 0].SetQuantityBombsNear(1);
            _expectedCells[1, 2].SetQuantityBombsNear(1);
            _expectedCells[2, 0].SetQuantityBombsNear(1);
            _expectedCells[2, 1].SetQuantityBombsNear(1);
            _expectedCells[2, 2].SetQuantityBombsNear(1);

            AssertValues();
        }

        [Test]
        public void NearBombCalculatorCalculateAFieldWith2Bombs()
        {
            _sourceCells[0, 0].SetBomb();
            _sourceCells[0, 1].SetBomb();

            _expectedCells[0, 0].SetBomb();
            _expectedCells[0, 1].SetBomb();
            _expectedCells[0, 0].SetQuantityBombsNear(1);
            _expectedCells[0, 1].SetQuantityBombsNear(1);
            _expectedCells[0, 2].SetQuantityBombsNear(1);
            _expectedCells[1, 0].SetQuantityBombsNear(2);
            _expectedCells[1, 1].SetQuantityBombsNear(2);
            _expectedCells[1, 2].SetQuantityBombsNear(1);

            AssertValues();
        }

        [Test]
        public void NearBombCalculatorCalculate8Bombs()
        {
            _sourceCells[0, 0].SetBomb();
            _sourceCells[0, 1].SetBomb();
            _sourceCells[0, 2].SetBomb();
            _sourceCells[1, 0].SetBomb();
            _sourceCells[1, 2].SetBomb();
            _sourceCells[2, 0].SetBomb();
            _sourceCells[2, 1].SetBomb();
            _sourceCells[2, 2].SetBomb();


            _expectedCells[0, 0].SetBomb();
            _expectedCells[0, 1].SetBomb();
            _expectedCells[0, 2].SetBomb();
            _expectedCells[1, 0].SetBomb();
            _expectedCells[1, 2].SetBomb();
            _expectedCells[2, 0].SetBomb();
            _expectedCells[2, 1].SetBomb();
            _expectedCells[2, 2].SetBomb();

            _expectedCells[0, 0].SetQuantityBombsNear(2);
            _expectedCells[0, 1].SetQuantityBombsNear(4);
            _expectedCells[0, 2].SetQuantityBombsNear(2);
            _expectedCells[1, 0].SetQuantityBombsNear(4);
            _expectedCells[1, 1].SetQuantityBombsNear(8);
            _expectedCells[1, 2].SetQuantityBombsNear(4);
            _expectedCells[2, 0].SetQuantityBombsNear(2);
            _expectedCells[2, 1].SetQuantityBombsNear(4);
            _expectedCells[2, 2].SetQuantityBombsNear(2);

            AssertValues();
        }

        [Test]
        public void NearBombCalculatorCalculate0Bombs()
        {
            AssertValues();
        }
    }
}
