﻿using System;
using System.Collections.Generic;
using System.Text;

namespace ConnectFour
{
    /// <summary>
    /// This is the PlayerHuman class that will handle the information of the human player.
    /// </summary>
    public class PlayerHuman: Player
    {
        /// <summary>
        /// The PlayerHuman class constructor. Set isHuman to true.
        /// </summary>
        /// <param name="name">Name of the player.</param>
        public PlayerHuman(string name):base(name)
        {
            _isHuman = true;
        }

        /// <summary>
        /// This takes care of the players move. It will get the player input and check if valid.
        /// </summary>
        /// <param name="pieces">Array representing pieces on the board.</param>
        /// <returns>Index in the array corresponding to the user's choice.</returns>
        public override int Move(sbyte[] pieces)
        {
            string str = string.Empty;

            // Loop until the player gives a valid choice

            // Return -1 if choice is Q or else return the corresponding index.
        }

        /// <summary>
        /// Checks if the choice entered by the user is a valid choice (meaning 1-7 and Q).
        /// </summary>
        /// <param name="pieces">Array representing pieces on the board.</param>
        /// <param name="choice">Player's input.</param>
        /// <returns>True if choice is valid, false if not.</returns>
        private bool CheckValidChoice(sbyte[] pieces, char choice)
        {
            // Check if the user selected Quit or a column that isn't filled.
            return false;
        }
    }
}
