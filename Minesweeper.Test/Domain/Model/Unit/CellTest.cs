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
        private Cell _cell;
        private Cell _expectedCell;

        [SetUp]
        public void Initialize()
        {
            _cell = new Cell();
            _expectedCell = new Cell();
        }

        [Test]
        public void CreateUntouchedCell()
        {
            _cell.Status.Should().Be(StatusEnum.Untouched);
        }

        [Test]
        public void ConfigureCellWithBomb()
        {
            _cell.SetBomb();
            _cell.HasBomb.Should().BeTrue();
        }

        [Test]
        public void ConfigureCellWithoutBomb()
        {
            _cell.HasBomb.Should().BeFalse();
        }

        [Test]
        public void ConfigureCellWith5BombsNear()
        {
            _cell.SetQuantityBombsNear(5);
            _cell.QuantityBombsNear.Should().Be(5);
        }

        [Test]
        public void FlagCell()
        {
            _cell.Flag();
            _cell.Status.Should().Be(StatusEnum.Flagged);
        }

        [Test]
        public void FlagCellThatIsRevealed()
        {
            _cell.Check();
            Action action = () => _cell.Flag();
            action.ShouldThrow<MinesweeperException>();
        }

        [Test]
        public void UnflagCell()
        {
            _cell.Flag();
            _cell.Unflag();
            _cell.Status.Should().Be(StatusEnum.Untouched);
        }

        [Test]
        public void UnflagCellWithoutFlag()
        {
            Action action = () => _cell.Unflag();
            action.ShouldThrow<MinesweeperException>();
        }

        [Test]
        public void CheckCellWithoutBomb()
        {
            _cell.Check();
            _cell.Status.Should().Be(StatusEnum.Revealed);
        }

        [Test]
        public void CheckCellWithBomb()
        {
            _cell.SetBomb();
            Action action = () => _cell.Check();
            action.ShouldThrow<GameOverException>();
        }

        [Test]
        public void CheckCellAlreadyReavealed()
        {
            _cell.Check();
            Action action = () => _cell.Check();
            action.ShouldThrow<MinesweeperException>();
        }

        [Test]
        public void CheckCellFlagged()
        {
            _cell.Flag();
            Action action = () => _cell.Check();
            action.ShouldThrow<MinesweeperException>();
        }

        [Test]
        public void SetQuantityNearBombsInCheckedCell()
        {
            _cell.Check();
            Action action = () => _cell.SetQuantityBombsNear(4);
            action.ShouldThrow<MinesweeperException>();
        }

        [Test]
        public void SetBombInCheckedCell()
        {
            _cell.Check();
            Action action = () => _cell.SetBomb();
            action.ShouldThrow<MinesweeperException>();
        }

        [Test]
        public void CompareCellsWithSameQuantityBombsAndNearBombsAndStatus()
        {
            _cell.Equals(_expectedCell).Should().BeTrue();
        }

        [Test]
        public void CompareCellsWithDifferentQuantityNearBombs()
        {
            _expectedCell.SetQuantityBombsNear(5);
            _cell.SetQuantityBombsNear(2);

            _cell.Equals(_expectedCell).Should().BeFalse();
        }

        [Test]
        public void CompareCellsWithAndWithoutBomb()
        {
            _expectedCell.SetBomb();

            _cell.Equals(_expectedCell).Should().BeFalse();
        }

        [Test]
        public void CompareCellsWithDifferentStatus()
        {
            _expectedCell.Check();

            _cell.Equals(_expectedCell).Should().BeFalse();
        }

        [Test]
        public void CompareCellsWithDifferentQuantityBombsAndNearBombsAndStatus()
        {
            _expectedCell.SetQuantityBombsNear(3);
            _expectedCell.Check();

            _cell.SetBomb();

            _cell.Equals(_expectedCell).Should().BeFalse();
        }

        [Test]
        public void IsFlagOrUntouched_StatusNotFlagOrUntouched_ReturnFalse()
        {
            _cell.Check();
            var status = _cell.IsFlagOrUntouched();
            status.Should().BeFalse();
        }

        [Test]
        public void IsFlagOrUntouched_StatusUntouched_ReturnTrue()
        {
            var status = _cell.IsFlagOrUntouched();
            status.Should().BeTrue();
        }

        [Test]
        public void IsFlagOrUntouched_StatusFlag_ReturnTrue()
        {
            _cell.Flag();
            var status = _cell.IsFlagOrUntouched();
            status.Should().BeTrue();
        }

        [Test]
        public void Equals_NullObject_ReturnFalse()
        {
            _cell.Equals(null).Should().BeFalse();
        }

        [Test]
        public void Equals_WithDifferentStatus_ReturnFalse()
        {
            var testCell = new Cell();
            testCell.Check();
            _cell.Equals(testCell).Should().BeFalse();
        }

        [Test]
        public void Equals_WithDifferentQuantityBombsNear_ReturnFalse()
        {
            var testCell = new Cell();
            testCell.SetQuantityBombsNear(3);
            _cell.Equals(testCell).Should().BeFalse();
        }

        [Test]
        public void Equals_WithDifferentHasBomb_ReturnFalse()
        {
            var testCell = new Cell();
            testCell.SetBomb();
            _cell.Equals(testCell).Should().BeFalse();
        }

        [Test]
        public void Equals_WithAllFieldsSimilar_ReturnTrue()
        {
            var testCell = new Cell();
            _cell.Equals(testCell).Should().BeTrue();
        }
    }
}
