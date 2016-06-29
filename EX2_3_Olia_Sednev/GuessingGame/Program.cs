using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuessingGame
{
    class Program
    {
        static void Main(string[] args)
        {
            int userGuess = 0;
            int numberOfGuesses = 0;
            int secret = new Random().Next(1, 100);
            while ((userGuess != secret))
            {
                Console.WriteLine("Please try to guess number between 1-100:");
                userGuess=int.Parse( Console.ReadLine());
                numberOfGuesses++;
                if(userGuess > secret)
                {
                    Console.WriteLine("Too big");
                }
                else if(userGuess < secret)
                {
                    Console.WriteLine("Too small");
                }
                else
                {
                    if(numberOfGuesses > 7)
                    {
                        Console.WriteLine("You took {0} guesses !!!", numberOfGuesses);
                        Console.WriteLine("You failed :( ");
                        Console.WriteLine("Correct number is: {0}",secret);

                    }
                    else
                    {
                        Console.WriteLine("Correct guess!!!");
                        Console.WriteLine("You took {0} guesses !!!", numberOfGuesses);
                    }
                }
            } 
        }
    }
}
