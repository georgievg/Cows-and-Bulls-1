using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BullsAndCows;

namespace BullsAndCowsTests
{
    [TestClass]
    public class CommandParserTests
    {
        [TestMethod]
        public void TopIsValidCommand()
        {
            CommandParser commandParser = new CommandParser();
            var actual = commandParser.ParseCommand("top");

            Assert.AreEqual("top",actual);
        }

        [TestMethod]
        public void RestartIsValidCommand()
        {
            CommandParser commandParser = new CommandParser();
            var actual = commandParser.ParseCommand("restart");

            Assert.AreEqual("restart", actual);
        }

        [TestMethod]
        public void HelpIsValidCommand()
        {
            CommandParser commandParser = new CommandParser();
            var actual = commandParser.ParseCommand("help");

            Assert.AreEqual("help", actual);
        }

        [TestMethod]
        public void ExitIsValidCommand()
        {
            CommandParser commandParser = new CommandParser();
            var actual = commandParser.ParseCommand("exit");

            Assert.AreEqual("exit", actual);
        }

        [TestMethod]
        public void EmptyStringIsNotValidCommand()
        {
            CommandParser commandParser = new CommandParser();
            var actual = commandParser.ParseCommand("");

            Assert.AreEqual("invalid command", actual);
        }

        [TestMethod]
        public void LongerThanFourDigitNumberIsNotValid()
        {
            CommandParser commandParser = new CommandParser();
            var actual = commandParser.ParseCommand("19872");

            Assert.AreEqual("invalid command", actual);
        }

        [TestMethod]
        public void FourDigitNumberIsValidCommand()
        {
            CommandParser commandParser = new CommandParser();
            var actual = commandParser.ParseCommand("1289");

            Assert.AreEqual("1289", actual);
        }

        [TestMethod]
        public void CombinationOfDigitsAndLettersIsNotValidNumber()
        {
            CommandParser commandParser = new CommandParser();
            var actual = commandParser.ParseCommand("1a90");

            Assert.AreEqual("invalid number", actual);
        }
    }
}
