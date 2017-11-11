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

        [SetUp]
        public void Initialize()
        {
            _cell = new Cell();
        }

        #region Default Values

        [Test]
        public void Status_UntouchedCell_ReturnUntouched()
        {
            _cell.Status.Should().Be(StatusEnum.Untouched);
        }

        [Test]
        public void HasBomb_WithoutBomb_ReturnFalse()
        {
            _cell.HasBomb.Should().BeFalse();
        }

        #endregion

        #region SetBomb

        [Test]
        public void SetBomb_CellWithoutBomb_ReturnHasBombTrue()
        {
            _cell.SetBomb();
            _cell.HasBomb.Should().BeTrue();
        }

        [Test]
        public void SetBomb_CellWithBomb_ReturnMinesweeperException()
        {
            _cell.SetBomb();
            Action action = () => _cell.SetBomb();
            action.ShouldThrow<MinesweeperException>();
        }

        [Test]
        public void SetBomb_CheckedCell_ReturnMinesweeperException()
        {
            _cell.Check();
            Action action = () => _cell.SetBomb();
            action.ShouldThrow<MinesweeperException>();
        }

        [Test]
        public void SetBomb_FlaggedCell_ReturnMinesweeperException()
        {
            _cell.Flag();
            Action action = () => _cell.SetBomb();
            action.ShouldThrow<MinesweeperException>();
        }

        #endregion

        #region SetQuantityBombsNear

        [Test]
        public void QuantityBombsNear_With5_Return5()
        {
            _cell.SetQuantityBombsNear(5);
            _cell.QuantityBombsNear.Should().Be(5);
        }

        [Test]
        public void SetQuantityBombsNear_InCheckedCell_ReturnMinesweeperException()
        {
            _cell.Check();
            Action action = () => _cell.SetQuantityBombsNear(4);
            action.ShouldThrow<MinesweeperException>();
        }

        #endregion

        #region Flag

        [Test]
        public void Flag_UnflagCell_ReturnFlaggedStatus()
        {
            _cell.Flag();
            _cell.Status.Should().Be(StatusEnum.Flagged);
        }

        [Test]
        public void Flag_CellWithStatusIsRevealed_ReturnMinesweeperException()
        {
            _cell.Check();
            Action action = () => _cell.Flag();
            action.ShouldThrow<MinesweeperException>();
        }

        [Test]
        public void Flag_CellWithBomb_ReturnFlaggedStatus()
        {
            _cell.SetBomb();
            _cell.Flag();
            _cell.Status.Should().Be(StatusEnum.Flagged);
        }

        #endregion

        #region Unflag

        [Test]
        public void Unflag_FlaggedCell_ReturnStatusUntouched()
        {
            _cell.Flag();
            _cell.Unflag();
            _cell.Status.Should().Be(StatusEnum.Untouched);
        }

        [Test]
        public void Unflag_CellWithoutFlag_ReturnMinesweeperException()
        {
            Action action = () => _cell.Unflag();
            action.ShouldThrow<MinesweeperException>();
        }

        #endregion

        #region Check
        [Test]
        public void Check_CellWithoutBomb_ReturnStatusRevealed()
        {
            _cell.Check();
            _cell.Status.Should().Be(StatusEnum.Revealed);
        }

        [Test]
        public void Check_CellWithBomb_ReturnGameOverException()
        {
            _cell.SetBomb();
            Action action = () => _cell.Check();
            action.ShouldThrow<GameOverException>();
        }

        [Test]
        public void Check_CellAlreadyReavealed_ReturnMinesweeperException()
        {
            _cell.Check();
            Action action = () => _cell.Check();
            action.ShouldThrow<MinesweeperException>();
        }

        [Test]
        public void Check_CellFlagged_ReturnMinesweeperException()
        {
            _cell.Flag();
            Action action = () => _cell.Check();
            action.ShouldThrow<MinesweeperException>();
        }

        #endregion

        #region IsFlagOrUntouched
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
        #endregion

        #region Equals
        [Test]
        public void Equals_NullObject_ReturnFalse()
        {
            _cell.Equals(null).Should().BeFalse();
        }

        [Test]
        public void Equals_WithAllFieldsSimilar_ReturnTrue()
        {
            var testCell = new Cell();
            _cell.Equals(testCell).Should().BeTrue();
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

        #endregion
    }
}
