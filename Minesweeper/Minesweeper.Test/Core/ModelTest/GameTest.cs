using FluentAssertions;
using Minesweeper.Core;
using Minesweeper.Core.Enumerator;
using NUnit.Framework;

namespace Minesweeper.Test.Core.ModelTest
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