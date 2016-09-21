using Minesweeper.Console.Helper;
using Minesweeper.Domain.Enumerator;
using Minesweeper.Domain.Model;
using Minesweeper.Domain.Exception;
using System;
using System.Collections.Generic;

namespace Minesweeper.Console
{
    class Program
    {
        private static Game _game;

        static void Main(string[] args)
        {
            var difficulty = ChooseDifficulty();
            _game = new Game();
            _game.ConfigureGameDifficulty(difficulty);

            PlayGame();

            System.Console.ReadKey();
        }

        private static void PlayGame()
        {
            var continuePlaying = true;
            while (continuePlaying)
            {
                PrintField();
                continuePlaying = CheckAction();
            }
        }

        private static DifficultyLevelEnum ChooseDifficulty()
        {
            var selectedDifficulty = false;
            while (!selectedDifficulty)
            {
                try
                {
                    ConsoleHelper.PrintTexts(GetConfigurationTexts());
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

        private static string[] GetConfigurationTexts()
        {
            var texts = new List<string>();
            texts.Add(Properties.Resources.ChooseDifficulty);
            texts.Add(Properties.Resources.EasyDifficultyOption);
            texts.Add(Properties.Resources.MediumDifficultyOption);
            texts.Add(Properties.Resources.HardDifficultyOption);
            return texts.ToArray();
        }

        private static string[] GetActionTexts()
        {
            var texts = new List<string>();
            texts.Add(Properties.Resources.ChooseAction);
            texts.Add(Properties.Resources.CheckAction);
            texts.Add(Properties.Resources.FlagAction);
            texts.Add(Properties.Resources.UnflagAction);
            return texts.ToArray();
        }

        private static bool CheckAction()
        {
            try
            {
                var position = GetPositionTyped();
                _game.Field.Check(position);

                System.Console.Clear();

                return true;
            }
            catch(GameOverException ex)
            {
                System.Console.WriteLine(ex.Message);
                return false;
            }
            catch(MinesweeperException ex)
            {
                System.Console.WriteLine(string.Format(Properties.Resources.TryAgainMessage, ex.Message));
                return true;
            }
            catch (Exception)
            {
                System.Console.WriteLine(Properties.Resources.CommandFailMessage);
                return true;
            }
        }

        private static Position GetPositionTyped()
        {
            System.Console.WriteLine(Properties.Resources.ReadRow);
            var row = Convert.ToInt32(System.Console.ReadLine());

            System.Console.WriteLine(Properties.Resources.ReadCollumn);
            var collumn = Convert.ToInt32(System.Console.ReadLine());

            return new Position(row, collumn);
        }

        private static void PrintField()
        {
            var rows = _game.Field.FieldLevel.QuantityRows();
            var collumns = _game.Field.FieldLevel.QuantityCollumns();

            for (var row = 0; row < rows; row++)
            {
                for (var collumn = 0; collumn < collumns; collumn++)
                {
                    var text = string.Empty;
                    var position = new Position(row, collumn);
                    var cell = _game.Field.GetCell(position);

                    switch (cell.Status)
                    {
                        case StatusEnum.Untouched:
                            text = "U";
                            break;
                        case StatusEnum.Revealed:
                            text = "R";
                            break;
                        case StatusEnum.Flagged:
                            text = "F";
                            break;
                    }

                    System.Console.Write(string.Format("{0} ", text));
                }
                System.Console.WriteLine();
            }
        }
    }
}
