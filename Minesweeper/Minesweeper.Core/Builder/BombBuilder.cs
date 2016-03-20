using Minesweeper.Core.Interface;
using System;
using System.Collections.Generic;

namespace Minesweeper.Core.Builder
{
    public class BombBuilder : IBombBuilder
    {
        public List<int> GenerateBombsPosition(IFieldLevel fieldLevel)
        {
            var quantityBombs = fieldLevel.QuantiyBombs();
            var fieldSize = fieldLevel.QuantityCells();

            var bombsPosition = new List<int>();

            var generateMoreBomb = true;
            var random = new Random();
            while (generateMoreBomb)
            {
                var nextPosition = random.Next(0, fieldSize - 1);
                if (!bombsPosition.Contains(nextPosition))
                    bombsPosition.Add(nextPosition);

                generateMoreBomb = quantityBombs > bombsPosition.Count;
            }

            return bombsPosition;
        }
    }
}
