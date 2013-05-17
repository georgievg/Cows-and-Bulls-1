using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BullsAndCows;

namespace BullsAndCowsTests
{
    [TestClass]
    public class CowTests
    {
        [TestMethod]
        public void OneIsCorrectCowsCountFor1786()
        {
            bool[] isBull = new bool[4];
            Bull bullTest = new Bull("1786", "6187", isBull);
            Cow cowTest = new Cow("1786", "6187", isBull);
            string actual = cowTest.GetPrintableCount();

            Assert.AreEqual("Cows: 4", actual, "Cow counting logic problem.");
        }

        [TestMethod]
        public void ThreeIsCorrectCowsCountFor2996()
        {
            bool[] isBull = new bool[4];
            Bull bullTest = new Bull("2296", "2296", isBull);
            Cow cowTest = new Cow("2296", "2292", isBull);
            string actual = cowTest.GetPrintableCount();

            Assert.AreEqual("Cows: 3", actual, "Cow counting logic problem.");
        }

        [TestMethod]
        public void SevenIsNotCorrectCowsCountFor9067()
        {
            bool[] isBull = new bool[4];
            Bull bullTest = new Bull("9067", "0185", isBull);
            Cow cowTest = new Cow("9067", "0185", isBull);
            string actual = cowTest.GetPrintableCount();

            Assert.AreNotEqual("Cows: 7", actual, "Cow counting logic problem.");
        }

        [TestMethod]
        public void ZeroIsNotCorrectCowsCountFor1923()
        {
            bool[] isBull = new bool[4];
            Bull bullTest = new Bull("1923", "1093", isBull);
            Cow cowTest = new Cow("1923", "1093", isBull);
            string actual = cowTest.GetPrintableCount();

            Assert.AreNotEqual("Cows: 0", actual, "Cow counting logic problem.");
        }

        [TestMethod]
        [ExpectedException(typeof(NullReferenceException))]
        public void EmptyNumberForGuessIsNotAllowed()
        {
            Cow cowllTest = new Cow(null, "3462", new bool[4]);
        }

        [TestMethod]
        [ExpectedException(typeof(NullReferenceException))]
        public void EmptyTryNumberIsNotAllowed()
        {
            Cow cowllTest = new Cow("4390", null, new bool[4]);
        }

        [TestMethod]
        [ExpectedException(typeof(NullReferenceException))]
        public void EmptyBoolArrayForBullsIsNotAllowed()
        {
            Cow cowllTest = new Cow("5331", "2178", null);
        }
    }
}
