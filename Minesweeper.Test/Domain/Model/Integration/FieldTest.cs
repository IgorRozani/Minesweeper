using FluentAssertions;
using Minesweeper.Domain.Enumerator;
using Minesweeper.Domain.Interface;
using Minesweeper.Domain.Level;
using Minesweeper.Domain.Model;
using Minesweeper.Domain.Extension;
using NUnit.Framework;
using NSubstitute;
using NSubstitute.Core.Arguments;

namespace Minesweeper.Test.Domain.Model.Integration
{
    [TestFixture]
    public class FieldTest
    {
        private const int QUANTITY_COLUMNS = 10;
        private const int QUANTITY_ROWS = 10;

        private Field _field;
        private Position _position;
        private ICellsOpener _cellsOpener;

        [OneTimeSetUp]
        public void Initialize()
        {
            var field = new Cell[1, 1];
            field[0, 0] = new Cell();

            var fieldDirector = Substitute.For<IFieldDirector>();

            fieldDirector.CreateField(Arg.Any<IFieldLevel>()).Returns(field);

            _cellsOpener = Substitute.For<ICellsOpener>();
            _field = new Field(fieldDirector, _cellsOpener);

            _position = new Position(0, 0);
        }

        [SetUp]
        public void Setup()
        {
            _field.CreateField(new EasyLevel());
        }

        [Test]
        public void Field_Cells_HasNotCellsNull()
        {
            _field.Cells.Should().NotBeNullOrEmpty();
        }

        [Test]
        public void Field_FieldLevel_HasValueInFieldLevel()
        {
            _field.FieldLevel.Should().NotBeNull();
        }

        [Test]
        public void Field_Check_CheckCellInTheFieldWithoutBombAndWithNearBomb()
        {
            _field.Check(_position);
            _cellsOpener.Received().Check(_field.Cells, _position);
        }

        [Test]
        public void Field_Flag_FlagCellInTheField()
        {
            _field.Flag(_position);
            _field.Cells[_position.Row, _position.Collumn].Status.Should().Be(StatusEnum.Flagged);
        }

        [Test]
        public void Field_Unflag_UnflagCellInTheField()
        {
            _field.Flag(_position);
            _field.Unflag(_position);
            _field.Cells[_position.Row, _position.Collumn].Status.Should().Be(StatusEnum.Untouched);
        }
    }
}
