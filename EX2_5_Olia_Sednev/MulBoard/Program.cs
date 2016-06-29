using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MulBoard
{
    class MulBoard
    {
        public void EntryToProgram()
        {
            DisplyBoard();

        }

        private void DisplyBoard()
        {
            for(int i = 1; i <= 10; i++)
            {
                for(int j = 1; j <= 10; j++)
                {
                    Console.Write("{0,4}", i, j);
                }
                Console.WriteLine();

            }
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            var mulBoard = new MulBoard();
            mulBoard.EntryToProgram();
        }
    }
}
