using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Minesweeper.Console.Helper
{
    public static class ConsoleHelper
    {
        public static void PrintTexts(params string[] texts)
        {
            foreach (var text in texts)
                System.Console.WriteLine(text);
        }
    }
}
