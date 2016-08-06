using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackgammonInterfaces
{
    public interface IDiceGenerator
    {
        int Cube1 { get; set; }
        int Cube2 { get; set; }
        bool RolledDouble { get; set; }

        void RollDice();

    }
}
