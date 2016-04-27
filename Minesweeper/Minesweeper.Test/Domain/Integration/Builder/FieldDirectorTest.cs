using FluentAssertions;
using Minesweeper.Domain.Builder;
using Minesweeper.Domain.Interface;
using Minesweeper.Domain.Level;
using Minesweeper.Domain.Model;
using NSubstitute;
using NUnit.Framework;

namespace Minesweeper.Test.Domain.Integration.Builder
{
    [TestFixture]
    public class FieldDirectorTest
    {
        private const int QUANTITY_COLUMNS = 10;
        private const int QUANTITY_ROWS = 10;

        private FieldDirector fieldDirector;
        private IFieldLevel fieldLevel;

        [OneTimeSetUp]
        public void InitializeTests()
        {
            fieldLevel = new EasyLevel();

            IBombGenerator bombGenerator = new BombGenerator();
            IBombDirector bombDirector = new BombDirector(bombGenerator);
            INearBombCalculator nearBombCalculator = new NearBombCalculator();
            fieldDirector = new FieldDirector(bombDirector, nearBombCalculator);
        }

        [Test]
        public void FieldDirectorGenerateCellsNotNull()
        {
            var generateField = fieldDirector.CreateField(fieldLevel);

            generateField.Should().NotBeNullOrEmpty();
        }
    }
}
