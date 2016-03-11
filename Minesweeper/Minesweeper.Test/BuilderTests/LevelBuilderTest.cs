using Microsoft.VisualStudio.TestTools.UnitTesting;
using Minesweeper.Model.Builder;
using NSubstitute;
using System;

namespace Minesweeper.Test.BuilderTests
{
    [TestClass]
    public class LevelBuilderTest
    {
        private const int QUANTITY_ROWS_EVEN = 10;
        private const int QUANTITY_COLUMNS_EVEN = 10;
        private const int QUANTITY_ROWS_ODD_SMALLER = 9;
        private const int QUANTITY_COLUMNS_ODD_SMALLER = 9;
        private const int QUANTITY_ROWS_ODD_GREATER = 3;
        private const int QUANTITY_COLUMNS_ODD_GREATER = 3;

        private LevelBuilder mock;

        [TestInitialize]
        public void InitializeTests()
        {
            mock = Substitute.For<LevelBuilder>();
        }

        private void SetQuantityInMock(int rows, int columns)
        {
            mock.QuantityCollumns().Returns(columns);
            mock.QuantityRows().Returns(rows);
        }

        [TestMethod]
        public void LevelBuilderCalculateQuantityBombsWithValidNumbers()
        {
            SetQuantityInMock(QUANTITY_ROWS_EVEN, QUANTITY_COLUMNS_EVEN);

            var quantityBombs = mock.QuantiyBombs();
            Assert.AreEqual(20, quantityBombs);
        }

        [TestMethod]
        public void LevelBuilderCalculateQuantityBombsWithDecimalSmallerThanFive()
        {
            SetQuantityInMock(QUANTITY_ROWS_ODD_SMALLER, QUANTITY_COLUMNS_ODD_SMALLER);

            var quantityBombs = mock.QuantiyBombs();
            Assert.AreEqual(16, quantityBombs);
        }

        [TestMethod]
        public void LevelBuilderCalculateQuantityBombsWithDecimalGreaterThanFive()
        {
            SetQuantityInMock(QUANTITY_ROWS_ODD_GREATER, QUANTITY_COLUMNS_ODD_GREATER);

            var quantityBombs = mock.QuantiyBombs();
            Assert.AreEqual(1, quantityBombs);
        }
    }
}
