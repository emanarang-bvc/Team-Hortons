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
            // Setup Opponent

            Player currentPlayer; // Set this player as a random 
            int index = 0; // This is the array index where we will put either 1 (player 1) or -1 (player 2)

            // Start loop
            // Switch players/get the opponent every start of the loop.

            // If current player is human, display the board.

            index = 0; // Get the player's move.
            // If index < 0, then the player selected quit.
            
            // Else, place token (1 or -1) in array using our index

            //Increament moveCount;
            
            // Iterate through loop until its the end of the game.
                        
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

            // If human, loop asking for a valid name (similar to player 1)
            
            _player2 = new PlayerHuman(str);
            // Else, ask for computer difficulty

            ComputerDifficulty level = ComputerDifficulty.Random;
            _player2 = new PlayerComputer("Computer(" + level.ToString() + ")", level);
            
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
            // Randomize between _player1 and _player2
            return _player1;
        }

        /// <summary>
        /// Checks if game has already ended either by a win or by draw or by quitting.
        /// </summary>
        /// <returns>Returns true if a player wins of board is filled or a player quits, otherwise false.</returns>
        private bool CheckEndGame(Player player, int index)
        {
            // Check first if winning move.
            
            // Check if draw.
            
            // Else, not end game.
            
        }

        /// <summary>
        ///Checks if there is already a winner.
        /// </summary>
        /// <param name="player">Current player.</param>
        /// <returns>True if player wins, else false.</returns>
        private bool CheckWin(Player player, int index)
        {
            // Check combination for all orientations
            
            // If win, display the finished board and message

            return false;
        }

        /// <summary>
        /// Checks if the board is filled.
        /// </summary>
        /// <returns></returns>
        private bool CheckDraw()
        {
            //Check if number of moves reached 42

            // If draw, display the board and message

            return false;
        }

        /// <summary>
        /// If a player quits, display message.
        /// </summary>
        /// <param name="player"></param>
        /// <returns></returns>
        private void Quit(Player player)
        {
            // Display quit message.
        }

        /// <summary>
        /// Returns the opponent of the supplied player.
        /// </summary>
        /// <param name="player">Either the player or the opponent.</param>
        /// <returns>The player opposite the player supplied in the paramenter/</returns>
        private Player GetOpponent(Player player)
        {
            // Just return the other player
            return _player1;
        }

        #endregion
    }
}
