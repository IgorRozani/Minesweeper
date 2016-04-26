using FluentAssertions;
using Minesweeper.Domain.Enumerator;
using Minesweeper.Domain.Model;
using NUnit.Framework;

namespace Minesweeper.Test.Domain.ModelTest
{
    [TestFixture]
    public class GameTest
    {
        private Game game;

        [SetUp]
        public void GameInitialize()
        {
            game = new Game();
        }

        [Test]
        public void GetConfiguredGameDifficultity()
        {
            game.ConfigureGameDifficulty(DifficultyLevelEnum.Easy);

            game.Difficulty.Should().Be(DifficultyLevelEnum.Easy);
        }
    }
}