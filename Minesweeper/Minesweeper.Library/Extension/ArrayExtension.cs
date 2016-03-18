using System;

namespace Minesweeper.Library.Extension
{
    public static class ArrayExtension
    {
        public static int GetRows(this Array source)
        {
            return source.GetLength(0);
        }

        public static int GetCollumns(this Array source)
        {
            return source.Length / GetRows(source);
        }
    }
}
