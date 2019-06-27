using System;
using System.Collections.Generic;
using System.Text;

namespace ConnectFour
{
    // <summary>
    /// This is the PlayerComputer class that will handle the information of the AI player.
    /// </summary>
    public class PlayerComputer : Player
    {
        private ComputerDifficulty _level;
        private Random _rand;

        public ComputerDifficulty ComputerLevel
        {
            get { return _level;  }
        }

        /// <summary>
        /// The PlayerComputer class constructor. Set isHuman to false.
        /// </summary>
        /// <param name="name">Name of the player.</param>
        public PlayerComputer(string name, ComputerDifficulty level) : base(name)
        {
            _level = level;
            _isHuman = false;
            _rand = new Random();
        }

        /// <summary>
        /// This method returns the computer's move. Move based on the difficulty level.
        /// </summary>
        /// <param name="pieces">Array representing pieces on the board.</param>
        /// <returns>Index in the array corresponding to the user's choice.</returns>
        public override int Move(sbyte[] pieces)
        {
            int index = 0;

            // Check difficulty, then return the selected index.

            return index;
        }

        /// <summary>
        /// Gives a random move depending on column availability.
        /// </summary>
        /// <param name="pieces">Array representing pieces on the board.</param>
        /// <returns>Column index (zero-based).</returns>
        private int RandomMove(sbyte[] pieces)
        {
            // List all valid columns (columns that are not filled) and randomize through them
            return 0;
        }
    }
}
