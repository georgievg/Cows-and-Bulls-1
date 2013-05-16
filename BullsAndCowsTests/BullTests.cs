using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BullsAndCows;

namespace BullsAndCowsTests
{
    [TestClass]
    public class BullTests
    {
        [TestMethod]
        public void TwoIsCorrectBullsCountFor2653()
        {
            Bull bullTest = new Bull("2653", "2352", new bool[4]);
            string actual = bullTest.GetPrintableCount();

            Assert.AreEqual("Bulls: 2 ", actual, "Bull counting logic problem.");
        }

        [TestMethod]
        public void OneIsCorrectBullsCountFor3331()
        {
            Bull bullTest = new Bull("3331", "3462", new bool[4]);
            string actual = bullTest.GetPrintableCount();

            Assert.AreEqual("Bulls: 1 ", actual, "Bull counting logic problem.");
        }

        [TestMethod]
        public void FourIsCorrectBullsCountFor0000()
        {
            Bull bullTest = new Bull("0000", "0000", new bool[4]);
            string actual = bullTest.GetPrintableCount();

            Assert.AreEqual("Bulls: 4 ", actual, "Bull counting logic problem.");
        }

        [TestMethod]
        public void OneIsNotCorrectBullsCountFor2901()
        {
            Bull bullTest = new Bull("2901", "2400", new bool[4]);
            string actual = bullTest.GetPrintableCount();

            Assert.AreNotEqual("Bulls: 1 ", actual, "Bull counting logic problem.");
        }

        [TestMethod]
        public void ThreeIsNotCorrectBullsCountFor9734()
        {
            Bull bullTest = new Bull("9734", "9943", new bool[4]);
            string actual = bullTest.GetPrintableCount();

            Assert.AreNotEqual("Bulls: 3 ", actual, "Bull counting logic problem.");
        }

        [TestMethod]
        [ExpectedException(typeof(NullReferenceException))]
        public void EmptyNumberForGuessIsNotAllowed()
        {
            Bull bullTest = new Bull(null, "3462", new bool[4]);   
        }

        [TestMethod]
        [ExpectedException(typeof(NullReferenceException))]
        public void EmptyTryNumberIsNotAllowed()
        {
            Bull bullTest = new Bull("4390", null, new bool[4]);
        }

        [TestMethod]
        [ExpectedException(typeof(NullReferenceException))]
        public void EmptyBoolArrayForBullsIsNotAllowed()
        {
            Bull bullTest = new Bull("5331", "2178", null);
        }
    }
}
