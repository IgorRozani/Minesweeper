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
