using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BackgammonInterfaces;

namespace BackgammonImplementation
{
    public class Player : IPlayer
    {
        public string Name { get; set; }
        public Token TokenOfPlayer { get; set; }
        public bool MyTurn { get; set; }
        public int SumOfTokensAtHome { get; set; }
       
        public Player(string name, Token token)
        {
            Name = name;
            TokenOfPlayer = token;
        }
    }
}
