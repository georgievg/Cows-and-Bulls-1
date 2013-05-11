using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BullsAndCows
{
    /// <summary>
    /// Determine the logic and methods controlling the game flow.
    /// </summary>
    public class Engine
    {
        /// <summary>
        /// Number representing the count of moves that are cheats.
        /// </summary>
        private int numberOfCheats;

        /// <summary>
        /// Number representing the count of moves that player has done(not including cheat moves).
        /// </summary>
        private int numberOfMoves;

        /// <summary>
        /// The secret number of the game. Variable representing four random digits in the range of 0000 - 9999.
        /// </summary>
        private SecretNumber numberToGuess;

        /// <summary>
        /// Keeps true or false value depending from the game current state or more specific is the secret number is already guessed.
        /// </summary>
        private bool isGuessed;

        /// <summary>
        /// Initializes a new instance of the <see cref="Engine"/> class.
        /// </summary>
        public Engine()
        {
        }

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

        /// <summary>
        /// Initialize <see cref="Engine"/> class fields to their default values needed for the normal execution of the game.
        /// </summary>
        private void Initialize()
        {
            this.numberToGuess = new SecretNumber();
            this.numberOfMoves = 0;
            this.numberOfCheats = 0;
            this.isGuessed = false;
        }

        /// <summary>
        /// Creates new game for the same instance of the Engine.
        /// </summary>
        private void CreateNewGame()
        {
            this.Play();
        }

        /// <summary>
        /// Decides did the guess is the secret number otherwise notify the user for number of 'cows' and 'bulls'.
        /// </summary>
        /// <param name="numberToTry">Number representing try of the user to guess the secret number.</param>
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
                Cow cow = new Cow(this.numberToGuess.Value, numberToTry);
                Bull bull = new Bull(this.numberToGuess.Value, numberToTry);

                Console.Write("Wrong number! ");
                bull.DrawToConsole();
                cow.DrawToConsole();
            }
        }

        /// <summary>
        /// Execute game command or notify the user for invalid one.
        /// </summary>
        /// <param name="command">Name of the command to be executed.</param>
        private void CommandExecution(string command)
        {
            switch (command.ToLower())
            {
                case "top":
                    string scoreBoard = HallOfFame.GenerateScoreBoard();
                    Console.WriteLine(scoreBoard);
                    break;
                case "help":
                    this.numberToGuess.RevealDigit();
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
