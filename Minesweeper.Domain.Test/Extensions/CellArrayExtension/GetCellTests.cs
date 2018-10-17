using Minesweeper.Domain.Extensions;
using Minesweeper.Domain.Models;
using System;
using Xunit;

namespace Minesweeper.Domain.Test.Extensions.CellArrayExtension
{
    public class GetCellTests
    {
        private Cell[,] _cellAray;

        public GetCellTests()
        {
            _cellAray = null;
        }

        [Fact(DisplayName = "Position null")]
        public void PositionNull()
        {
            Assert.Throws<ArgumentException>(() => _cellAray.GetCell(null));
        }

        [Fact(DisplayName = "Get cell successfully")]
        public void GetCellSuccessfully()
        {
            _cellAray = new Cell[12, 15];
            _cellAray[1,2] = new Cell();

            var cell = _cellAray.GetCell(new Position(1, 2));

            Assert.NotNull(cell);
        }
    }
}
