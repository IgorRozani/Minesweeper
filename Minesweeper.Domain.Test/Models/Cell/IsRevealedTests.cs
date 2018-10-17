using Xunit;

namespace Minesweeper.Domain.Test.Models.Cell
{
    public class IsRevealedTests
    {
        private readonly Domain.Models.Cell _cell;

        public IsRevealedTests()
        {
            _cell = new Domain.Models.Cell();
        }

        [Fact(DisplayName = "Status flagged return false")]
        public void StatusFlaggedReturnFalse()
        {
            _cell.Flag();

            Assert.False(_cell.IsRevealed());
        }

        [Fact(DisplayName = "Status untouched return false")]
        public void StatusUntouchedReturnFalse()
        {
            Assert.False(_cell.IsRevealed());
        }

        [Fact(DisplayName = "Status revealed return true")]
        public void StatusRevealedReturnTrue()
        {
            _cell.Check();

            Assert.True(_cell.IsRevealed());
        }
    }
}
