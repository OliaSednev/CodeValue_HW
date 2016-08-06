using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BackgammonInterfaces;
using BackgammonImplementation;

namespace BackgammonLogic
{
    class GameLogic: IGameLogic
    {
        public IBoard GameBoard { get; set; }
        public IPlayer X_Player { get; set; }
        public IPlayer O_Player { get; set; }
        
        
        public IDiceGenerator Dice { get; set; }
        public int Dice_Counter { get; private set; }
        public bool RolledDice { get; private set; } //indication about if dice rolled

        public int? PlayerSourceCell { get; private set; }       
        public void SetPlayerSourse(int? index)
        {
            PlayerSourceCell = index;
        }

        public GameLogic()
        {
            X_Player = new Player("The X Player", Token.X);
            O_Player = new Player("The O Player", Token.O);
            X_Player.MyTurn = true;

            GameBoard = new Board();
            Dice = new DiceGenerator();
        }

        public void SwapTurns()
        {
            X_Player.MyTurn = !X_Player.MyTurn;
            O_Player.MyTurn = !O_Player.MyTurn;
        }

        public void RollTheDice()
        {
            Dice.RollDice();
            RolledDice = true;
            Dice.RolledDouble = Dice.Cube1 == Dice.Cube2; // check if Double
        }

        public void ResetCube1()
        {
            Dice.Cube1 = 0;
        }
        public void ResetCube2()
        {
            Dice.Cube2 = 0;
        }
        
        public void DiceCounter()
        {
            Dice_Counter = Dice.RolledDouble ? 4 : 2;
        }

        public void ResetDiceCounter()
        {
            Dice_Counter = 0;
        }
        private void ResetCubeByTarget(int target)
        {
            if (!Dice.RolledDouble)
            {
                if (O_Player.MyTurn)
                {
                    ResetCube(target, 1);
                }
                else
                {
                    ResetCube(target, -1);
                }
            }
        }

        private void ResetCube(int target, int coefficient)
        {
            if ((coefficient*PlayerSourceCell - coefficient * target) == Dice.Cube1) // reset if the cube was used
            {
                ResetCube1();
            }
            else
            {
                ResetCube2();
            }
        }
        private void ResetCubeByNumber(int cube)
        {
            if (!Dice.RolledDouble)
            {
                if (cube == Dice.Cube1)
                {
                    ResetCube1();
                }
                if (cube == Dice.Cube2)
                {
                    ResetCube2();
                }
            }
        }



        public bool LegalOption(int source)
        {
            return X_Player.MyTurn ? IsItLegalOption(source, X_Player) : IsItLegalOption(source, O_Player);
        }
        public bool IsItLegalOption(int source, IPlayer player)
        {
            if (player.TokenOfPlayer == Token.X)
            {
                return GameBoard.CellsList[source].TokenType == Token.X && GameBoard.TokensInTheJail_X == 0;
            }
            //if (TokenOfPlayer == Token.O)
            return GameBoard.CellsList[source].TokenType == Token.O && GameBoard.TokensInTheJail_O == 0;
        }

        public bool LegalMove(int target)
        {
            if (X_Player.MyTurn)
            {
                return Move(X_Player, target, 1);
            }
            return Move(O_Player, target, -1);
        }

        private bool Move(IPlayer player, int target, int coefficient)
        {
            if (Dice.RolledDouble)
            {
                return IsItLegalMove(player, PlayerSourceCell.Value, target, Dice.Cube1, coefficient);
            }
            return IsItLegalMove(player, PlayerSourceCell.Value, target, Dice.Cube1, coefficient) ||
                   IsItLegalMove(player, PlayerSourceCell.Value, target, Dice.Cube2, coefficient);
        }

