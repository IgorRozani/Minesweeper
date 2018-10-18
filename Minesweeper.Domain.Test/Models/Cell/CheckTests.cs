using Minesweeper.Domain.Enums;
using Minesweeper.Domain.Exceptions;
using Xunit;

namespace Minesweeper.Domain.Test.Models.Cell
{
    public class CheckTests
    {
        private Domain.Models.Cell _cell;

        public CheckTests()
        {
            _cell = new Domain.Models.Cell();
        }

        [Fact(DisplayName = "Cell without bomb returns status revealed")]
        public void CellWithoutBombReturnsStatusRevealed()
        {
            _cell.Check();

            Assert.Equal(StatusEnum.Revealed, _cell.Status);
        }

        [Fact(DisplayName = "Cell with bomb returns GameOverException")]
        public void CellWithBombReturnGameOverException()
        {
            _cell.SetBomb();

            Assert.Throws<GameOverException>(() => _cell.Check());
        }

        [Fact(DisplayName = "Cell with bomb set status revealed")]
        public void CellWithBombSetStatusRevealed()
        {
            _cell.SetBomb();

            Assert.Throws<GameOverException>(() => _cell.Check());

            Assert.Equal(StatusEnum.Revealed, _cell.Status);
        }

        [Fact(DisplayName = "Cell with bomb returns message in GameOverException")]
        public void CellWithBombReturnMessageInGameOverException()
        {
            _cell.SetBomb();

            var exception = Assert.Throws<GameOverException>(() => _cell.Check());

            Assert.Equal("Game over!", exception.Message);
        }

        [Fact(DisplayName = "Cell already reavealed returns MinesweeperException")]
        public void CellAlreadyReavealedReturnMinesweeperException()
        {
            _cell.Check();

            Assert.Throws<MinesweeperException>(() => _cell.Check());
        }

        [Fact(DisplayName = "Cell already reavealed returns message in MinesweeperException")]
        public void CellAlreadyReavealedReturnMessageInMinesweeperException()
        {
            _cell.Check();

            var exception = Assert.Throws<MinesweeperException>(() => _cell.Check());

            Assert.Equal("This cell is already revealed.", exception.Message);
        }

        [Fact(DisplayName = "Cell flagged returns MinesweeperException")]
        public void CellFlaggedReturnMinesweeperException()
        {
            _cell.Flag();

            Assert.Throws<MinesweeperException>(() => _cell.Check());
        }

        [Fact(DisplayName = "Cell flagged returns message in MinesweeperException")]
        public void CellFlaggedReturnMessageInMinesweeperException()
        {
            _cell.Flag();

            var exception = Assert.Throws<MinesweeperException>(() => _cell.Check());

            Assert.Equal("It can't be checked a flagged cell.", exception.Message);
        }
    }
}
