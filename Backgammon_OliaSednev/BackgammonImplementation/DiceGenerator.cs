using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BackgammonInterfaces;

namespace BackgammonImplementation
{
    public class DiceGenerator : IDiceGenerator
    {
        public int Cube1 { get; set; }
        public int Cube2 { get; set; }
        private static Random random = new Random();
        public bool RolledDouble { get; set; }

        public void RollDice()
        {
            Cube1 = random.Next(1, 7);
            Cube2 = random.Next(1, 7);
        }
    }
}
