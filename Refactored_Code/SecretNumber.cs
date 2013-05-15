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
            this.numberToGuess = null;
            this.GenerateNumberForGuess();
            this.GenerateHelpingNumber();
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
            bool isEqualToNumberForTry = numberToTry == this.numberToGuess;

            return isEqualToNumberForTry;
        }

        /// <summary>
        /// Used in the <see cref="PrintHelpingNumber()"/> to print on the Console all numbers revealed by the command 'help'. 
        /// </summary>
        public void PrintHelpingNumber()
        {
            this.RevealDigit();
            Console.Write("The number looks like ");
            foreach (char ch in this.helpingNumber)
            {
                Console.Write(ch);
            }

            Console.Write(".");
            Console.WriteLine();
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
    }
}
