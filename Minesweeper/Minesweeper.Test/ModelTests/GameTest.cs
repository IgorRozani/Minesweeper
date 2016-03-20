using Microsoft.VisualStudio.TestTools.UnitTesting;
using Minesweeper.Core;
using Minesweeper.Core.Enumerator;

namespace Minesweeper.Test.ModelTests
{
    [TestClass]
    public class GameTest
    {
        private Game game;

        [TestInitialize]
        public void GameInitialize()
        {
            game = new Game();
        }

        [TestMethod]
        public void GetConfiguredGameDifficultity()
        {
            game.ConfigureGameDifficulty(DifficultyLevelEnum.Easy);

            Assert.AreEqual(game.Difficulty, DifficultyLevelEnum.Easy);
        }
    }
}
