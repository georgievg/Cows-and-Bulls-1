using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BullsAndCows
{
    class Bull
    {

        string numberForGuessString;
        // constructor
        public Bull(string numberForGues)
        {
            this.numberForGuessString = numberForGues;
        }

        // Methods
        public int CountBulls(
            string tryNumberString, bool[] bulls)
        {
            int bullsCount = 0;
            for (int i = 0; i < tryNumberString.Length; i++)
            {
                if (tryNumberString[i] == numberForGuessString[i])
                {
                    bullsCount++;
                    bulls[i] = true;
                }
            }
            return bullsCount;
        }

    }
}
