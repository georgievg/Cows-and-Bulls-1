using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BullsAndCows
{
    public class Cow : IDraw
    {
        // constructor
        string numberForGuessString;

        string tryNumberString;

        public Cow(string numberForGues, string tryNumberString)
        {
            this.numberForGuessString = numberForGues;
            this.tryNumberString = tryNumberString;
        }


        // Methods

        public void DrawToConsole()
        {
            Console.Write(this.ToString());
        }

        public override string ToString()
        {
            return String.Format("Cows: {0}", this.CountCows());
        }

        public int CountCows()
        {
            bool[] cows = new bool[4];
            int cowsCount = 0;
            int notAllowed = 0;

            for (int z = 0; z < tryNumberString.Length; z++)
            {
                for (int indexOfBull = notAllowed; indexOfBull < tryNumberString.Length; indexOfBull++)
                {
                    if (tryNumberString[indexOfBull] == numberForGuessString[indexOfBull])
                    {
                        notAllowed = indexOfBull;
                        break;
                    }
                }

                for (int i = 0; i < tryNumberString.Length; i++)
                {

                    if (!cows[i] && !(tryNumberString[i] == numberForGuessString[i]))
                    {

                        if (tryNumberString[z] == numberForGuessString[i])
                        {
                            if (i == notAllowed)
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
