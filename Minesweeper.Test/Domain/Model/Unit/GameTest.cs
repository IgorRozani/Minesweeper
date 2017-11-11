using FluentAssertions;
using Minesweeper.Domain.Enumerator;
using Minesweeper.Domain.Exception;
using Minesweeper.Domain.Model;
using NUnit.Framework;
using System;

namespace Minesweeper.Test.Domain.Model.Unit
{
    [TestFixture]
    public class GameTest
    {
        private Game _game;

        [SetUp]
        public void GameInitialize()
        {
            _game = new Game();
        }

        [Test]
        public void ConfigureGameDifficulty_EasyLevel_ReturnEasyLevel()
        {
            _game.ConfigureGameDifficulty(DifficultyLevelEnum.Easy);

            _game.Difficulty.Should().Be(DifficultyLevelEnum.Easy);
        }

        [Test]
        public void ConfigureGameDifficulty_MediumLevel_ReturnMediumLevel()
        {
            _game.ConfigureGameDifficulty(DifficultyLevelEnum.Medium);

            _game.Difficulty.Should().Be(DifficultyLevelEnum.Medium);
        }

        [Test]
        public void ConfigureGameDifficulty_HardLevel_ReturnHardLevel()
        {
            _game.ConfigureGameDifficulty(DifficultyLevelEnum.Hard);

            _game.Difficulty.Should().Be(DifficultyLevelEnum.Hard);
        }

        [Test]
        public void ConfigureGameDifficulty_InvalidLevel_ReturnMinesweeperException()
        {
            Action action = () => _game.ConfigureGameDifficulty((DifficultyLevelEnum)4);
            action.ShouldThrow<MinesweeperException>();
        }
    }
}