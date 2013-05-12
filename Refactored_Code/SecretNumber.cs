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
        /// <summary>
        /// Symbol representing starting state of the digits in <see cref="helpingNumber"/>.
        /// </summary>
        private const char HidingSymbol = 'X';

        /// <summary>
        /// Number of the digits for the secret number.
        /// </summary>
        private const int SecretNumberLenght = 4;

        /// <summary>
        /// Container for hiding  partially the secret number from the user when use 'help' command, depending of how many times is used the command.
        /// </summary>
        private char[] helpingNumber;

        /// <summary>
        /// Symbol used to hide the unrevealed digits of the secret number.
        /// </summary>
        private string numberToGuess;

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
        /// Reveals one digit from the secret number each time is invoked and print it on the Console.
        ///     Never reveals already revealed digit.
        /// </summary>
        public void RevealDigit()
        {
            bool isRevealed = false;

            while (!isRevealed)
            {
                Random randomIndexGenerator = new Random();
                int digitForReveal = randomIndexGenerator.Next(0, SecretNumber.SecretNumberLenght);

                if (this.helpingNumber[digitForReveal] == SecretNumber.HidingSymbol)
                {
                    this.helpingNumber[digitForReveal] = this.numberToGuess[digitForReveal];
                    isRevealed = true;
                }
            }

            this.PrintHelpingNumber();
        }

        /// <summary>
        /// Used in the <see cref="PrintHelpingNumber()"/> to print on the Console all numbers revealed by the command 'help'. 
        /// </summary>
        private void PrintHelpingNumber()
        {
            Console.Write("The number looks like ");
            foreach (char ch in this.helpingNumber)
            {
                Console.Write(ch);
            }

            Console.Write(".");
            Console.WriteLine();
        }

        /// <summary>
        /// Generate a secret number for the user to guess in the range of 0000 - 9999.
        /// </summary>
        private void GenerateNumberForGuess()
        {
            Random randomSecretNumberGenerator = new Random();
            StringBuilder fourDigitNumber = new StringBuilder();

            for (int numberCount = 0; numberCount < SecretNumber.SecretNumberLenght; numberCount++)
            {
                fourDigitNumber.Append(randomSecretNumberGenerator.Next(0, 9));
            }

            this.numberToGuess = fourDigitNumber.ToString();
        }

        /// <summary>
        /// Initialize <see cref="helpingNumber"/> with hiding symbol <see cref="HidingSymbol"/>.
        /// </summary>
        private void GenerateHelpingNumber()
        {
            for (int helpingNumberIndex = 0; helpingNumberIndex < this.helpingNumber.Length; helpingNumberIndex++)
            {
                this.helpingNumber[helpingNumberIndex] = SecretNumber.HidingSymbol;
            }
        } 
    }
}
