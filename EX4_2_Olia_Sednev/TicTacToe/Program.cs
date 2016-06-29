using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToe
{
    class Program
    {
        static void Main(string[] args)
        {
            TicTacToeGame game = new TicTacToeGame();
            int row, column;
            Console.WriteLine("Select from available options: ");
            Console.WriteLine("-------------------------------\n");
            game.DisplayBoard();
            do
            {
                try
                {
                    Console.Write("Select row between 1-3:  ");
                    row = int.Parse(Console.ReadLine());
                    Console.Write("Select column between 1-3:  ");
                    column = int.Parse(Console.ReadLine());


                    if (game.CheckIfMoveLegality(row - 1, column - 1))
                    {
                        game.NewCurrentType(row - 1, column - 1);
                        Console.WriteLine("\n");
                        game.DisplayBoard();
                    }
                    else
                    {
                        Console.WriteLine("Coordinates out of range!!! \n");
                    }
                }
                catch(Exception exn)
                {
                    Console.WriteLine(exn.Message);

                }

            } while (!game.IsGameOver);
            Console.WriteLine("\n\n---=== GAME OVER !!!! ===---\n\n");

        }
    }
}
