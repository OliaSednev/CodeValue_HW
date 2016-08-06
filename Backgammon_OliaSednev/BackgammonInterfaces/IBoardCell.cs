using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackgammonInterfaces
{
    public interface IBoardCell
    {
        int SumOfTokens { get; set; }
        Token? TokenType { get; set; }
    }
}
