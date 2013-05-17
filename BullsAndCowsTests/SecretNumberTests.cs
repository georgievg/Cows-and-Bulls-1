using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BullsAndCows;

namespace BullsAndCowsTests
{
    [TestClass]
    public class SecretNumberTests
    {
        [TestMethod]
        public void RandomNumberToGuessGeneratorDifferentNumbers()
        {
            BullsAndCows.SecretNumber randomNumber1 = new BullsAndCows.SecretNumber();
            System.Threading.Thread.Sleep(10);
            BullsAndCows.SecretNumber randomNumber2 = new BullsAndCows.SecretNumber();
            System.Threading.Thread.Sleep(10);
            BullsAndCows.SecretNumber randomNumber3 = new BullsAndCows.SecretNumber();
            Assert.IsFalse((randomNumber1.Value == randomNumber2.Value) && (randomNumber2.Value == randomNumber3.Value));
        }

        [TestMethod]
        public void NumberToGuessIsGenerated()
        {
            SecretNumber secretNumberTest = new SecretNumber();

            Assert.AreNotEqual(null,secretNumberTest.Value);
        }

        [TestMethod]
        public void RevealedFourTimesSecretNumberIsCorrect()
        {
            SecretNumber secretNumberTest = new SecretNumber();
            secretNumberTest.GetHelpingNumber();
            secretNumberTest.GetHelpingNumber();
            secretNumberTest.GetHelpingNumber();
            string actual = secretNumberTest.GetHelpingNumber();

            Assert.AreEqual("The number looks like " + secretNumberTest.Value + "." + Environment.NewLine,actual);

        }
    }
}
