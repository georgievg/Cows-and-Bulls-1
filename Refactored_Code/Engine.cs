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
            CommandParser consoleReader = new CommandParser();
            UserInterface.PrintGameRulesMessage();
            Initialize();
            GenerateNumberForGuess();

            //long commandDigit = 0;// no need of it

            string command;

            while (!isGuessed)
            {
                Console.Write("Enter your guess or command: ");
                command = Console.ReadLine();
                command = consoleReader.ParseCommand(command);
                    CommandExecution(command);
                
            }

            HallOfFame.AddPlayerToScoreboard(numberOfMoves, numberOfCheats);
            HallOfFame.PrintScoreboard();
            CreateNewGame();
        }


        private void GenerateNumberForGuess()
        {
            long numberForGuess = randomGenerator.Next(0, 9999);
            numberForGuessString = numberForGuess.ToString();
            //AddZeroes();// no need of it
        }

        // no need of this
        /*private void AddZeroes()
        {
            int zeroesForAdd = 4 - numberForGuessString.Length;
            StringBuilder sb = new StringBuilder();

            for (int i = 0; i < zeroesForAdd; i++)
            {
                sb.Append("0");
            }
            sb.Append(numberForGuessString);
            numberForGuessString = sb.ToString();
        }*/


        private void ProcessNextMove(string guessNumber)
        {
            this.numberOfMoves++;
            if (isEqualToNumberForGuess(guessNumber))
            {
                isGuessed = true;
                UserInterface.PrintCongratulationMessage(numberOfMoves, numberOfCheats);
            }
            else
            {
                PrintBullsAndCows(guessNumber);
            }                                                                           
        }
                                                                                                                                                                                                                                         
        private void CommandExecution(string command)                                          
        {                                                                                        
            switch (command.ToLower())                                                           
            {                                                                                    
                case "top":                                                                      
                    HallOfFame.PrintScoreboard();                                                
                    break;                                                                       
                case "help":                                                                     
                    RevealDigit();                                                                                                                             
                    break;                                                                       
                case "restart":                                                                  
                    CreateNewGame();                                                             
                    return;                                                                      
                case "exit":                                                                     
                    Console.WriteLine("Good bye!");                                              
                    Environment.Exit(1);                                                         
                    break;
                case "invalid command":
                    Console.WriteLine("Invalid command!");
                    break;
                case "invalid number":
                    Console.WriteLine("You have entered invalid number!");  
                    break;
                default:
                    this.ProcessNextMove(command);
                    break;                                                                         
                                                                                            
            }                                                                                    
        }                                                                                        
       
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
            numberOfCheats++;
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
            Cow cow = new Cow(numberForGuessString);
            Bull bull = new Bull(numberForGuessString);
            bool[] bulls = new bool[4];
            bool[] cows = new bool[10];



            int bullsCount = bull.CountBulls(tryNumberString, bulls);
            int cowsCount = cow.CountCows(tryNumberString, bulls, cows);
            /*CountBullsAndCows(
                tryNumberString, ref bullsCount, ref cowsCount);*/ // no need of this
            Console.WriteLine("Wrong number! Bulls: {0}, Cows: {1}!",
                              bullsCount, cowsCount);
        }

        // no need of this
        /*private  void CountBullsAndCows(
            string tryNumberString, ref int bullsCount, ref int cowsCount)
        {
            bool[] bulls = new bool[4];
            bool[] cows = new bool[10];



            bullsCount = CountBulls(tryNumberString, bullsCount, bulls);
            cowsCount = CountCows(tryNumberString, cowsCount, bulls, cows);
        }*/
  

    }
}
