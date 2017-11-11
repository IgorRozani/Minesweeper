using FluentAssertions;
using Minesweeper.Domain.Core.FieldBuilder;
using NSubstitute;
using NUnit.Framework;

namespace Minesweeper.Test.Domain.Core.FieldBuilder.Unit
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

        private LevelBuilder _mockLevelBuilder;

        [SetUp]
        public void InitializeTests()
        {
            _mockLevelBuilder = Substitute.For<LevelBuilder>();
        }

        private void SetQuantityInMock(int rows, int columns)
        {
            _mockLevelBuilder.QuantityCollumns().Returns(columns);
            _mockLevelBuilder.QuantityRows().Returns(rows);
        }

        [Test]
        public void QuantiyBombs_20Bombs_Return20Bombs()
        {
            SetQuantityInMock(QUANTITY_ROWS_EVEN, QUANTITY_COLUMNS_EVEN);

            var quantityBombs = _mockLevelBuilder.QuantiyBombs();

            quantityBombs.Should().Be(20);
        }

        [Test]
        public void QuantiyBombs_SixteenDotTwoBombs_ReturnSixteenBombs()
        {
            SetQuantityInMock(QUANTITY_ROWS_ODD_SMALLER, QUANTITY_COLUMNS_ODD_SMALLER);

            var quantityBombs = _mockLevelBuilder.QuantiyBombs();

            quantityBombs.Should().Be(16);
        }

        [Test]
        public void QuantiyBombs_OneDotEightBombsReturnOneBomb()
        {
            SetQuantityInMock(QUANTITY_ROWS_ODD_GREATER, QUANTITY_COLUMNS_ODD_GREATER);

            var quantityBombs = _mockLevelBuilder.QuantiyBombs();

            quantityBombs.Should().Be(1);
        }

        [Test]
        public void Size_TenRowsTenCollumsn_ReturnSize100()
        {
            SetQuantityInMock(QUANTITY_ROWS_EVEN, QUANTITY_COLUMNS_EVEN);

            var quantityCells = _mockLevelBuilder.Size();

            quantityCells.Should().Be(100);
        }
    }
}
