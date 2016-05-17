using Minesweeper.Console.Helper;
using Minesweeper.Domain.Enumerator;
using Minesweeper.Domain.Model;
using Minesweeper.Library.Exception;
using System;
using System.Collections.Generic;

namespace Minesweeper.Console
{
    class Program
    {
        private static Game game;
        static void Main(string[] args)
        {
            System.Console.WriteLine((char)178);
            var difficulty = ChooseDifficulty();
            game = new Game();
            game.ConfigureGameDifficulty(difficulty);
        }

        private static DifficultyLevelEnum ChooseDifficulty()
        {
            var selectedDifficulty = false;
            while (!selectedDifficulty)
            {
                try
                {
                   ConsoleHelper.PrintTexts(GetConfigurationMessages());
                    var valueRead = Convert.ToInt32(System.Console.ReadLine());
                    return ConvertToDifficultityLevelEnum(valueRead);
                }
                catch (Exception)
                {
                    ConsoleHelper.PrintTexts(Properties.Resources.InvalidDifficulty, string.Empty);
                }
            }

            throw new GameOverException();
        }

        private static DifficultyLevelEnum ConvertToDifficultityLevelEnum(int value)
        {
            if (value < 0 || value > 2)
                throw new MinesweeperException(Properties.Resources.InvalidDifficulty);

            return (DifficultyLevelEnum)value;
        }

        private static string[] GetConfigurationMessages()
        {
            var messages = new List<string>();
            messages.Add(Properties.Resources.ChooseDifficulty);
            messages.Add(Properties.Resources.EasyDifficultyOption);
            messages.Add(Properties.Resources.MediumDifficultyOption);
            messages.Add(Properties.Resources.HardDifficultyOption);
            return messages.ToArray();
        }

        private static void PrintField()
        {
            var rows = game.Field.FieldLevel.QuantityRows();
            var collumns = game.Field.FieldLevel.QuantityCollumns();

            for(var row = 0; row < rows; row++)
            {
                for(var collumn = 0; collumn < collumns; collumn++)
                {

                }
            }
        }
    }
}
