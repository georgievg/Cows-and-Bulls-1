namespace BullsAndCowsTests
{
    using System;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using System.IO;
    using System.Text;

    [TestClass]
    public class UserInterfaceTests
    {
        [TestMethod]
        public void PrintCorrectGameRulesMessage()
        {
            using (StringWriter consoleOutput = new StringWriter())
            {
                Console.SetOut(consoleOutput);
                BullsAndCows.UserInterface.PrintGameRulesMessage();
                string expectedOutput = string.Format(
                 "Welcome to “Bulls and Cows” game." + Environment.NewLine +
                 "Please try to guess my secret 4-digit number." + Environment.NewLine +
                 "Use 'top' to view the top scoreboard." + Environment.NewLine +
                 "'Restart' to start a new game." + Environment.NewLine +
                 "'Help' to cheat." + Environment.NewLine +
                 "'Exit' to quit the game." + Environment.NewLine + Environment.NewLine);
                Assert.AreEqual(expectedOutput, consoleOutput.ToString(), "PrintGameRulesMessage method not working as expected.");
            }
        }

        [TestMethod]
        public void PrintCongratulationMessageWithoutCheats()
        {
            using (StringWriter consoleOutput = new StringWriter())
            {
                Console.SetOut(consoleOutput);
                BullsAndCows.UserInterface.PrintCongratulationMessage(5, 0);
                string expected = string.Format(
                 "Congratulations! You guessed the secret number in 5 attempts ." + Environment.NewLine);
                Assert.AreEqual(expected, consoleOutput.ToString(), "PrintScoreBoard method not working as expected.");
            }
        }

        [TestMethod]
        public void PrintCongratulationMessageWithCheats()
        {
            using (StringWriter consoleOutput = new StringWriter())
            {
                Console.SetOut(consoleOutput);
                BullsAndCows.UserInterface.PrintCongratulationMessage(10, 2);
                string expected = string.Format(
                 "Congratulations! You guessed the secret number in 10 attempts " +"and 2 cheats."+ Environment.NewLine);
                Assert.AreEqual(expected, consoleOutput.ToString(), "PrintScoreBoard method not working as expected.");
            }
        }

        [TestMethod]
        public void PrintCorrectCheaterMessage()
        {
            using (StringWriter consoleOutput = new StringWriter())
            {
                Console.SetOut(consoleOutput);
                BullsAndCows.UserInterface.PrintCheaterMessage();
                string expected = string.Format(
                 "You are not allowed to enter the top scoreboard." + Environment.NewLine);
                Assert.AreEqual(expected, consoleOutput.ToString(), "PrintScoreBoard method not working as expected.");
            }
        }
    }
}
