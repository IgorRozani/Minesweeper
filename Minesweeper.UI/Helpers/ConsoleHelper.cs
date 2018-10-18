using System;

namespace Minesweeper.UI.Helpers
{
    public static class ConsoleHelper
    {
        public static void WriteMultipleLines(params string[] texts)
        {
            foreach (var text in texts)
                Console.WriteLine(text);
        }
    }
}
