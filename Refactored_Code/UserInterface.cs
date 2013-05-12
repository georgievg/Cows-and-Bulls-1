//-----------------------------------------------------------------------
// <copyright file="UserInterface.cs" company="TelerikAcademy">
//     All rights reserved © Telerik Academy 2012-2013
// </copyright>
//-----------------------------------------------------------------------
namespace BullsAndCows
{
    using System;

    /// <summary>
    /// Provides the user interface in the game
    /// </summary>
    public static class UserInterface
    {
        /// <summary>
        /// Prints the game rules
        /// </summary>
        public static void PrintGameRulesMessage()
        {
            Console.WriteLine(
          "Welcome to “Bulls and Cows” game." + Environment.NewLine +
          "Please try to guess my secret 4-digit number." + Environment.NewLine +
          "Use 'top' to view the top scoreboard." + Environment.NewLine +
          "'Restart' to start a new game." + Environment.NewLine +
          "'Help' to cheat." + Environment.NewLine,
          "'Exit' to quit the game." + Environment.NewLine);
        }

        /// <summary>
        /// Print message on console to congratulate the user for guessing the secret number
        /// </summary>
        /// <param name="numberOfMoves">the count of moves that were made</param>
        /// <param name="numberOfCheats">the count of cheats that were made</param>
        public static void PrintCongratulationMessage(int numberOfMoves, int numberOfCheats)
        {
            Console.Write("Congratulations! You guessed the secret number in {0} attempts ", numberOfMoves);

            if (numberOfCheats != 0)
            {
                Console.Write("and {0} cheats", numberOfCheats);
            }

            Console.WriteLine(".");
        }

        /// <summary>
        /// Print information to users that used cheats
        /// </summary>
        public static void PrintCheaterMessage()
        {
            Console.WriteLine(
                    "You are not allowed to enter the top scoreboard.");
        }
    }
}
