using Minesweeper.Domain.Enums;
using Xunit;

namespace Minesweeper.Domain.Test.Models.Cell
{
    public class ConstructorTests
    {
        private readonly Domain.Models.Cell _cell;

        public ConstructorTests()
        {
            _cell=new Domain.Models.Cell();
        }

        [Fact(DisplayName = "Untouched cell returns untouched")]
        public void UntouchedCellReturnUntouched()
        {
            Assert.Equal(StatusEnum.Untouched, _cell.Status);
        }

        [Fact(DisplayName = "Without bomb returns false")]
        public void WithoutBombReturnFalse()
        {
            Assert.False(_cell.HasBomb);
        }
    }
}
