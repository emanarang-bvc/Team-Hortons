using System;

namespace ConnectFour
{
    /// <summary>
    ///  This class handles the flow and implements the rules regarding the game Connect Four
    /// </summary>
    public class ConnectFour
    {
        #region Members and Constructor

        /// <summary>
        /// This array records which position is held by a player. 
        ///     A value of 1 will be for First Player and -1 for Second Player.
        /// </summary>
        private sbyte[] _pieces;
        private byte _moveCount = 0;
        private Player _player1;
        private Player _player2;

        /// <summary>
        ///  Constructor of ConnectFour class.
        /// </summary>
        public ConnectFour()
        {
            // Initialize game board state
            _pieces = new sbyte[42];
            _moveCount = 0;
        }

        #endregion

        #region Public Method

        /// <summary>
        /// New Game will be the entry point of the game and will handle all parts of the game.
        /// </summary>
        public void NewGame()
        {

            // Setup First Player
            SetupPlayer();

            // Setup Opponent
            SetupOpponent();

            // Set this player as a random 
            Player currentplayer = SelectRandomPlayer();

            // This is the array index where we will put either 1 (player 1) or -1 (player 2)
            int index = 0; 

            // Start loop
            do
            {
                // Switch players/get the opponent every start of the loop.
                currentplayer = GetOpponent(currentplayer);

                // If current player is human, display the board.
                if (currentplayer.IsHuman)
                {
                    Display.DisplayBoard(_pieces, true);
                }

                index = currentplayer.Move(_pieces);
                // If index < 0, then the player selected quit.
                if (index < 0)
                {
                    Quit(currentplayer);
                    Console.WriteLine();
                    return;
                }
                else
                {
                    // Else, place token (1 or -1) in array using our index
                    _pieces[index] = currentplayer.Token;
                }

                //Increament moveCount;
                _moveCount++;
            
                // Iterate through loop until its the end of the game.
            } while (!CheckEndGame(currentplayer, index));
            Console.WriteLine();
        }

        #endregion

        #region Private Methods

        /// <summary>
        /// Sets the information of Player.
        /// </summary>
        private void SetupPlayer()
        {
            string str = string.Empty;
            // Loop as long as user is giving an empty string or white space.
            do
            {
                Console.WriteLine("Enter name of Player 1: ");
                str = Console.ReadLine().Trim();

            } while (str.Length == 0);

            // Initialize Player 1.
            _player1 = new PlayerHuman(str);
            _player1.PlayerColor = ConsoleColor.Red;
            _player1.Token = 1;
            Console.WriteLine();
        }

        /// <summary>
        /// Sets the information of the Opponent.
        /// </summary>
        private void SetupOpponent()
        {
            string str = string.Empty;

            // Loop asking if opponont is human or computer
            do
            {
                Display.MenuSelectOpponent(_player1.Name, _player1.PlayerColor);

                str = Console.ReadLine().Trim().ToUpper();
                if (str.Length == 0)
                    str = "X";
            } while (str[0] != 'H' && str[0] != 'C');

            bool isHuman = str[0] == 'H' ? true : false;
            // If human, loop asking for a valid name (similar to player 1)
            if (isHuman)
            {
                do
                {
                    Console.WriteLine("Enter Name of Player 2: ");
                    str = Console.ReadLine().Trim();

                    if (str.ToUpper() == _player1.Name.ToUpper())
                    {
                        Console.WriteLine("Sorry, but {0} is already taken!", str);
                    }
                } while (str.Length == 0 || str.ToUpper() == _player1.Name.ToUpper());

                _player2 = new PlayerHuman(str);

            }
            else
            {
                // Computer opponent, ask for difficulty
                do
                {
                    Display.MenuSelectDifficulty();
                    str = Console.ReadLine().Trim();
                    if (str.Length == 0)
                        str = "x";

                } while (str[0] != '0' && str[0] != '1' && str[0] != '2' && str[0] != '3');



                ComputerDifficulty level = ComputerDifficulty.Random;
                if (str[0] == '1')
                    level = ComputerDifficulty.Easy;
                else if (str[0] == '2')
                    level = ComputerDifficulty.Normal;
                else if (str[0] == '3')
                    level = ComputerDifficulty.Advanced;

                _player2 = new PlayerComputer("Computer(" + level.ToString() + ")", level);
            }

            // Supply the rest of the information for all cases.
            _player2.PlayerColor = ConsoleColor.Yellow;
            _player2.Token = -1;
            

        }

        /// <summary>
        /// Randomly selects which player to move first.
        /// </summary>
        /// <returns></returns>
        private Player SelectRandomPlayer()
        {
            Random random = new Random();
            var select = random.Next(2);
            // Randomize between _player1 and _player2
            if (select == 0)
            {
                return _player1;
            }
            else
            {
                return _player2;
            }
        }

        /// <summary>
        /// Checks if game has already ended either by a win or by draw or by quitting.D:\Team-Hortons-master\ConnectFour\ConnectFour\Classes\ConnectFour.cs
        /// </summary>
        /// <returns>Returns true if a player wins of board is filled or a player quits, otherwise false.</returns>
        private bool CheckEndGame(Player player, int index)
        {
            // Check first if winning move.
            if (CheckWin(player, index))
                return true;
            // Check if draw.
            else if (CheckDraw())
                return true;
            // Else, not end game.
            else
                return false;
        }

        /// <summary>
        ///Checks if there is already a winner.
        /// </summary>
        /// <param name="player">Current player.</param>
        /// <returns>True if player wins, else false.</returns>
        private bool CheckWin(Player player, int index)
        {
            bool isWin = false;
            // Check combination for all orientations.
            if (Calculation.CheckVerticalWin(_pieces, player.Token, index))
                isWin = true;
            else if (Calculation.CheckHorizontalWin(_pieces, player.Token, index))
                isWin = true;
            else if (Calculation.CheckDiagonalWin1(_pieces, player.Token, index))
                isWin = true;
            else if (Calculation.CheckDiagonalWin2(_pieces, player.Token, index))
                isWin = true;

            // If win, display the finished board and message
            if (isWin)
            {
                Display.DisplayBoard(_pieces, false);
                Display.MessageWin(player.Name, player.PlayerColor);
            }

            return isWin;
        }

        /// <summary>
        /// Checks if the board is filled.
        /// </summary>
        /// <returns></returns>
        private bool CheckDraw()
        {

            //Check if number of moves reached 42
            bool endinDraw = _moveCount >= 42;

            // If draw, display the board and message
            if (endinDraw)
            {
                Display.DisplayBoard(_pieces, false);
                Display.MessageDraw(_player1.Name, _player1.PlayerColor, _player2.Name, _player2.PlayerColor);


            }
            return endinDraw;
        }

        /// <summary>
        /// If a player quits, display message.
        /// </summary>
        /// <param name="player"></param>
        /// <returns></returns>
        private void Quit(Player player)
        {
            // Display quit message.
            Player opponent = GetOpponent(player);
            Console.WriteLine();
            Display.MessageResignation(player.Name, player.PlayerColor, opponent.Name, opponent.PlayerColor);
        }

        /// <summary>
        /// Returns the opponent of the supplied player.
        /// </summary>
        /// <param name="player">Either the player or the opponent.</param>
        /// <returns>The player opposite the player supplied in the paramenter/</returns>
        private Player GetOpponent(Player player)
        {
            // Just return the other player
            if (player == _player1)
                return _player2;
            else
                return _player1;
        }

        #endregion
    }


}
