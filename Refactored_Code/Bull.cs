//-----------------------------------------------------------------------
// <copyright file="CommandParser.cs" company="TelerikAcademy">
//     All rights reserved © Telerik Academy 2012-2013
// </copyright>
//-----------------------------------------------------------------------

namespace BullsAndCows
{
    using System;

    class Bull : IDraw
    {
        private string numberForGuessString;
        private bool[] isBull;
        private string tryNumberString;

        public Bull(string numberForGuess, string tryNumberString, bool[] isBull)
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
            return string.Format("Bulls: {0} ", this.CountBulls());
        }

        private int CountBulls()
        {
            int bullsCount = 0;
            for (int i = 0; i < tryNumberString.Length; i++)
            {
                if (tryNumberString[i] == numberForGuessString[i])
                {
                    bullsCount++;
                    isBull[i] = true;
                }
            }
            return bullsCount;
        }

    }
}
