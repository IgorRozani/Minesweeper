using Minesweeper.Domain.Models;
using System;
using System.Collections.Generic;

namespace Minesweeper.Domain.Extensions
{
    public static class CellArrayExtension
    {
        public static Cell GetCell(this Cell[,] source, Position position)
        {
            if(position == null)
                throw new ArgumentException();
            return source[position.Row, position.Collumn];
        }

        public static List<int> GetDimensionsLength(this Cell[,] source)
        {
            var lengths = new List<int>();
            for (var index = 0; index < source.Rank; index++)
                lengths.Add(source.GetLength(index));

            return lengths;
        }
    }
}
