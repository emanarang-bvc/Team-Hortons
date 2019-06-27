using System;
using System.Collections.Generic;
using System.Text;

namespace ConnectFour
{
    /// <summary>
    /// This class contains functions used for calculating figures needed for the board.
    /// </summary>
    static class Calculation
    {
        /// <summary>
        /// Gets the index value of the lowest available slot in the column.
        /// </summary>
        /// <param name="pieces">Array representing the board.</param>
        /// <param name="choice">Selected column index (zero-based).</param>
        /// <returns></returns>
        public static int GetAvailableIndex(sbyte[] pieces, int colIndex)
        {
            int index = colIndex;
            for (int i = colIndex; i <= 41; i += 7)
            {
                if (pieces[i] == 0)
                    index = i;
                else
                    break;
            }

            return index;
        }

        /// <summary>
        /// This function checks if there is a Connect Four in a row containing the index.
        /// </summary>
        /// <param name="pieces">Array representing board state.</param>
        /// <param name="token">Token of player saved in the array.</param>
        /// <param name="index">Index where a new token is placed.</param>
        /// <returns>True if there is a connect four.</returns>
        public static bool CheckHorizontalWin(sbyte[] pieces, sbyte token, int index)
        {
            // Limit is 3 spaces from the index.
            int lowerLimit = (index - 3 > (index / 7) * 7) ? index -3 : (index / 7) * 7;
            int upperLimit = (index + 3 < ((index / 7) * 7) + 6) ? index + 3 : ((index / 7) * 7) + 6;

            // Check if there is a connect four.
            for (int i = lowerLimit; i <= upperLimit - 3; i++)
            {
                if (pieces[i] + pieces[i + 1] + pieces[i + 2] + pieces[i + 3] == 4 * token)
                    return true;
            }

            return false;
        }

        /// <summary>
        /// This function checks if there is a Connect Four in a column containing the index.
        /// </summary>
        /// <param name="pieces">Array representing board state.</param>
        /// <param name="token">Token of player saved in the array.</param>
        /// <param name="index">Index where a new token is placed.</param>
        /// <returns>True if there is a connect four.</returns>
        public static bool CheckVerticalWin(sbyte[] pieces, sbyte token, int index)
        {
            // Limit is 3 spaces from the index.
            int lowerLimit = (index % 7 > index - 21) ? index % 7 : index -21;
            int upperLimit = (index + 21 < (index % 7) +35) ? index + 21 : (index % 7) + 35;

            // Check if there is a connect four.
            for (int i = lowerLimit; i <= upperLimit - 21; i+= 7)
            {
                if (pieces[i] + pieces[i + 7] + pieces[i + 14] + pieces[i + 21] == 4 * token)
                    return true;
            }

            return false;
        }

        /// <summary>
        /// This function checks if there is a Connect Four in a diagonal (from upper left to lower right) 
        ///     containing the index.
        /// </summary>
        /// <param name="pieces">Array representing board state.</param>
        /// <param name="token">Token of player saved in the array.</param>
        /// <param name="index">Index where a new token is placed.</param>
        /// <returns>True if there is a connect four.</returns>
        public static bool CheckDiagonalWin1(sbyte[] pieces, sbyte token, int index)
        {
            int lowerLimit = index;
            int upperLimit = index;

            // Limit is 3 spaces from the index.
            for (int i = 1; i <= 3; i++)
            {
                if (lowerLimit / 7 > 0 && lowerLimit % 7 > 0)
                    lowerLimit -= 8;

                if (upperLimit < 35 && upperLimit % 7 < 6)
                    upperLimit += 8;
            }

            // Check if there is a connect four.
            for (int i = lowerLimit; i <= upperLimit - 24; i += 8)
            {
                if (pieces[i] + pieces[i + 8] + pieces[i + 16] + pieces[i + 24] == 4 * token)
                    return true;
            }

            return false;
        }

        /// <summary>
        /// This function checks if there is a Connect Four in a diagonal (from upper right to lower left) 
        ///     containing the index.
        /// </summary>
        /// <param name="pieces">Array representing board state.</param>
        /// <param name="token">Token of player saved in the array.</param>
        /// <param name="index">Index where a new token is placed.</param>
        /// <returns>True if there is a connect four.</returns>
        public static bool CheckDiagonalWin2(sbyte[] pieces, sbyte token, int index)
        {
            int lowerLimit = index;
            int upperLimit = index;

            // Limit is 3 spaces from the index.
            for (int i = 1; i <= 3; i++)
            {
                if (lowerLimit / 7 > 0 && lowerLimit % 7 < 6)
                    lowerLimit -= 6;

                if (upperLimit < 35 && upperLimit % 7 > 0)
                    upperLimit += 6;
            }

            // Check if there is a connect four.
            for (int i = lowerLimit; i <= upperLimit - 18; i += 6)
            {
                if (pieces[i] + pieces[i + 6] + pieces[i + 12] + pieces[i + 18] == 4 * token)
                    return true;
            }

            return false;
        }
    }
}
