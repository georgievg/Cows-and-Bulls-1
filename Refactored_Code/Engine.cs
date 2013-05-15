//-----------------------------------------------------------------------
// <copyright file="Engine.cs" company="TelerikAcademy">
//     All rights reserved © Telerik Academy 2012-2013
// </copyright>
//-----------------------------------------------------------------------

namespace BullsAndCows
{
    using System;
    using System.Linq;

    /// <summary>
    /// Determine the logic and methods controlling the game flow.
    /// </summary>
    public class Engine
    {
        private int numberOfCheats;
        private int numberOfMoves;
        private SecretNumber numberToGuess;
        private bool isGuessed;
        
        /// <summary>
        /// Entry point of the Engine. All High - level game logic methods are invoked in this methods to begin the game.
        /// </summary>
        public void Play()
        {
            this.Initialize();
            string command = null;
            CommandParser consoleReader = new CommandParser();
            UserInterface.PrintGameRulesMessage();

            while (!this.isGuessed)
            {
                Console.Write("Enter your guess or command: ");
                command = Console.ReadLine();
                command = consoleReader.ParseCommand(command);
                this.CommandExecution(command);
            }

            HallOfFame.AddPlayerToScoreboard(this.numberOfMoves, this.numberOfCheats);

            string scoreBoard = HallOfFame.GenerateScoreBoard();
            Console.WriteLine(scoreBoard);

            this.CreateNewGame();
        }

        private void Initialize()
        {
            this.numberToGuess = new SecretNumber();
            this.numberOfMoves = 0;
            this.numberOfCheats = 0;
            this.isGuessed = false;
        }

        private void CreateNewGame()
        {
            this.Play();
        }

        private void ProcessNextMove(string numberToTry)
        {
            this.numberOfMoves++;
            if (this.numberToGuess.IsEqualToNumberForTry(numberToTry))
            {
                this.isGuessed = true;
                UserInterface.PrintCongratulationMessage(this.numberOfMoves, this.numberOfCheats);
            }
            else
            {
                bool[] isBull = new bool[4];
                Bull bull = new Bull(this.numberToGuess.Value, numberToTry, isBull);
                Cow cow = new Cow(this.numberToGuess.Value, numberToTry,isBull);
                

                Console.Write("Wrong number! ");
                bull.DrawToConsole();
                cow.DrawToConsole();
            }
        }

        private void CommandExecution(string command)
        {
            switch (command.ToLower())
            {
                case "top":
                    string scoreBoard = HallOfFame.GenerateScoreBoard();
                    Console.WriteLine(scoreBoard);
                    break;
                case "help":
                    this.numberToGuess.PrintHelpingNumber();
                    this.numberOfCheats++;
                    break;
                case "restart":
                    this.CreateNewGame();
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
    }
}
