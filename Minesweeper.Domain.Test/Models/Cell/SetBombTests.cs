using Minesweeper.Domain.Exceptions;
using Xunit;

namespace Minesweeper.Domain.Test.Models.Cell
{
    public class SetBombTests
    {
        private Domain.Models.Cell _cell;

        public SetBombTests()
        {
            _cell = new Domain.Models.Cell();
        }

        [Fact(DisplayName = "Cell without bomb set HasBomb true")]
        public void CellWithoutBombSetHasBombTrue()
        {
            _cell.SetBomb();

            Assert.True(_cell.HasBomb);
        }

        [Fact(DisplayName = "Cell with bomb return MinesweeperException")]
        public void CellWithBombReturnMinesweeperException()
        {
            _cell.SetBomb();

            Assert.Throws<MinesweeperException>(() => _cell.SetBomb());
        }

        [Fact(DisplayName = "Cell with bomb return message in MinesweeperException")]
        public void CellWithBombReturnMessageInMinesweeperException()
        {
            _cell.SetBomb();

            var exception = Assert.Throws<MinesweeperException>(() => _cell.SetBomb());

            Assert.Equal("This cell already has bomb", exception.Message);
        }

        [Fact(DisplayName = "Checked cell return MinesweeperException")]
        public void CheckedCellReturnMinesweeperException()
        {
            _cell.Check();

            Assert.Throws<MinesweeperException>(() => _cell.SetBomb());
        }

        [Fact(DisplayName = "Checked cell return message in MinesweeperException")]
        public void CheckedCellReturnMessageInMinesweeperException()
        {
            _cell.Check();

            var exception = Assert.Throws<MinesweeperException>(() => _cell.SetBomb());

            Assert.Equal("It can't be place a bomb in a checked cell.", exception.Message);
        }

        [Fact(DisplayName = "Flagged cell return MinesweeperException")]
        public void FlaggedCellReturnMinesweeperException()
        {
            _cell.Flag();

            Assert.Throws<MinesweeperException>(() => _cell.SetBomb());
        }

        [Fact(DisplayName = "Flagged cell return message in MinesweeperException")]
        public void FlaggedCellReturnMessageInMinesweeperException()
        {
            _cell.Flag();

            var exception = Assert.Throws<MinesweeperException>(() => _cell.SetBomb());

            Assert.Equal("It can't be place a bomb in a checked cell.", exception.Message);
        }
    }
}
