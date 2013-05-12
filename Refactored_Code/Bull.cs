using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BullsAndCows
{
    class Bull : IDraw
    {
        /// <summary>
        /// Counts how many numbers matchs in the same place with the Guess Number
        /// </summary>
        /// <returns>
        /// Prints the amount of found Bulls
        /// </returns>
        private string numberForGuessString;
        //bool[] bulls = new bool[4];
        private string tryNumberString;

        public Bull(string numberForGuess, string tryNumberString)
        {
            this.numberForGuessString = numberForGuess;
            this.tryNumberString = tryNumberString;   
        }

        public void DrawToConsole()
        {
            Console.Write("Bulls: {0} ", this.CountBulls());
        }
        /// <summary>
        /// Counts the amount of Bulls in the Guess Number
        /// </summary>
        private int CountBulls()
        {
            int bullsCount = 0;
            for (int i = 0; i < tryNumberString.Length; i++)
            {
                if (tryNumberString[i] == numberForGuessString[i])
                {
                    bullsCount++;
                    //bulls[i] = true;
                }
            }
            return bullsCount;
        }

    }
}
