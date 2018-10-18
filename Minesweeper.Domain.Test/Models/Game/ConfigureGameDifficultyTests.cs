using Minesweeper.Domain.Enums;
using Minesweeper.Domain.Exceptions;
using Moq.AutoMock;
using Xunit;

namespace Minesweeper.Domain.Test.Models.Game
{
    public class ConfigureGameDifficultyTests
    {
        private readonly Domain.Models.Game _game;

        public ConfigureGameDifficultyTests()
        {
            var autoMocker = new AutoMocker();

            _game = autoMocker.CreateInstance<Domain.Models.Game>();
        }

        [Fact(DisplayName = "Invalid DifficultyLevelEnum return MinesweeperException")]
        public void InvalidDifficultyLevelEnumReturnMinesweeperException()
        {
            Assert.Throws<MinesweeperException>(() => _game.ConfigureGameDifficulty((DifficultyLevelEnum)5));
        }

        [Fact(DisplayName = "Invalid DifficultyLevelEnum return message in MinesweeperException")]
        public void InvalidDifficultyLevelEnumReturnMessageInMinesweeperException()
        {
            var exception = Assert.Throws<MinesweeperException>(() => _game.ConfigureGameDifficulty((DifficultyLevelEnum)5));

            Assert.Equal("Invalid game level!", exception.Message);
        }

        [Fact(DisplayName = "DifficultyLevelEnum easy set difficulty easy")]
        public void DifficultyLevelEnumEasySetDifficultyEasy()
        {
            _game.ConfigureGameDifficulty(DifficultyLevelEnum.Easy);

            Assert.Equal(DifficultyLevelEnum.Easy, _game.Difficulty);
        }

        [Fact(DisplayName = "DifficultyLevelEnum medium set difficulty medium")]
        public void DifficultyLevelEnumMediumSetDifficultyMedium()
        {
            _game.ConfigureGameDifficulty(DifficultyLevelEnum.Medium);

            Assert.Equal(DifficultyLevelEnum.Medium, _game.Difficulty);
        }

        [Fact(DisplayName = "DifficultyLevelEnum hard set difficulty hard")]
        public void DifficultyLevelEnumHardSetDifficultyHard()
        {
            _game.ConfigureGameDifficulty(DifficultyLevelEnum.Hard);

            Assert.Equal(DifficultyLevelEnum.Hard, _game.Difficulty);
        }
    }
}
