using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BackgammonInterfaces;

namespace BackgammonImplementation
{
    public class BoardCell : IBoardCell
    {
        public int SumOfTokens { get; set; }
        public Token? TokenType { get; set; } //can be nullable
        public BoardCell() { } //for empty initial cells
        public BoardCell(int sum, Token token)
        {
            SumOfTokens = sum;
            TokenType = token;
        }
    }
}
