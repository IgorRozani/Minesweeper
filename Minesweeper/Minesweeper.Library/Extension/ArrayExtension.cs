using System;
using System.Collections.Generic;

namespace Minesweeper.Library.Extension
{
    public static class ArrayExtension
    {
        public static List<int> GetDimensionsLength(this Array source)
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
