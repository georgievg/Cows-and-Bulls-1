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
        private string numberForGuess;
        private string tryNumber;
        private bool[] isBull;

        public Cow(string numberForGuess, string tryNumberString, bool[] isBull)
        {
            this.NumberForGuess = numberForGuess;
            this.TryNumber = tryNumberString;
            this.IsBull = isBull;
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
            bool[] isCow = new bool[4];
            int cowsCount = 0;
            for (int numberIndex = 0; numberIndex < this.TryNumber.Length; numberIndex++)
            {
                if (!this.IsBull[numberIndex])
                {
                    cowsCount = CountCowsForCurrentDigit(this.TryNumber, cowsCount, this.IsBull, isCow, numberIndex);
                }
            }
            return cowsCount;
        }

        private int CountCowsForCurrentDigit(
            string tryNumberString, int cowsCount, bool[] bulls, bool[] cows, int numberIndex)
        {
            for (int currNumberIndex = 0; currNumberIndex < tryNumberString.Length; currNumberIndex++)
            {
                if (tryNumberString[numberIndex] == numberForGuess[currNumberIndex])
                {
                    if (!bulls[currNumberIndex] && !cows[currNumberIndex])
                    {
                        cows[currNumberIndex] = true;
                        cowsCount++;
                        return cowsCount;
                    }
                }
            }
            return cowsCount;
        }

        private string NumberForGuess
        {
            get
            {
                return this.numberForGuess;
            }
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new NullReferenceException(string.Format("Number for guess the game number entered from the user can't be an empty string!"));
                }
                if (value.Length != 4)
                {
                    throw new ArgumentOutOfRangeException(string.Format("Lenght of number for guess must be exaclty 4. Actual length is {0}!", this.numberForGuess.Length));
                }
                this.numberForGuess = value;
            }
        }
        private string TryNumber
        {
            get
            {
                return this.tryNumber;
            }
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new NullReferenceException(string.Format("Number for try to guess the game number entered from the user can't be an empty string!"));
                }
                if (value.Length != 4)
                {
                    throw new ArgumentOutOfRangeException(string.Format("Lenght of number for try must be exaclty 4. Actual length is {0}!", this.tryNumber.Length));
                }
                this.tryNumber = value;
            }
        }

        private bool[] IsBull
        {
            get
            {
                return this.isBull;
            }
            set
            {
                if (value == null)
                {
                    throw new NullReferenceException(string.Format("isBool must be instanced befour being passed to the costrucotor of the Bull class!"));
                }
                if (value.Length != 4)
                {
                    throw new ArgumentOutOfRangeException(string.Format("Legth of isBull must be exactly 4. Actual legth is {0}!", this.isBull.Length));
                }
                this.isBull = value;
            }
        }
    }
}