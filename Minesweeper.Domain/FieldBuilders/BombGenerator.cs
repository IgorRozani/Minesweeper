using System;
using System.Collections.Generic;
using Minesweeper.Domain.Exceptions;
using Minesweeper.Domain.Interfaces;
using Minesweeper.Domain.Models;

namespace Minesweeper.Domain.FieldBuilders
{
    public class BombGenerator : IBombGenerator
    {
        public List<Position> GenerateBombsPosition(int quantityBombs, int fieldSize, int quantityCollumns)
        {
            if (quantityBombs < 0)
                throw new MinesweeperException(Properties.Resources.InvalidBombQuantity);

            if (quantityBombs > fieldSize)
                throw new MinesweeperException(Properties.Resources.QuantityBombsBiggerThanFieldSize);

            return CreateBombs(quantityBombs, fieldSize, quantityCollumns);
        }

        private List<Position> CreateBombs(int quantityBombs, int fieldSize, int quantityCollumns)
        {
            var bombsIndices = GenerateBombsIndices(quantityBombs, fieldSize);
            return ConvertIndicesToPosition(bombsIndices, quantityCollumns);
        }

        private List<int> GenerateBombsIndices(int quantityBombs, int fieldSize)
        {
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

        private List<Position> ConvertIndicesToPosition(List<int> bombsIndices, int quantityCollumns)
        {
            var bombsPosition = new List<Position>();

            foreach (var bombIndex in bombsIndices)
            {
                if (bombIndex == 0)
                    bombsPosition.Add(new Position(0, 0));
                else
                {
                    var row = bombIndex / quantityCollumns;
                    var collumn = bombIndex % quantityCollumns;
                    bombsPosition.Add(new Position(row, collumn));
                }
            }

            return bombsPosition;
        }
    }
}