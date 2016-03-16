using Minesweeper.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Minesweeper.Console
{
    class Program
    {
        static void Main(string[] args)
        {
            var game = new Game();
            game.ConfigureGameDifficulty(Model.Enumerator.DifficultyLevelEnum.Easy);
            System.Console.ReadKey();
        }
    }
}
