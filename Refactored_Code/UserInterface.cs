using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BullsAndCows
{
    public static class UserInterface
    {


        // Methods

        public static void PrintGameRulesMessage()
        {
            Console.WriteLine(
          "Welcome to “Bulls and Cows” game." + Environment.NewLine +
          "Please try to guess my secret 4-digit number." + Environment.NewLine +
          "Use 'top' to view the top scoreboard." + Environment.NewLine +
          "'Restart' to start a new game." + Environment.NewLine +
          "'Help' to cheat." + Environment.NewLine,
          "'Exit' to quit the game." + Environment.NewLine );
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

        public static void PrintCheaterMessage()
        {
            Console.WriteLine(
                    "You are not allowed to enter the top scoreboard.");
        }
    }
}
