using Microsoft.VisualStudio.TestTools.UnitTesting;
using Minesweeper.Core.Builder;
using NSubstitute;

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

        private LevelBuilder mockLevelBuilder;

        [TestInitialize]
        public void InitializeTests()
        {
            mockLevelBuilder = Substitute.For<LevelBuilder>();
        }

        private void SetQuantityInMock(int rows, int columns)
        {
            mockLevelBuilder.QuantityCollumns().Returns(columns);
            mockLevelBuilder.QuantityRows().Returns(rows);
        }

        [TestMethod]
        public void LevelBuilderCalculateQuantityBombsWithValidNumbers()
        {
            SetQuantityInMock(QUANTITY_ROWS_EVEN, QUANTITY_COLUMNS_EVEN);

            var quantityBombs = mockLevelBuilder.QuantiyBombs();
            Assert.AreEqual(20, quantityBombs);
        }

        [TestMethod]
        public void LevelBuilderCalculateQuantityBombsWithDecimalSmallerThanFive()
        {
            SetQuantityInMock(QUANTITY_ROWS_ODD_SMALLER, QUANTITY_COLUMNS_ODD_SMALLER);

            var quantityBombs = mockLevelBuilder.QuantiyBombs();
            Assert.AreEqual(16, quantityBombs);
        }

        [TestMethod]
        public void LevelBuilderCalculateQuantityBombsWithDecimalGreaterThanFive()
        {
            SetQuantityInMock(QUANTITY_ROWS_ODD_GREATER, QUANTITY_COLUMNS_ODD_GREATER);

            var quantityBombs = mockLevelBuilder.QuantiyBombs();
            Assert.AreEqual(1, quantityBombs);
        }

        [TestMethod]
        public void LevelBuilderCalculateQuatityCells()
        {
            SetQuantityInMock(QUANTITY_ROWS_EVEN, QUANTITY_COLUMNS_EVEN);

            var quantityCells = mockLevelBuilder.QuantityCells();
            Assert.AreEqual(100, quantityCells);
        }
    }
}
