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
        private string[] allowedCommands;

        // construcotor
        public CommandParser()
        {
            this.allowedCommands = new string[] {
                "top",
                "help",
                "restart",
                "exit",
            };
        }

        public string ParseCommand(string command)
        {
            string formatedCommand = command.Trim();
            // Searching for game command
            for (int commandsIndex = 0; commandsIndex < this.allowedCommands.Length; commandsIndex++)
            {
                if (formatedCommand.Equals(this.allowedCommands[commandsIndex]))
                {
                    return formatedCommand.ToLower();
                }
            }
            // Checking for entered valid guess number
            if (formatedCommand.Length == 4)
            {
                for (int commandChars = 0; commandChars < formatedCommand.Length; commandChars++)
                {
                    if ((formatedCommand[commandChars] < '0' || formatedCommand[commandChars] > '9'))
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
