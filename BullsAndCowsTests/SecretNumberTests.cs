using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

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
    }
}
