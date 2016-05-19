using Minesweeper.Domain.Interface;
using Minesweeper.Library.Exception;
using System;
using System.Collections.Generic;

namespace Minesweeper.Domain.Core.FieldBuilder
{
    public class BombGenerator : IBombGenerator
    {
        public List<int> GenerateBombsPosition(int quantityBombs, int fieldSize)
        {
            if (quantityBombs > fieldSize)
                throw new MinesweeperException(Properties.Resources.QuantityBombsBiggerThanFieldSize);

            var bombsPosition = new List<int>();
            var random = new Random();

            var generateMoreBomb = quantityBombs > 0;
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
