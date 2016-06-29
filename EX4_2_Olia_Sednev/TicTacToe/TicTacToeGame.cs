using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToe
{
    public enum SquareType {empty, O, X }
    class TicTacToeGame
    {
        SquareType[,] board = new SquareType[3, 3];
        SquareType currentType = SquareType.X;
        public bool IsGameOver { get { return HasDrow() || HasWinner(); }}

        public TicTacToeGame()
        {
            SquareType[,] board = new SquareType[3,3];
        }

        public void DisplayBoard()
        {
            Console.WriteLine("---===Game board===---");
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    Console.Write("{0,6}",this.board[i,j]);
                }
                Console.WriteLine();
            }
            Console.WriteLine();
        }

        public bool CheckIfMoveLegality(int i, int j)
        {
            if(0 <= i && i< 3 && 0 <= j && j < 3)
            {
                return true;
            }
            return false;

        }
        public void NewCurrentType(int i, int j)
        {

            if (board[i, j] != SquareType.empty)
            {
                Console.WriteLine("\ntry again...");
                return;
            }
            else
            {
                board[i, j] = currentType;
                ChangeType();
            }

        }

        private void ChangeType()
        {
            if (currentType == SquareType.X)
            {
                currentType = SquareType.O;
            }
            else
            {
                currentType = SquareType.X;
            }
        }

        private bool HasDrow()
        {
            for(int i = 0; i < 3; i++)
            {
                for(int j = 0; j < 3; j++)
                {
                    if(board[i,j] == SquareType.empty)
                    {
                        return false;
                    }
                }
            }
            return true;
        }

        private bool HasWinner()
        {

            if ((board[0, 0] == SquareType.O && board[0, 1] == SquareType.O && board[0, 2] == SquareType.O) ||
                (board[0, 0] == SquareType.X && board[0, 1] == SquareType.X && board[0, 2] == SquareType.X) ||
                (board[1, 0] == SquareType.O && board[1, 1] == SquareType.O && board[1, 2] == SquareType.O) ||
                (board[1, 0] == SquareType.X && board[1, 1] == SquareType.X && board[1, 2] == SquareType.X) ||
                (board[2, 0] == SquareType.O && board[2, 1] == SquareType.O && board[2, 2] == SquareType.O) ||
                (board[2, 0] == SquareType.X && board[2, 1] == SquareType.X && board[2, 2] == SquareType.X) ||
                (board[0, 0] == SquareType.O && board[1, 1] == SquareType.O && board[2, 2] == SquareType.O) ||
                (board[0, 0] == SquareType.X && board[1, 1] == SquareType.X && board[2, 2] == SquareType.X) ||
                (board[0, 2] == SquareType.O && board[1, 1] == SquareType.O && board[2, 0] == SquareType.O) ||
                (board[0, 2] == SquareType.X && board[1, 1] == SquareType.X && board[2, 0] == SquareType.X) ||
                (board[0, 0] == SquareType.O && board[1, 0] == SquareType.O && board[2, 0] == SquareType.O) ||
                (board[0, 0] == SquareType.X && board[1, 0] == SquareType.X && board[2, 0] == SquareType.X) ||
                (board[0, 1] == SquareType.O && board[1, 1] == SquareType.O && board[2, 1] == SquareType.O) ||
                (board[0, 1] == SquareType.X && board[1, 1] == SquareType.X && board[2, 1] == SquareType.X) ||
                (board[0, 2] == SquareType.O && board[1, 2] == SquareType.O && board[2, 2] == SquareType.O) ||
                (board[0, 2] == SquareType.X && board[1, 2] == SquareType.X && board[2, 2] == SquareType.X))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}



//            var winOptions = new[]
//{
//                new[] { board[0,0], board[0,1], board[0, 2]},
//                new[] { board[1,0], board[1,1], board[1, 2]},
//                new[] { board[2,0], board[2,1], board[2, 2]},
//                new[] { board[0,0], board[1,1], board[2, 2]},
//                new[] { board[0,2], board[1,1], board[2, 0]}
//            };
//            foreach(var options in winOptions)
//            {
//                options.Any(SquareType.empty);
//            }
//            if (board[0,1]==SquareType.O)