        public bool IsItLegalMove(IPlayer player, int source, int target, int cubeNumber, int coefficient)
        {
            return coefficient * target - coefficient * source == cubeNumber &&
                (GameBoard.CellsList[target].TokenType == null || //free cell
                GameBoard.CellsList[target].TokenType == player.TokenOfPlayer);
        }
        public void SetMove(int target, bool tokenWasEaten)
        {
            if (!tokenWasEaten) // if tokenWasEaten false, cell is empty, just need to add token to list and if tokenWasEaten true, one token eats another, there is no need to add token
            {
                GameBoard.CellsList[target].SumOfTokens++; //add token to target cell
            }

            if (PlayerSourceCell >= 0 && PlayerSourceCell <= 23) // board moves
            {
                GameBoard.CellsList[PlayerSourceCell.Value].SumOfTokens--; // reduce token from source cell
                if (GameBoard.CellsList[PlayerSourceCell.Value].SumOfTokens == 0) //if cell empty set null
                {
                    GameBoard.CellsList[PlayerSourceCell.Value].TokenType = null;
                }
            }
            else // (PlayerSourceCell <= 0 && PlayerSourceCell >= 23) the move from Jail.
            {
                GameBoard.RemoveTokenFromJail(X_Player.MyTurn ? X_Player.TokenOfPlayer : O_Player.TokenOfPlayer);
            }

            if (GameBoard.CellsList[target].SumOfTokens == 1) // if was eaten or empty, change to current Token
            {
                GameBoard.CellsList[target].TokenType = X_Player.MyTurn ? X_Player.TokenOfPlayer : O_Player.TokenOfPlayer;
            }
            ResetCubeByTarget(target); // reset the used cube
            PlayerSourceCell = null;
            Dice_Counter--;
        }

        public bool LegalMoveToEat(int target)
        {
            return MoveToEat(target, X_Player.MyTurn ? X_Player : O_Player);
        }

        public bool MoveToEat(int target, IPlayer player)
        {
            if (Dice.RolledDouble)
            {
                return IsItLegalToEat(player, PlayerSourceCell.Value, target, Dice.Cube1);
            }
            return IsItLegalToEat(player, PlayerSourceCell.Value, target, Dice.Cube1) ||
                   IsItLegalToEat(player, PlayerSourceCell.Value, target, Dice.Cube2);
        }

        public bool IsItLegalToEat(IPlayer player, int source, int target, int cubeNumber)
        {

            if (player.TokenOfPlayer == Token.X)
            {
                return target - source == cubeNumber &&
                       GameBoard.CellsList[target].TokenType == Token.O && // not my tokens
                       GameBoard.CellsList[target].SumOfTokens == 1; // and one token, then i can eat him
            }
            //if (TokenOfPlayer == Token.O)
            return source - target == cubeNumber &&
                   GameBoard.CellsList[target].TokenType == Token.X &&  // not my tokens
                   GameBoard.CellsList[target].SumOfTokens == 1; // and one token, then i can eat him
        }
        public void SetMoveToEat(int index)
        {
            GameBoard.AddTokenToJail(X_Player.MyTurn ? O_Player.TokenOfPlayer : X_Player.TokenOfPlayer);

            SetMove(index, true);
        }

        public void SetJailMove(int cube)
        {
            GameBoard.CellsList[PlayerSourceCell.Value].SumOfTokens--;
            if (GameBoard.CellsList[PlayerSourceCell.Value].SumOfTokens == 0)
            {
                GameBoard.CellsList[PlayerSourceCell.Value].TokenType = null;
            }

            ResetCubeByNumber(cube);
            PlayerSourceCell = null;
            Dice_Counter--;
        }

        public bool IsLegalToExit(out int cubeUsed)
        {
            cubeUsed = Dice.Cube1 < Dice.Cube2 ? Dice.Cube1 : Dice.Cube2;

            if (X_Player.MyTurn)
            {
                bool isLegalMoveCube1 = IsExitMove(X_Player, PlayerSourceCell.Value, Dice.Cube1);
                bool isLegalMoveCube2 = IsExitMove(X_Player, PlayerSourceCell.Value, Dice.Cube2);

                return Dice.RolledDouble ? IsExitMove(X_Player, PlayerSourceCell.Value, Dice.Cube1) :
                    LegalMoveForExit(ref cubeUsed, isLegalMoveCube1, isLegalMoveCube2);
            }
            else
            {
                bool isLegalMoveCube1 = IsExitMove(O_Player, PlayerSourceCell.Value, Dice.Cube1);
                bool isLegalMoveCube2 = IsExitMove(O_Player, PlayerSourceCell.Value, Dice.Cube2);

                return Dice.RolledDouble ? IsExitMove(O_Player, PlayerSourceCell.Value, Dice.Cube1) :
                    LegalMoveForExit(ref cubeUsed, isLegalMoveCube1, isLegalMoveCube2);
            }
        }
        public bool IsExitMove(IPlayer player, int source, int cubeNumber)
        {
            return player.TokenOfPlayer == Token.X ? (source + cubeNumber >= 24) : (source - cubeNumber <= -1);
        }

