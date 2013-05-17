//-----------------------------------------------------------------------
// <copyright file="HallOfFame.cs" company="TelerikAcademy">
//     All rights reserved © Telerik Academy 2012-2013
// </copyright>
//-----------------------------------------------------------------------
namespace BullsAndCows
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    /// <summary>
    /// Class holding the high scores
    /// </summary>
    public static class HallOfFame
    {
        private static List<PlayerInfo> scoreHolder;

        /// <summary>
        /// Initializes static members of the <see cref="HallOfFame"/> class which holds <see cref="PlayerInfo"/>
        /// </summary>
        static HallOfFame()
        {
            scoreHolder = new List<PlayerInfo>();
        }

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
        /// Erases The Players From The ScoreBoard
        /// </summary>
        public static void EraseScoreBoard()
        {
            scoreHolder.Clear();
        }

        private static void ValidateNickName(string nickName)
        {
            if (string.IsNullOrEmpty(nickName))
            {
                throw new NullReferenceException("NickName can not be empty");
            }
        }

        /// <summary>
        /// Adds player to the scoreboard
        /// </summary>
        /// <param name="guesses">Amount of guesses it took of the player</param>
        /// <param name="numberOfCheats">How many cheats he used</param>
        /// <param name="nick">The nickName of the player to be added</param>
        public static void AddPlayerToScoreboard(int guesses, int numberOfCheats, string nick)
        {
            ValidateNickName(nick);
            if (numberOfCheats > 0)
            {
                UserInterface.PrintCheaterMessage();
            }
            else
            {
                if (scoreHolder.Count < 5)
                {
                    AddPlayerToScoreHolder(guesses, nick);
                }
                else if (scoreHolder[4].Guesses > guesses)
                {
                    scoreHolder.RemoveAt(4);
                    AddPlayerToScoreHolder(guesses, nick);
                }
            }
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

        private static void AddPlayerToScoreHolder(int guesses, string nickName)
        {
            PlayerInfo newPlayer = new PlayerInfo(nickName, guesses);
            scoreHolder.Add(newPlayer);
            scoreHolder.Sort();
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
