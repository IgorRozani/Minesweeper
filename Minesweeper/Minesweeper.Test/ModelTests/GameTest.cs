using Microsoft.VisualStudio.TestTools.UnitTesting;
using Minesweeper.Model;
using Minesweeper.Model.Enumerators;

namespace Minesweeper.Test.ModelTests
{
    [TestClass]
    public class GameTest
    {
        private Game game;
        private Cell[][] easyField;

        [TestInitialize]
        public void GameInitialize()
        {
            game = new Game();
            easyField = new Cell[3][];
            easyField[0] = new Cell[3] { new Cell(), new Cell(), new Cell() };
            easyField[1] = new Cell[3] { new Cell(), new Cell(), new Cell() };
            easyField[2] = new Cell[3] { new Cell(), new Cell(), new Cell() };
        }

        [TestMethod]
        public void CreateEasyGame_GameDifficulty()
        {
            game.ConfigureGameDifficulty(DifficultyLevelEnum.Easy);

            Assert.AreEqual(game.Difficulty, DifficultyLevelEnum.Easy);
        }

        [TestMethod]
        public void CreateEasyGame_Field()
        {
            game.ConfigureGameDifficulty(DifficultyLevelEnum.Easy);
            CollectionAssert.AreEqual(game.Field, easyField);
        }
    }
}
