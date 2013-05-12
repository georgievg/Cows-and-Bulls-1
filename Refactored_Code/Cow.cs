using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BullsAndCows
{
    public class Cow : IDraw
    {
        /// <summary>
        /// Counts how many numbers are the same as the Secret Number
        /// </summary>
        /// <returns>
        /// Prints the amount of found Cows
        /// </returns>
        private string numberForGuessString;

        private string tryNumberString;

        public Cow(string numberForGues, string tryNumberString)
        {
            this.numberForGuessString = numberForGues;
            this.tryNumberString = tryNumberString;
        }

        public void DrawToConsole()
        {
            Console.WriteLine("Cows: {0}", this.CountCows());
        }
        /// <summary>
        /// Counts the amount of Cows in the Secret Number
        /// </summary>
        public int CountCows()
        {
            bool[] cows = new bool[4];
            int cowsCount = 0;
           

            for (int z = 0; z < tryNumberString.Length; z++)
            {
                char symbol = '\0';
                for (int i = 0; i < tryNumberString.Length; i++)
                {
                    if (tryNumberString[z] == numberForGuessString[i])
                    {
                        symbol = tryNumberString[z];
                    }
                    if (!cows[i] && !(tryNumberString[i] == numberForGuessString[i]))
                    {

                        if (tryNumberString[z] == numberForGuessString[i])
                        {
                            if (numberForGuessString[z] == symbol)
                            {
                                cowsCount--;
                            }
                            cows[i] = true;
                            cowsCount++;
                            break;
                        }
                    }
                    
                }
            }

            return cowsCount;
        }
    }
}
