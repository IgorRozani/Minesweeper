using FluentAssertions;
using Minesweeper.Domain.Enumerator;
using Minesweeper.Domain.Model;
using Minesweeper.Domain.Exception;
using NUnit.Framework;
using System;

namespace Minesweeper.Test.Domain.Model.Unit
{
    [TestFixture]
    public class CellTest
    {
        private Cell cell;
        private Cell expectedCell;

        [SetUp]
        public void Initialize()
        {
            cell = new Cell();
            expectedCell = new Cell();
        }

        [Test]
        public void CreateUntouchedCell()
        {
            cell.Status.Should().Be(StatusEnum.Untouched);
        }

        [Test]
        public void ConfigureCellWithBomb()
        {
            cell.SetBomb();
            cell.HasBomb.Should().BeTrue();
        }

        [Test]
        public void ConfigureCellWithoutBomb()
        {
            cell.HasBomb.Should().BeFalse();
        }

        [Test]
        public void ConfigureCellWith5BombsNear()
        {
            cell.SetQuantityBombsNear(5);
            cell.QuantityBombsNear.Should().Be(5);
        }

        [Test]
        public void FlagCell()
        {
            cell.Flag();
            cell.Status.Should().Be(StatusEnum.Flagged);
        }

        [Test]
        public void FlagCellThatIsRevealed()
        {
            cell.Check();
            Action action = () => cell.Flag();
            action.ShouldThrow<MinesweeperException>();
        }

        [Test]
        public void UnflagCell()
        {
            cell.Flag();
            cell.Unflag();
            cell.Status.Should().Be(StatusEnum.Untouched);
        }

        [Test]
        public void UnflagCellWithoutFlag()
        {
            Action action = () => cell.Unflag();
            action.ShouldThrow<MinesweeperException>();
        }

        [Test]
        public void CheckCellWithoutBomb()
        {
            cell.Check();
            cell.Status.Should().Be(StatusEnum.Revealed);
        }

        [Test]
        public void CheckCellWithBomb()
        {
            cell.SetBomb();
            Action action = () => cell.Check();
            action.ShouldThrow<GameOverException>();
        }

        [Test]
        public void CheckCellAlreadyReavealed()
        {
            cell.Check();
            Action action = () => cell.Check();
            action.ShouldThrow<MinesweeperException>();
        }

        [Test]
        public void CheckCellFlagged()
        {
            cell.Flag();
            Action action = () => cell.Check();
            action.ShouldThrow<MinesweeperException>();
        }

        [Test]
        public void SetQuantityNearBombsInCheckedCell()
        {
            cell.Check();
            Action action = () => cell.SetQuantityBombsNear(4);
            action.ShouldThrow<MinesweeperException>();
        }

        [Test]
        public void SetBombInCheckedCell()
        {
            cell.Check();
            Action action = () => cell.SetBomb();
            action.ShouldThrow<MinesweeperException>();
        }

        [Test]
        public void CompareCellsWithSameQuantityBombsAndNearBombsAndStatus()
        {
            cell.Equals(expectedCell).Should().BeTrue();
        }

        [Test]
        public void CompareCellsWithDifferentQuantityNearBombs()
        {
            expectedCell.SetQuantityBombsNear(5);
            cell.SetQuantityBombsNear(2);

            cell.Equals(expectedCell).Should().BeFalse();
        }

        [Test]
        public void CompareCellsWithAndWithoutBomb()
        {
            expectedCell.SetBomb();

            cell.Equals(expectedCell).Should().BeFalse();
        }

        [Test]
        public void CompareCellsWithDifferentStatus()
        {
            expectedCell.Check();

            cell.Equals(expectedCell).Should().BeFalse();
        }

        [Test]
        public void CompareCellsWithDifferentQuantityBombsAndNearBombsAndStatus()
        {
            expectedCell.SetQuantityBombsNear(3);
            expectedCell.Check();

            cell.SetBomb();

            cell.Equals(expectedCell).Should().BeFalse();
        }


    }
}
