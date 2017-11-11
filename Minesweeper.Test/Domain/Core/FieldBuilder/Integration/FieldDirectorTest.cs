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
        private FieldDirector _fieldDirector;
        private IFieldLevel _fieldLevel;

        [OneTimeSetUp]
        public void InitializeTests()
        {
            _fieldLevel = new EasyLevel();

            IBombGenerator bombGenerator = new BombGenerator();
            IBombDirector bombDirector = new BombDirector(bombGenerator);
            IIdentifyCellsAround identifyCellsAround = new IdentifyCellsAround();
            INearBombCalculator nearBombCalculator = new NearBombCalculator(identifyCellsAround);
            _fieldDirector = new FieldDirector(bombDirector, nearBombCalculator);
        }

        [Test]
        public void CreateField_GenerateCells_ReturnInstanciateCells()
        {
            var generateField = _fieldDirector.CreateField(_fieldLevel);

            generateField.Should().NotBeNullOrEmpty();
        }
    }
}
