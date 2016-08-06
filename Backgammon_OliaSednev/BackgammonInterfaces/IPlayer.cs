using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackgammonInterfaces
{
    public interface IPlayer
    {
        string Name { get; set; }
        Token TokenOfPlayer { get; set; }
        bool MyTurn { get; set; }
        int SumOfTokensAtHome { get; set; }
    }
}
