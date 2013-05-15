//-----------------------------------------------------------------------
// <copyright file="CommandParser.cs" company="TelerikAcademy">
//     All rights reserved © Telerik Academy 2012-2013
// </copyright>
//-----------------------------------------------------------------------

namespace BullsAndCows
{
    using System;

    public class Cow : IDraw
    {
        /// <summary>
        /// Counts how many numbers are the same as the Secret Number
        /// </summary>
        /// <returns>
        /// Prints the amount of found Cows
        /// </returns>
        private string numberForGuessString;
        private int cowsCount;
        private string tryNumberString;
        private bool[] isBull;

        public Cow(string numberForGuess, string tryNumberString, bool[] isBull)
        {
            this.numberForGuessString = numberForGuess;
            this.tryNumberString = tryNumberString;
            this.isBull = isBull;
        }

        /// <summary>
        /// Gets the count of the Bulls
        /// </summary>
        /// <returns>Formatted string</returns>
        public string GetPrintableCount()
        {
            return string.Format("Cows: {0}", this.CountCows());
        }

        /// <summary>
        /// Counts the amount of Cows in the Secret Number
        /// </summary>
       
        private int CountCows()
        {
            bool[] cows = new bool[4];
            for (int i = 0; i < tryNumberString.Length; i++)
            {
                //int digitForTry = int.Parse(tryNumberString[i].ToString());
                if (!isBull[i])
                {
                    cowsCount = CountCowsForCurrentDigit(tryNumberString, cowsCount, isBull, cows, i);
                }
            }
            return cowsCount;
        }

        private int CountCowsForCurrentDigit(
            string tryNumberString, int cowsCount, bool[] bulls, bool[] cows, int i)
        {
            for (int j = 0; j < tryNumberString.Length; j++)
            {
                if (tryNumberString[i] == numberForGuessString[j])
                {
                    if (!bulls[j] && !cows[j])
                    {
                        cows[j] = true;
                        cowsCount++;
                        return cowsCount;
                    }
                }
            }
            return cowsCount;
        }
    }
}