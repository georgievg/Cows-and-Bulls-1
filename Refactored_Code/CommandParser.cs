//-----------------------------------------------------------------------
// <copyright file="CommandParser.cs" company="TelerikAcademy">
//     All rights reserved © Telerik Academy 2012-2013
// </copyright>
//-----------------------------------------------------------------------
namespace BullsAndCows
{
    using System;
    
    /// <summary>
    /// This class provides command parser logic
    /// </summary>
    public class CommandParser
    {
        private string[] AllowedCommands{get;set;}

        /// <summary>
        /// Initializes a new instance of the <see cref="CommandParser" /> class.
        /// </summary>
        public CommandParser()
        {
            this.AllowedCommands = new string[]
            {
                "top",
                "help",
                "restart",
                "exit",
            };
        }

        /// <summary>
        /// Parse entered command from the user to one of the allowed commands. 
        /// </summary>
        /// <param name="command">Command that will be parsed</param>
        /// <returns>Formatted command that is allowed</returns>
        public string ParseCommand(string command)
        {
            string formatedCommand = command.Trim();

            // Searching for game command
            for (int commandsIndex = 0; commandsIndex < this.AllowedCommands.Length; commandsIndex++)
            {
                if (formatedCommand.Equals(this.AllowedCommands[commandsIndex]))
                {
                    return formatedCommand.ToLower();
                }
            }

            // Checking for entered valid guess number
            if (formatedCommand.Length == 4)
            {
                for (int commandChars = 0; commandChars < formatedCommand.Length; commandChars++)
                {
                    if (formatedCommand[commandChars] < '0' || formatedCommand[commandChars] > '9')
                    {
                        return "invalid number";
                    }
                }

                return formatedCommand;
            }

            return "invalid command";
        }
    }
}
