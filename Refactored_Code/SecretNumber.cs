//-----------------------------------------------------------------------
// <copyright file="SecretNumber.cs" company="TelerikAcademy">
//     All rights reserved © Telerik Academy 2012-2013
// </copyright>
//-----------------------------------------------------------------------

namespace BullsAndCows
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    /// <summary>
    /// Class generating 'secret number' and defining all logic connected to it.
    /// </summary>
    public class SecretNumber
    {
        private const char HidingSymbol = 'X';
        private const int SecretNumberLenght = 4;
        private char[] helpingNumber;
        private string numberToGuess;
        private Random randomNumberGenerator = new Random();

        /// <summary>
        /// Initializes a new instance of the <see cref="SecretNumber"/> class.
        /// </summary>
        public SecretNumber()
        {
            this.helpingNumber = new char[SecretNumber.SecretNumberLenght];
            this.GenerateNumberForGuess();
            this.GenerateHelpingNumber();
            this.NumberToGuess = this.numberToGuess;
        }

        /// <summary>
        /// Gets the generated secret number value.
        /// </summary>
        public string Value
        {
            get
            {
                return this.numberToGuess;
            }
        }

        /// <summary>
        /// Check is the user guess is right.
        /// </summary>
        /// <param name="numberToTry">Number representing try of the user to guess the secret number</param>
        /// <returns>True for right guess and false for opposite.</returns>
        public bool IsEqualToNumberForTry(string numberToTry)
        {
            bool isEqualToNumberForTry = numberToTry == this.NumberToGuess;

            return isEqualToNumberForTry;
        }

        /// <summary>
        /// Used in the <see cref="PrintHelpingNumber()"/> to print on the Console all numbers revealed by the command 'help'. 
        /// </summary>
        public string GetHelpingNumber()
        {
            this.RevealDigit();
            StringBuilder sb = new StringBuilder();
            sb.Append("The number looks like ");
            foreach (char ch in this.helpingNumber)
            {
                sb.Append(ch);
            }

            sb.Append(".");
            sb.AppendLine();

            return sb.ToString();
        }

        private void RevealDigit()
        {
            bool isRevealed = false;

            while (!isRevealed)
            {
                int digitForReveal = randomNumberGenerator.Next(0, SecretNumber.SecretNumberLenght);

                if (this.helpingNumber[digitForReveal] == SecretNumber.HidingSymbol)
                {
                    this.helpingNumber[digitForReveal] = this.numberToGuess[digitForReveal];
                    isRevealed = true;
                }
            }
        }

        private void GenerateNumberForGuess()
        {
            StringBuilder fourDigitNumber = new StringBuilder();

            for (int numberCount = 0; numberCount < SecretNumber.SecretNumberLenght; numberCount++)
            {
                fourDigitNumber.Append(this.randomNumberGenerator.Next(0, 9));
            }

            this.numberToGuess = fourDigitNumber.ToString();
        }

        private void GenerateHelpingNumber()
        {
            for (int helpingNumberIndex = 0; helpingNumberIndex < this.helpingNumber.Length; helpingNumberIndex++)
            {
                this.helpingNumber[helpingNumberIndex] = SecretNumber.HidingSymbol;
            }
        }

        private string NumberToGuess
        {
            get
            {
                return this.numberToGuess;
            }
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new NullReferenceException(string.Format("Number for guess the game number entered from the user can't be an empty string!"));
                }
                if (value.Length != 4)
                {
                    throw new ArgumentOutOfRangeException(string.Format("Lenght of number for guess must be exaclty 4. Actual length is {0}!", this.numberToGuess.Length));
                }
                this.numberToGuess = value;
            }
        }
    }
}
