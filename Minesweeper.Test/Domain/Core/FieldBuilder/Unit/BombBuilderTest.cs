using FluentAssertions;
using Minesweeper.Domain.Core.FieldBuilder;
using Minesweeper.Domain.Exception;
using NUnit.Framework;
using System;

namespace Minesweeper.Test.Domain.Core.FieldBuilder.Unit
{
    [TestFixture]
    public class BombBuilderTest
    {
        private const int FIELD_SIZE = 100;
        private const int FIELD_SIZE_SMALL = 10;
        private const int QUANTITY_COLUMNS = 10;
        private const int QUANTITY_COLUMNS_SMALL = 2;
        private const int QUANTITY_BOMBS = 20;
        private const int QUANTITY_ZERO_BOMBS = 0;
        private const int QUANTITY_NEGATIVE_BOMBS = -10;

        private BombGenerator _bombGenerator;

        [SetUp]
        public void InitializeTests()
        {
            _bombGenerator = new BombGenerator();
        }

        [Test]
        public void GenerateBombsPosition_TwentyBombs_ReturnTwentyBombs()
        {
            var bombs = _bombGenerator.GenerateBombsPosition(QUANTITY_BOMBS, FIELD_SIZE, QUANTITY_COLUMNS);
            bombs.Should().NotBeNullOrEmpty().And.HaveCount(QUANTITY_BOMBS);
        }

        [Test]
        public void GenerateBombsPosition_TwentyBombs_DontGenerateBombsInSamePosition()
        {
            var bombs = _bombGenerator.GenerateBombsPosition(QUANTITY_BOMBS, FIELD_SIZE, QUANTITY_COLUMNS);
            bombs.Should().NotBeNullOrEmpty().And.OnlyHaveUniqueItems();
        }

        [Test]
        public void GenerateBombsPosition_ZeroBombs_ReturnZeroBombs()
        {
            var bombs = _bombGenerator.GenerateBombsPosition(QUANTITY_ZERO_BOMBS, FIELD_SIZE, QUANTITY_COLUMNS);
            bombs.Should().NotBeNull().And.HaveCount(QUANTITY_ZERO_BOMBS);
        }

        [Test]
        public void GenerateBombsPosition_GenerateMoreBombsThanFieldSize_ReturnMinesweeperException()
        {
            Action act = () => _bombGenerator.GenerateBombsPosition(QUANTITY_BOMBS, FIELD_SIZE_SMALL, QUANTITY_COLUMNS_SMALL);
            act.ShouldThrow<MinesweeperException>();
        }

        [Test]
        public void GenerateBombsPosition_GenerateNegativeQuantityBombs_ReturnMinesweeperException()
        {
            Action act = () => _bombGenerator.GenerateBombsPosition(QUANTITY_NEGATIVE_BOMBS, FIELD_SIZE_SMALL, QUANTITY_COLUMNS_SMALL);
            act.ShouldThrow<MinesweeperException>();
        }
    }
}
