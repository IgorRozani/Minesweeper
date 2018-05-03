using Minesweeper.Domain.Model;
using System;
using System.Collections.Generic;

namespace Minesweeper.Domain.Extension
{
    public static class CellArrayExtension
    {
        public static Cell GetCell(this Cell[,] source, Position position) => source[position.Row, position.Collumn];

        public static List<int> GetDimensionsLength(this Cell[,] source)
        {
            if (source == null)
                throw new ArgumentNullException();

            var lengths = new List<int>();
            for (var index = 0; index < source.Rank; index++)
                lengths.Add(source.GetLength(index));

            return lengths;
        }
    }
}
