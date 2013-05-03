using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BullsAndCows
{
    public class Cow
    {
       // constructor
        string numberForGuessString;

        public Cow(string numberForGues)
        {
            this.numberForGuessString = numberForGues;
        }


        // Methods
        public int CountCows(
            string tryNumberString, bool[] bulls, bool[] cows)
        {
            int cowsCount = 0;
            for (int i = 0; i < tryNumberString.Length; i++)
            {
                int digitForTry = int.Parse(tryNumberString[i].ToString());
                if (!bulls[i] && !cows[digitForTry])
                {
                    cows[digitForTry] = true;
                    cowsCount =
                    CountCowsForCurrentDigit(
                        tryNumberString, cowsCount, bulls, i);
                }
            }
            return cowsCount;
        }

        private int CountCowsForCurrentDigit(
            string tryNumberString, int cowsCount, bool[] bulls, int i)
        {
            for (int j = 0; j < tryNumberString.Length; j++)
            {
                if (tryNumberString[i] == numberForGuessString[j])
                {
                    if (!bulls[j])
                    {
                        cowsCount++;
                    }
                }
            }
            return cowsCount;
        }

    }
}
