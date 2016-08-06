using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackgammonInterfaces
{
    public interface IGameLogic
    {
        IBoard GameBoard { get; set; }
        IPlayer X_Player { get; set; }
        IPlayer O_Player { get; set; }
        IDiceGenerator Dice { get; set; }

        void SwapTurns();
        void RollTheDice();
    }
}
