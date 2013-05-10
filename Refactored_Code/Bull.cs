using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BullsAndCows
{
    class Bull : IDraw
    {

        string numberForGuessString;
        //bool[] bulls = new bool[4];
        string tryNumberString;


        public Bull(string numberForGuess, string tryNumberString)
        {
            this.numberForGuessString = numberForGuess;
            this.tryNumberString = tryNumberString;
            
        }

        public void DrawToConsole()
        {
            Console.Write(this.ToString());
        }

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

        public override string ToString()
        {
            return String.Format("Bulls: {0}",this.CountBulls());
        }

    }
}
