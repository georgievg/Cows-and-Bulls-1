using System;
using System.Collections.Generic;
using System.Text;

namespace BullsAndCows
{
    /// <summary>
    /// Class holding the high scores
    /// </summary>
    public static class HallOfFame
    {
        /// <summary>
        /// List of all <see cref="PlayerInfo"/> instances
        /// </summary>
        private static List<PlayerInfo> scoreHolder;

        private static string nickName;

        /// <summary>
        /// Gets the List of all players
        /// </summary>
        public static int PlayersCount
        {
            get
            {
                return scoreHolder.Count;
            }
        }

        /// <summary>
        /// Initializes static members of the <see cref="HallOfFame"/> class which holds <see cref="PlayerInfo"/>
        /// </summary>
        static HallOfFame()
        {
            nickName = null;
            scoreHolder = new List<PlayerInfo>();
        }

        /// <summary>
        /// Erases The Players From The ScoreBoard
        /// </summary>
        public static void EraseScoreBoard()
        {
            scoreHolder.Clear();
        }

        /// <summary>
        /// Validates the nick name for the user.
        /// </summary>
        /// <returns>Validated nick name.</returns>
        public static string ValidateNickName()
        {
            Console.WriteLine("You can add your nickname to top scores!");

            string playerNick = Console.ReadLine();

            while (playerNick == string.Empty)
            {
                playerNick = Console.ReadLine();
            }

            return playerNick;
        }

        /// <summary>
        /// Adds player to the scoreboard
        /// </summary>
        /// <param name="guesses">Amount of guesses it took of the player</param>
        /// <param name="numberOfCheats">How many cheats he used</param>
        /// <param name="nickName"> The nickName of the player </param>
        public static void AddPlayerToScoreboard(int guesses, int numberOfCheats)
        {
            if (numberOfCheats > 0)
            {
                UserInterface.PrintCheaterMessage();
            }
            else
            {
                nickName = HallOfFame.ValidateNickName();

                try
                {
                    if (scoreHolder.Count < 5)
                    {
                        AddPlayerToScoreHolder(guesses, nickName);
                    }
                    else if (scoreHolder[4].Guesses > guesses)
                    {
                        scoreHolder.RemoveAt(4);
                        AddPlayerToScoreHolder(guesses, nickName);
                    }
                }
                catch (ArgumentException e)
                {
                    Console.WriteLine(e.Message);
                }
            }
        }

        /// <summary>
        /// Add an instance of <see cref="PlayerInfo"/> to the scoreHolder
        /// </summary>
        /// <param name="guesses">How many guesses it took to the player</param>
        /// <param name="nickName">The players nickname</param>
        private static void AddPlayerToScoreHolder(int guesses, string nickName)
        {
            PlayerInfo newPlayer = new PlayerInfo(nickName, guesses);
            scoreHolder.Add(newPlayer);
        }

        /// <summary>
        /// Generates the scoreboard of all players
        /// </summary>
        /// <returns>String of the generated scoreboard</returns>
        public static string GenerateScoreBoard()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine();
            if (scoreHolder.Count > 0)
            {
                sb.AppendLine("Scoreboard:");
                sb.AppendLine();
                scoreHolder.Sort();
                int currentPosition = 1;
                sb.AppendLine(string.Format("  {0,7} | {1}", "Guesses", "Name"));
                string dashes = GenerateDashes(40);
                sb.AppendLine(dashes);
                foreach (var currentPlayerInfo in scoreHolder)
                {
                    sb.AppendLine(string.Format("{0}| {1}", currentPosition, currentPlayerInfo));
                    dashes = GenerateDashes(40);
                    sb.AppendLine(dashes);
                    currentPosition++;
                }

                sb.AppendLine();
            }
            else
            {
                sb.AppendLine("Scoreboard is empty!");
            }

            return sb.ToString();
        }

        /// <summary>
        /// Generates dashes to be printed as a separator
        /// </summary>
        /// <param name="dashesForPrint">Amount of dashes to print</param>
        /// <returns>The dashes to be printed</returns>
        private static string GenerateDashes(int dashesForPrint)
        {
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < dashesForPrint; i++)
            {
                sb.Append("-");
            }

            sb.AppendLine();
            return sb.ToString();
        }
    }
}