        public bool LegalMoveForExit(ref int cubeUsed, bool isLegalMoveCube1, bool isLegalMoveCube2)
        {
            if (isLegalMoveCube1)
            {
                cubeUsed = Dice.Cube1;
            }
            if (isLegalMoveCube2)
            {
                cubeUsed = Dice.Cube2;
            }
            if (isLegalMoveCube1 && isLegalMoveCube2)
            {
                cubeUsed = Dice.Cube1 < Dice.Cube2 ? Dice.Cube1 : Dice.Cube2;
            }
            return isLegalMoveCube1 || isLegalMoveCube2;
        }

        public void UpdateAtHome(IPlayer player)
        {
            if (player.TokenOfPlayer == Token.X)
            {
                CountTokensAtHome(player, 18, 23);
            }
            if (player.TokenOfPlayer == Token.O)
            {
                CountTokensAtHome(player, 0, 5);
            }
        }
        public void CountTokensAtHome(IPlayer player, int lowRange, int hightRange)
        {
            player.SumOfTokensAtHome = 0;
            for (int i = lowRange; i <= hightRange; i++)
            {
                if (GameBoard.CellsList[i].TokenType == player.TokenOfPlayer)
                {
                    player.SumOfTokensAtHome += GameBoard.CellsList[i].SumOfTokens;
                }
            }
        }

        public bool CanStartToTakeOutTokens(IPlayer player)
        {
            return player.TokenOfPlayer == Token.X ?
                ThereAreTokensOutsideTheHome(player, 0, 17, GameBoard.TokensInTheJail_X) :// in the jail, also outside the home
                ThereAreTokensOutsideTheHome(player, 6, 23, GameBoard.TokensInTheJail_O);
        }

        public bool ThereAreTokensOutsideTheHome(IPlayer player, int lowRange, int hightRange, int sumOfOutsideTheHome)
        {
            for (int i = lowRange; i <= hightRange; i++)
            {
                if (GameBoard.CellsList[i].TokenType == player.TokenOfPlayer)// if there are tokens outside the home
                {
                    sumOfOutsideTheHome += GameBoard.CellsList[i].SumOfTokens;
                }
            }
            return (sumOfOutsideTheHome == 0);
        }

        public IEnumerable<KeyValuePair<int, int>> GetAllMoves(IPlayer player)
        {
            return player.TokenOfPlayer == Token.X ? GetAllMovesForXPlayer() : GetAllMovesForOPlayer();
        }
        public IEnumerable<KeyValuePair<int, int>> GetAllMovesForXPlayer()
        {
            var legalMoves = new List<KeyValuePair<int, int>>();
            if (GameBoard.TokensInTheJail_X == 0)
            {
                for (int i = 0; i < GameBoard.CellsList.Count; i++)
                {
                    if (!Dice.RolledDouble)
                    {
                        if (Dice.Cube1 != 0 && i + Dice.Cube1 <= 23 &&
                            IsItLegalOption(i, X_Player) &&
                            IsItLegalMove(X_Player, i, i + Dice.Cube1, Dice.Cube1, 1))
                        {
                            legalMoves.Add(new KeyValuePair<int, int>(i, i + Dice.Cube1));
                        }
                        if (Dice.Cube2 != 0 && i + Dice.Cube2 <= 23 &&
                            IsItLegalOption(i, X_Player) &&
                            IsItLegalMove(X_Player, i, i + Dice.Cube2, Dice.Cube2, 1))
                        {
                            legalMoves.Add(new KeyValuePair<int, int>(i, i + Dice.Cube2));
                        }
                    }
                }
                return legalMoves;
            }
            return GetAllMovesFromJail(X_Player);
        }

        public IEnumerable<KeyValuePair<int, int>> GetAllMovesForOPlayer()
        {
            var legalMoves = new List<KeyValuePair<int, int>>();
            if (GameBoard.TokensInTheJail_O == 0)
            {
                for (int i = 0; i < GameBoard.CellsList.Count; i++)
                {
                    if (!Dice.RolledDouble)
                    {
                        if (Dice.Cube1 != 0 && i - Dice.Cube1 >= 0 &&
                            IsItLegalOption(i, O_Player) &&
                            IsItLegalMove(O_Player, i, i - Dice.Cube1, Dice.Cube1, -1))
                        {
                            legalMoves.Add(new KeyValuePair<int, int>(i, i - Dice.Cube1));
                        }
                        if (Dice.Cube2 != 0 && i - Dice.Cube2 >= 0 &&
                            IsItLegalOption(i, O_Player) &&
                            IsItLegalMove(O_Player, i, i - Dice.Cube2, Dice.Cube2, -1))
                        {
                            legalMoves.Add(new KeyValuePair<int, int>(i, i - Dice.Cube2));
                        }
                    }
                }
                return legalMoves;
            }
            return GetAllMovesFromJail(O_Player);
        }

