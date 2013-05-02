using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BullsAndCows
{
    public class Engine
    {

        // Fileds
        private int numberOfCheats;
        private int numberOfMoves;
        private string numberForGuessString;
        private bool isGuessed;
        private char[] helpingNumber;
        private Random randomGenerator;




        // Constructor
        public Engine()
        {

        }

        // Methods
        private void Initialize()
        {
            randomGenerator = new Random();
            numberOfMoves = 0;
            numberOfCheats = 0;
            isGuessed = false;
            helpingNumber = new char[] { 'X', 'X', 'X', 'X' };
        }



        public void Play()
        {
            UserInterface.GameRulesMessage();
            Initialize();
            GenerateNumberForGuess();

            long commandDigit = 0;
            string command;

            while (!isGuessed)
            {
                Console.Write("Enter your guess or command: ");
                command = Console.ReadLine();
                if (long.TryParse(command, out commandDigit))
                {
                    ProcessDigitCommand(command);
                }
                else
                {



                    ProcessTextCommand(command);
                }
            }

            HallOfFame.AddPlayerToScoreboard(numberOfMoves, numberOfCheats);
            HallOfFame.PrintScoreboard();
            CreateNewGame();
        }


        private void GenerateNumberForGuess()
        {
            long numberForGuess = randomGenerator.Next(0, 9999);
            numberForGuessString = numberForGuess.ToString();
            AddZeroes();
        }


        private void AddZeroes()
        {
            int zeroesForAdd = 4 - numberForGuessString.Length;
            StringBuilder sb = new StringBuilder();

            for (int i = 0; i < zeroesForAdd; i++)
            {
                sb.Append("0");
            }
            sb.Append(numberForGuessString);
            numberForGuessString = sb.ToString();
        }


        //This Two Methods should be combined in one more intelligent
        ////////////////////////////////////////////////////////////////////////////////////////////
                                                                                                  //
        private void ProcessDigitCommand(string tryNumberString)                                  //
        {                                                                                         //
            if (tryNumberString.Length == 4)                                                      //
            {                                                                                     //
                numberOfMoves++;                                                                  //
                if (isEqualToNumberForGuess(tryNumberString))                                     //
                {                                                                                 //
                    isGuessed = true;                                                             //
                    UserInterface.PrintCongratulationMessage(numberOfMoves, numberOfCheats);      //
                }                                                                                 //
                else                                                                              //
                {                                                                                 //
                    PrintBullsAndCows(tryNumberString);                                           //
                }                                                                                 //
            }                                                                                     //
            else                                                                                  //
            {                                                                                     //
                Console.WriteLine("You have entered invalid number!");                            //
            }                                                                                     //
        }                                                                                         //
                                                                                                  //
                                                                                                  //
                                                                                                  //
                                                                                                  //
        private void ProcessTextCommand(string command)                                           //
        {                                                                                         //
            switch (command.ToLower())                                                            //
            {                                                                                     //
                case "top":                                                                       //
                    HallOfFame.PrintScoreboard();                                                 //
                    break;                                                                        //
                case "help":                                                                      //
                    RevealDigit();                                                                //
                    numberOfCheats++;                                                             //
                    break;                                                                        //
                case "restart":                                                                   //
                    CreateNewGame();                                                              //
                    return;                                                                       //
                case "exit":                                                                      //
                    Console.WriteLine("Good bye!");                                               //
                    Environment.Exit(1);                                                          //
                    break;                                                                        //
                default:                                                                          //
                    Console.WriteLine("Invalid command!");                                        //
                    break;                                                                        //
            }                                                                                     //
        }                                                                                         //
        ////////////////////////////////////////////////////////////////////////////////////////////
        private void CreateNewGame()
        {
            this.Play();
        }


        private bool isEqualToNumberForGuess(string tryNumber)
        {
            bool isEqualToNumberForGuess =
            (tryNumber == numberForGuessString);
            return isEqualToNumberForGuess;
        }


        private void RevealDigit()
        {
            bool flag = false;
            int c = 0;
            while (!flag &&
                   c != 2 * numberForGuessString.Length)
            {
                int digitForReveal = randomGenerator.Next(0, 4);
                if (helpingNumber[digitForReveal] == 'X')
                {
                    helpingNumber[digitForReveal] =
                    numberForGuessString[digitForReveal];



                    flag = true;
                }
                c++;
            }
            PrintHelpingNumber();
        }

        private void PrintHelpingNumber()
        {
            Console.Write("The number looks like ");
            foreach (char ch in helpingNumber) { Console.Write(ch); }
            Console.Write(".");
            Console.WriteLine();
        }

        private void PrintBullsAndCows(string tryNumberString)
        {
            int bullsCount = 0;
            int cowsCount = 0;
            CountBullsAndCows(
                tryNumberString, ref bullsCount, ref cowsCount);
            Console.WriteLine("Wrong number! Bulls: {0}, Cows: {1}!",
                              bullsCount, cowsCount);
        }

        private  void CountBullsAndCows(
            string tryNumberString, ref int bullsCount, ref int cowsCount)
        {
            bool[] bulls = new bool[4];
            bool[] cows = new bool[10];



            bullsCount = CountBulls(tryNumberString, bullsCount, bulls);
            cowsCount = CountCows(tryNumberString, cowsCount, bulls, cows);
        }

        private  int CountCows(
            string tryNumberString, int cowsCount, bool[] bulls, bool[] cows)
        {
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
        private int CountBulls(
            string tryNumberString, int bullsCount, bool[] bulls)
        {
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
