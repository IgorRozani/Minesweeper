using Minesweeper.Domain.Core.GameMechanic;
using Minesweeper.Domain.Core.Helper;
using Minesweeper.Domain.Model;
using Minesweeper.Test.Helper;
using NUnit.Framework;

namespace Minesweeper.Test.Domain.Core.GameMechanic.Unit
{
    [TestFixture]
    public class IdentifiedBombsCalculatorTest
    {
        private CellsOpener identifiedBombsCalculator;
        private Cell[,] field;
        private Position position;
 
        [SetUp]
        public void Initialize()
        {
            //identifiedBombsCalculator = new IdentifiedBombsCalculator();

            field = FieldHelper.InstanciateField3X3();

            position = new Position(1, 1);
        }

        //[Test]
        //public void CalculateFieldWithoutBombsIdentfied()
        //{
        //    var result = identifiedBombsCalculator.Calculate(field, position);
        //    result.Should().Be(0);
        //}
    }
}