        public IEnumerable<KeyValuePair<int, int>> GetAllMovesToEat(IPlayer player)
        {
            return player.TokenOfPlayer == Token.X ? GetAllMovesToEatForXPlayer() : GetAllMovesToEatForOPlayer();
        }
        
        public IEnumerable<KeyValuePair<int, int>> GetAllMovesToEatForXPlayer()
        {
            var legalMoves = new List<KeyValuePair<int, int>>();
            if (GameBoard.TokensInTheJail_X == 0)
            {
                for (int i = 0; i < GameBoard.CellsList.Count; i++)
                {
                    if (!Dice.RolledDouble)
                    {
                        if (Dice.Cube1 != 0 && (i + Dice.Cube1 <= 23) &&
                            IsItLegalOption(i, X_Player) &&
                            IsItLegalMove(X_Player, i, i + Dice.Cube1, Dice.Cube1, 1))
                        {
                            legalMoves.Add(new KeyValuePair<int, int>(i, i + Dice.Cube1));
                        }
                    }
                    if (Dice.Cube2 != 0 && i + Dice.Cube2 <= 23 &&
                        IsItLegalOption(i, X_Player) &&
                        IsItLegalMove(X_Player, i, i + Dice.Cube2, Dice.Cube2, 1))
                    {
                        legalMoves.Add(new KeyValuePair<int, int>(i, i + Dice.Cube2));
                    }
                }
                return legalMoves;
            }
            return GetAllMovesFromJail(X_Player);
        }
        
        public IEnumerable<KeyValuePair<int, int>> GetAllMovesToEatForOPlayer()
        {
            var legalMoves = new List<KeyValuePair<int, int>>();
            if (GameBoard.TokensInTheJail_O == 0)
            {
                for (int i = 0; i < GameBoard.CellsList.Count; i++)
                {
                    if (!Dice.RolledDouble)
                    {
                        if (Dice.Cube1 != 0 && (i - Dice.Cube1 >= 0) &&
                            IsItLegalOption(i, O_Player) &&
                            IsItLegalMove(O_Player, i, i - Dice.Cube1, Dice.Cube1, -1))
                        {
                            legalMoves.Add(new KeyValuePair<int, int>(i, i - Dice.Cube1));
                        }
                    }
                    if (Dice.Cube2 != 0 && i - Dice.Cube2 >= 0 &&
                        IsItLegalOption(i, O_Player) &&
                        IsItLegalMove(O_Player, i, i - Dice.Cube2, Dice.Cube2, -1))
                    {
                        legalMoves.Add(new KeyValuePair<int, int>(i, i - Dice.Cube2));
                    }
                }
                return legalMoves;
            }
            return GetAllMovesFromJail(O_Player);
        }

        public IEnumerable<KeyValuePair<int, int>> GetAllMovesFromJail(IPlayer player)
        {
            return player.TokenOfPlayer == Token.X ? GetAllMovesFromJailForXPlayer() : GetAllMovesFromJailForOPlayer();
        }
   
        public IEnumerable<KeyValuePair<int, int>> GetAllMovesFromJailForXPlayer()
        {
            var legalMoves = new List<KeyValuePair<int, int>>();

            if (Dice.Cube1 != 0 && IsItLegalMove(X_Player, -1, -1 + Dice.Cube1, Dice.Cube1, 1))
            {
                legalMoves.Add(new KeyValuePair<int, int>(-1, -1 + Dice.Cube1));
            }
            if (Dice.Cube2 != 0 && IsItLegalMove(X_Player, -1, -1 + Dice.Cube2, Dice.Cube2, 1))
            {
                legalMoves.Add(new KeyValuePair<int, int>(-1, -1 + Dice.Cube2));
            }
            return legalMoves;
        }

        public IEnumerable<KeyValuePair<int, int>> GetAllMovesFromJailForOPlayer()
        {
            var legalMoves = new List<KeyValuePair<int, int>>();

            if (Dice.Cube1 != 0 && IsItLegalMove(O_Player, 24, 24 - Dice.Cube1, Dice.Cube1, -1))
            {
                legalMoves.Add(new KeyValuePair<int, int>(24, 24 - Dice.Cube1));
            }
            if (Dice.Cube2 != 0 && IsItLegalMove(O_Player, 24, 24 - Dice.Cube2, Dice.Cube2, -1))
            {
                legalMoves.Add(new KeyValuePair<int, int>(24, 24 - Dice.Cube2));
            }
            return legalMoves;
        }

