using FluentAssertions;
using Minesweeper.Domain.Core.FieldBuilder;
using Minesweeper.Domain.Core.Helper;
using Minesweeper.Domain.Interface;
using Minesweeper.Domain.Level;
using NUnit.Framework;

namespace Minesweeper.Test.Domain.Core.FieldBuilder.Integration
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
            IIdentifyCellsAround identifyCellsAround = new IdentifyCellsAround();
            INearBombCalculator nearBombCalculator = new NearBombCalculator(identifyCellsAround);
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
