using FluentAssertions;
using Minesweeper.Domain.Builder;
using NSubstitute;
using NUnit.Framework;

namespace Minesweeper.Test.Domain.Unit.Builder
{
    [TestFixture]
    public class LevelBuilderTest
    {
        private const int QUANTITY_ROWS_EVEN = 10;
        private const int QUANTITY_COLUMNS_EVEN = 10;
        private const int QUANTITY_ROWS_ODD_SMALLER = 9;
        private const int QUANTITY_COLUMNS_ODD_SMALLER = 9;
        private const int QUANTITY_ROWS_ODD_GREATER = 3;
        private const int QUANTITY_COLUMNS_ODD_GREATER = 3;

        private LevelBuilder mockLevelBuilder;

        [SetUp]
        public void InitializeTests()
        {
            mockLevelBuilder = Substitute.For<LevelBuilder>();
        }

        private void SetQuantityInMock(int rows, int columns)
        {
            mockLevelBuilder.QuantityCollumns().Returns(columns);
            mockLevelBuilder.QuantityRows().Returns(rows);
        }

        [Test]
        public void LevelBuilderCalculateQuantityBombsWithValidNumbers()
        {
            SetQuantityInMock(QUANTITY_ROWS_EVEN, QUANTITY_COLUMNS_EVEN);

            var quantityBombs = mockLevelBuilder.QuantiyBombs();

            quantityBombs.Should().Be(20);
        }

        [Test]
        public void LevelBuilderCalculateQuantityBombsWithDecimalSmallerThanFive()
        {
            SetQuantityInMock(QUANTITY_ROWS_ODD_SMALLER, QUANTITY_COLUMNS_ODD_SMALLER);

            var quantityBombs = mockLevelBuilder.QuantiyBombs();

            quantityBombs.Should().Be(16);
        }

        [Test]
        public void LevelBuilderCalculateQuantityBombsWithDecimalGreaterThanFive()
        {
            SetQuantityInMock(QUANTITY_ROWS_ODD_GREATER, QUANTITY_COLUMNS_ODD_GREATER);

            var quantityBombs = mockLevelBuilder.QuantiyBombs();

            quantityBombs.Should().Be(1);
        }

        [Test]
        public void LevelBuilderCalculateQuatityCells()
        {
            SetQuantityInMock(QUANTITY_ROWS_EVEN, QUANTITY_COLUMNS_EVEN);

            var quantityCells = mockLevelBuilder.Size();

            quantityCells.Should().Be(100);
        }
    }
}
