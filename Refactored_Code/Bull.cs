//-----------------------------------------------------------------------
// <copyright file="CommandParser.cs" company="TelerikAcademy">
//     All rights reserved © Telerik Academy 2012-2013
// </copyright>
//-----------------------------------------------------------------------

namespace BullsAndCows
{
    using System;

    public class Bull : IDraw
    {
        private string numberForGuess;
        private bool[] isBull;
        private string tryNumber;

        public Bull(string numberForGuess, string tryNumber, bool[] isBull)
        {
            this.NumberForGuess = numberForGuess;
            this.TryNumber = tryNumber;
            this.IsBull = isBull;
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
            for (int numberIndex = 0; numberIndex < TryNumber.Length; numberIndex++)
            {
                if (TryNumber[numberIndex] == NumberForGuess[numberIndex])
                {
                    bullsCount++;
                    isBull[numberIndex] = true;
                }
            }
            return bullsCount;
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
                    throw new ArgumentOutOfRangeException(string.Format("Legth of isBull must be exactly 4. Actual legth is {0}!",this.isBull.Length));
                }
                this.isBull = value;
            }
        }
    }
}
