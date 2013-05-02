using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BullsAndCows
{
    public static class HallOfFame
    {
        private static List<PlayerInfo> scoreHolder;
       

         static HallOfFame()
        {
            scoreHolder = new List<PlayerInfo>();
        }

        public static void AddPlayerToScoreboard(int guesses, int numberOfCheats)
        {
            if (numberOfCheats > 0)
            {
                Console.WriteLine(
                    "You are not allowed to enter the top scoreboard.");
            }
            else
            {
                if (scoreHolder.Count < 5)
                {
                    AddPlayer(guesses);
                }
                else if (scoreHolder[4].Guesses > guesses)
                {
                    scoreHolder.RemoveAt(4);
                    AddPlayer(guesses);
                }
            }
        }

       public static void PrintScoreboard()
        {
            Console.WriteLine();
            if (scoreHolder.Count > 0)
            {
                Console.WriteLine("Scoreboard:");
                scoreHolder.Sort();
                int currentPosition = 1;
                Console.WriteLine("  {0,7} | {1}", "Guesses", "Name");
                PrintLine(40);
                foreach (var currentPlayerInfo in scoreHolder)
                {
                    Console.WriteLine("{0}| {1}",
                                      currentPosition, currentPlayerInfo);
                    PrintLine(40);
                    currentPosition++;
                }
                Console.WriteLine();
            }
            else
            {
                Console.WriteLine("Scoreboard is empty!");
            }
        }

        public static void AddPlayer(int guesses)
        {
            Console.WriteLine("You can add your nickname to top scores!");
            string playerNick = String.Empty;
            while (playerNick == String.Empty)
                try
                {
                    Console.Write("Enter your nickname: ");
                    playerNick = Console.ReadLine();
                    PlayerInfo newPlayer = new PlayerInfo(playerNick, guesses);
                    scoreHolder.Add(newPlayer);
                }
                catch (ArgumentException e)
                {
                    Console.WriteLine(e.Message);
                    continue;
                }
        }



        private static void PrintLine(int dashesForPrint)
        {
            for (int i = 0; i < dashesForPrint; i++)
            {
                Console.Write("-");
            }
            Console.WriteLine();
        }

    }
}
