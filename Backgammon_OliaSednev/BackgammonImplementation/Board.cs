using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BackgammonInterfaces;

namespace BackgammonImplementation
{
    public class Board : IBoard
    {
        public List<IBoardCell> CellsList { get; set; }
        public int TokensInTheJail_X { get; set; }
        public int TokensInTheJail_O { get; set; }

        public Board()
        {
            CellsList = new List<IBoardCell>(new BoardCell[24]);
            TokensInTheJail_X = 0;
            TokensInTheJail_O = 0;
            BoardInitializer();

        }
        public void BoardInitializer()
        {
            for (int i = 0; i < 24; i++)
            {
                switch (i)
                {
                    case 0:
                        CellsList[i] = new BoardCell(2, Token.X);
                        break;
                    case 5:
                        CellsList[i] = new BoardCell(5, Token.O);
                        break;
                    case 7:
                        CellsList[i] = new BoardCell(3, Token.O);
                        break;
                    case 11:
                        CellsList[i] = new BoardCell(5, Token.X);
                        break;
                    case 12:
                        CellsList[i] = new BoardCell(5, Token.O);
                        break;
                    case 16:
                        CellsList[i] = new BoardCell(3, Token.X);
                        break;
                    case 18:
                        CellsList[i] = new BoardCell(5, Token.X);
                        break;
                    case 23:
                        CellsList[i] = new BoardCell(2, Token.O);
                        break;
                    default:
                        CellsList[i] = new BoardCell();
                        break;
                }
            }
        }
        public void AddTokenToCell(int cell, Token token)
        {
            if (CellsList[cell].TokenType != token)
                CellsList[cell].SumOfTokens++;
        }
        public void RemoveTokenFromCell(int cell, Token token)
        {
            if (CellsList[cell].TokenType != token)
                CellsList[cell].SumOfTokens--;
        }        
        public void AddTokenToJail(Token token)
        {
            if (token == Token.O)
            {
                TokensInTheJail_O++;
            }
            if (token == Token.X)
            {
                TokensInTheJail_X++;
            }
        }
        public void RemoveTokenFromJail(Token token)
        {
            if (token == Token.O)
            {
                TokensInTheJail_O--;
            }
            if (token == Token.X)
            {
                TokensInTheJail_X--;
            }
        }
    }
}
