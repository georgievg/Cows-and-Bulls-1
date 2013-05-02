using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BullsAndCows
{
    public static class UserInterface
    {


        // Methods

        public static void GameRulesMessage()
        {
            Console.WriteLine(
          "Welcome to “Bulls and Cows” game." + Environment.NewLine +
          "Please try to guess my secret 4-digit number." + Environment.NewLine +
          "Use 'top' to view the top scoreboard, 'restart'" + Environment.NewLine +
          "to start a new game and 'help'" + Environment.NewLine +
          " to cheat and 'exit' to quit the game.");
        }

        public static void PrintCongratulationMessage(int numberOfMoves, int numberOfCheats)
        {
            Console.Write("Congratulations! You guessed the secret number in {0} attempts ",numberOfMoves);

            if (numberOfCheats != 0)
            {
                Console.Write("and {0} cheats", numberOfCheats);
            }
            Console.WriteLine(".");
        }
    }
}
