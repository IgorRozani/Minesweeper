using FluentAssertions;
using Minesweeper.Domain.Enumerator;
using Minesweeper.Domain.Model;
using NUnit.Framework;

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
        public void GetConfiguredGameDifficultity()
        {
            _game.ConfigureGameDifficulty(DifficultyLevelEnum.Easy);

            _game.Difficulty.Should().Be(DifficultyLevelEnum.Easy);
        }
    }
}