using FluentAssertions;
using Minesweeper.Domain.Core.GameMechanic;
using Minesweeper.Domain.Model;
using Minesweeper.Test.Helper;
using NUnit.Framework;

namespace Minesweeper.Test.Domain.Core.GameMechanic.Unit
{
    [TestFixture]
    public class IdentifiedBombsCalculatorTest
    {
        private IdentifiedBombsCalculator identifiedBombsCalculator;
        private Cell[,] field;
        private Position position;
 
        [SetUp]
        public void Initialize()
        {
            identifiedBombsCalculator = new IdentifiedBombsCalculator();

            field = FieldHelper.InstanciateField3x3();

            position = new Position(1, 1);
        }

        [Test]
        public void CalculateFieldWithoutBombsIdentfied()
        {
            var result = identifiedBombsCalculator.Calculate(field, position);
            result.Should().Be(0);
        }
    }
}
