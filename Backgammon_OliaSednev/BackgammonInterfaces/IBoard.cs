using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackgammonInterfaces
{
    public interface IBoard
    {
        List<IBoardCell> CellsList { get; set; }
        int TokensInTheJail_X { get; set; }
        int TokensInTheJail_O { get; set; }
        void BoardInitializer();
        void AddTokenToCell(int cell, Token token);
        void RemoveTokenFromCell(int cell, Token token);
        void AddTokenToJail(Token token);
        void RemoveTokenFromJail(Token token);


    }
}
