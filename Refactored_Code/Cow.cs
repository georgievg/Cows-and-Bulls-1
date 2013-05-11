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
            Console.WriteLine("Cows: {0}", this.CountCows());
        }

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
