using System;
using System.Collections.Generic;
using Minesweeper.Domain.Enums;
using Minesweeper.Domain.Exceptions;
using Minesweeper.Domain.FieldBuilders;
using Minesweeper.Domain.GameMechanics;
using Minesweeper.Domain.Helpers;
using Minesweeper.Domain.Interfaces;
using Minesweeper.Domain.Models;
using Minesweeper.UI.Enums;
using Minesweeper.UI.Helpers;
using Minesweeper.Domain.Extensions;

namespace Minesweeper.UI
{
    class Program
    {
        private static Game _game;

        static void Main(string[] args)
        {
            var difficulty = ChooseDifficulty();

            IIdentifyCellsAround identifyCellsAround = new IdentifyCellsAround();
            INearBombCalculator nearBombCalculator = new NearBombCalculator(identifyCellsAround);

            IBombGenerator bombGenerator = new BombGenerator();
            IBombDirector bombDirector = new BombDirector(bombGenerator);
            IFieldDirector fieldDirector = new FieldDirector(bombDirector, nearBombCalculator);

            ICellsOpener cellsOpener = new CellsOpener(identifyCellsAround);

            _game = new Game(fieldDirector, cellsOpener);
            _game.ConfigureGameDifficulty(difficulty);

            PlayGame();

            Console.ReadKey();
        }

        private static void PlayGame()
        {
            var continuePlaying = true;
            while (continuePlaying)
            {
                PrintField();
                continuePlaying = Action();
            }
        }

        private static DifficultyLevelEnum ChooseDifficulty()
        {
            var difficulty = DifficultyLevelEnum.Easy;

            var hasSelectedDifficulty = false;
            while (!hasSelectedDifficulty)
            {
                try
                {
                    ConsoleHelper.WriteMultipleLines(GetConfigurationTexts());
                    var valueRead = Convert.ToInt32(Console.ReadLine());
                    difficulty = ConvertToDifficultityLevelEnum(valueRead);

                    hasSelectedDifficulty = true;
                }
                catch (Exception)
                {
                    ConsoleHelper.WriteMultipleLines(Properties.Resources.InvalidOption, string.Empty);
                }
            }

            return difficulty;
        }

        private static DifficultyLevelEnum ConvertToDifficultityLevelEnum(int value)
        {
            if (value < 0 || value > 2)
                throw new MinesweeperException(Properties.Resources.InvalidOption);

            return (DifficultyLevelEnum)value;
        }

        private static GameActionEnum ConvertToactionEnum(int value)
        {
            if (value < 0 || value > 2)
                throw new MinesweeperException(Properties.Resources.InvalidOption);

            return (GameActionEnum)value;
        }

        private static string[] GetConfigurationTexts()
        {
            var texts = new List<string>
            {
                Properties.Resources.ChooseDifficulty,
                Properties.Resources.EasyDifficultyOption,
                Properties.Resources.MediumDifficultyOption,
                Properties.Resources.HardDifficultyOption
            };
            return texts.ToArray();
        }

        private static string[] GetActionTexts()
        {
            var texts = new List<string>
            {
                Properties.Resources.ChooseAction,
                Properties.Resources.CheckAction,
                Properties.Resources.FlagAction,
                Properties.Resources.UnflagAction
            };
            return texts.ToArray();
        }

        private static GameActionEnum ChooseAction()
        {
            var action = GameActionEnum.Check;

            var hasSelectedAction = false;
            while (!hasSelectedAction)
            {
                try
                {
                    ConsoleHelper.WriteMultipleLines(GetActionTexts());
                    var valueRead = Convert.ToInt32(Console.ReadLine());
                    action = ConvertToactionEnum(valueRead);

                    hasSelectedAction = true;
                }
                catch (Exception)
                {
                    ConsoleHelper.WriteMultipleLines(Properties.Resources.InvalidOption, string.Empty);
                }
            }

            return action;
        }

        private static bool Action()
        {
            try
            {
                var action = ChooseAction();
                var position = GetPositionTyped();

                switch (action)
                {
                    case GameActionEnum.Check:
                        _game.Field.Check(position);
                        break;
                    case GameActionEnum.Flag:
                        _game.Field.Flag(position);
                        break;
                    case GameActionEnum.Unflag:
                        _game.Field.Unflag(position);
                        break;
                }

                Console.Clear();

                return true;
            }
            catch (GameOverException ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
            catch (MinesweeperException ex)
            {
                Console.WriteLine(Properties.Resources.TryAgainMessage, ex.Message);
                return true;
            }
            catch (Exception)
            {
                Console.WriteLine(Properties.Resources.CommandFailMessage);
                return true;
            }
        }

        private static Position GetPositionTyped()
        {
            Console.WriteLine(Properties.Resources.ReadRow);
            var row = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine(Properties.Resources.ReadCollumn);
            var collumn = Convert.ToInt32(Console.ReadLine());

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
                    var cell = _game.Field.Cells.GetCell(position);

                    switch (cell.Status)
                    {
                        case StatusEnum.Untouched:
                            text = "U";
                            break;
                        case StatusEnum.Revealed:
                            text = cell.QuantityBombsNear.ToString();
                            break;
                        case StatusEnum.Flagged:
                            text = "F";
                            break;
                    }

                    Console.Write($"{text} ");
                }
                Console.WriteLine();
            }
        }
    }
}