        public IEnumerable<KeyValuePair<int, int>> GetAllMovesToEatFromJail(IPlayer player)
        {
            return player.TokenOfPlayer == Token.X ? GetAllMovesToEatFromJailForXPlayer() : GetAllMovesToEatFromJailForOPlayer();
        }

        public IEnumerable<KeyValuePair<int, int>> GetAllMovesToEatFromJailForXPlayer()
        {
            var legalMoves = new List<KeyValuePair<int, int>>();
            if (Dice.Cube1 != 0 &&
                IsItLegalToEat(X_Player, -1, -1 + Dice.Cube1, Dice.Cube1))
            {
                legalMoves.Add(new KeyValuePair<int, int>(-1, -1 + Dice.Cube1));
            }
            if (Dice.Cube2 != 0 &&
                IsItLegalToEat(X_Player, -1, -1 + Dice.Cube2, Dice.Cube2))
            {
                legalMoves.Add(new KeyValuePair<int, int>(-1, -1 + Dice.Cube2));
            }
            return legalMoves;
        }

        public IEnumerable<KeyValuePair<int, int>> GetAllMovesToEatFromJailForOPlayer()
        {
            var legalMoves = new List<KeyValuePair<int, int>>();
            if (Dice.Cube1 != 0 &&
                IsItLegalToEat(O_Player, 24, 24 - Dice.Cube1, Dice.Cube1))
            {
                legalMoves.Add(new KeyValuePair<int, int>(24, 24 - Dice.Cube1));
            }
            if (Dice.Cube2 != 0 &&
                IsItLegalToEat(O_Player, 24, 24 - Dice.Cube2, Dice.Cube2))
            {
                legalMoves.Add(new KeyValuePair<int, int>(24, 24 - Dice.Cube2));
            }
            return legalMoves;
        }

        public IEnumerable<KeyValuePair<int, int>> ExitMoves(IPlayer player)
        {
            return player.TokenOfPlayer == Token.X ? ExitMovesOfPlayer(X_Player, 18, 23) : ExitMovesOfPlayer(O_Player, 0, 5);
        }
        public IEnumerable<KeyValuePair<int, int>> ExitMovesOfPlayer(IPlayer player, int lowRange, int hightRange)
        {
            var legalMoves = new List<KeyValuePair<int, int>>();
            for (int i = lowRange; i <= hightRange; i++)
            {
                if (!Dice.RolledDouble &&
                    Dice.Cube1 != 0 &&
                    IsItLegalOption(i, player) &&
                    IsExitMove(player, i, Dice.Cube1))
                {
                    legalMoves.Add(new KeyValuePair<int, int>(i, Dice.Cube1));
                }
                //if RolledDouble only this will be check
                if (Dice.Cube2 != 0 &&
                    IsItLegalOption(i, player) &&
                    IsExitMove(player, i, Dice.Cube2))
                {
                    legalMoves.Add(player.TokenOfPlayer == Token.O 
                        ? new KeyValuePair<int, int>(i, i - Dice.Cube2)
                        : new KeyValuePair<int, int>(i, Dice.Cube2));
                }
            }
            return legalMoves;
        }

        public bool ThereAreLegalMoves(IPlayer player)
        {
            return GetAllMoves(player).ToList().Count + GetAllMovesToEat(player).ToList().Count > 0;
        }

        public bool ThereAreLegalExitMoves(IPlayer player)
        {
            return ExitMoves(player).ToList().Count > 0;
        }

        public bool ThereAreLegalMovesFromJail(IPlayer player)
        {
            return GetAllMovesFromJail(player).ToList().Count + GetAllMovesToEatFromJail(player).ToList().Count > 0;
        }

        public bool PlayerMoves()
        {
            return X_Player.MyTurn ? ThereAreLegalMoves(X_Player) :
                ThereAreLegalMoves(O_Player);
        }
        public bool PlayerFromJailMoves()
        {
            return X_Player.MyTurn ? ThereAreLegalMovesFromJail(X_Player) :
                ThereAreLegalMovesFromJail(O_Player);
        }
        public bool PlayerExitMoves()
        {
            return X_Player.MyTurn ? ThereAreLegalExitMoves(X_Player) :
                ThereAreLegalExitMoves(O_Player);
        }

    }
}


