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

        private BombGenerator bombGenerator;

        [SetUp]
        public void InitializeTests()
        {
            bombGenerator = new BombGenerator();
        }

        [Test]
        public void BombGeneratorGenerateTwentyBombs()
        {
            var bombs = bombGenerator.GenerateBombsPosition(QUANTITY_BOMBS, FIELD_SIZE, QUANTITY_COLUMNS);
            bombs.Should().NotBeNullOrEmpty().And.HaveCount(QUANTITY_BOMBS);
        }

        [Test]
        public void BombGeneratorDontGenerateBombsInSamePosition()
        {
            var bombs = bombGenerator.GenerateBombsPosition(QUANTITY_BOMBS, FIELD_SIZE, QUANTITY_COLUMNS);
            bombs.Should().NotBeNullOrEmpty().And.OnlyHaveUniqueItems();
        }

        [Test]
        public void BombGeneratorGenerateZeroBombs()
        {
            var bombs = bombGenerator.GenerateBombsPosition(QUANTITY_ZERO_BOMBS, FIELD_SIZE, QUANTITY_COLUMNS);
            bombs.Should().NotBeNull().And.HaveCount(QUANTITY_ZERO_BOMBS);
        }

        [Test]
        public void BombGeneratorTryGenerateMoreBombsThanFieldSize()
        {
            Action act = () => bombGenerator.GenerateBombsPosition(QUANTITY_BOMBS, FIELD_SIZE_SMALL, QUANTITY_COLUMNS_SMALL);
            act.ShouldThrow<MinesweeperException>();
        }
    }
}
