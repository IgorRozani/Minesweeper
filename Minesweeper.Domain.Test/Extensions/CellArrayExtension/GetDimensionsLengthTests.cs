using Minesweeper.Domain.Extensions;
using Minesweeper.Domain.Models;
using System.Collections.Generic;
using Xunit;

namespace Minesweeper.Domain.Test.Extensions.CellArrayExtension
{
    public class GetDimensionsLengthTests
    {
        private const int DIMENSION_1 = 10;
        private const int DIMENSION_2 = 12;
        private Cell[,] _cellAray;

        public GetDimensionsLengthTests()
        {
            _cellAray = new Cell[DIMENSION_1, DIMENSION_2];
        }

        [Fact(DisplayName = "Get dimensions successfully")]
        public void GetDimensionsSuccessfully()
        {
            var expected = new List<int> {10, 12};

            var lengths = _cellAray.GetDimensionsLength();

            Assert.Equal(expected, lengths);
        }
    }
}
