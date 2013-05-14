using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BullsAndCowsTests
{
    [TestClass]
    public class PlayerInfoTests
    {
        [TestMethod]
        public void PlayerInfoNicknameTest()
        {
            BullsAndCows.PlayerInfo demoPlayer = new BullsAndCows.PlayerInfo("Master Nakov", 1);
            string demoPlayerNickname = demoPlayer.NickName;
            Assert.AreEqual("Master Nakov", demoPlayerNickname);
        }

        [TestMethod]
        public void PlayerInfoGuessesTest()
        {
            BullsAndCows.PlayerInfo demoPlayer = new BullsAndCows.PlayerInfo("Niki", 13);
            int demoPlayerGuesses = demoPlayer.Guesses;
            Assert.AreEqual(13, demoPlayerGuesses);
        }

        [TestMethod]
        public void PlayerInfoToStringTest()
        {
            BullsAndCows.PlayerInfo demoPlayer = new BullsAndCows.PlayerInfo("Master Nakov", 8);
            string expextedToString = string.Format("{0,3}    | {1}", 8, "Master Nakov");
            Assert.AreEqual(expextedToString, demoPlayer.ToString());
        }

        [TestMethod]
        public void PlayerInfoCompareToWithEqualPlayers()
        {
            BullsAndCows.PlayerInfo firstDemoPlayer = new BullsAndCows.PlayerInfo("Ninja Player", 4);
            BullsAndCows.PlayerInfo secondDemoPlayer = new BullsAndCows.PlayerInfo("Ninja Player", 4);
            int compareResult = firstDemoPlayer.CompareTo(secondDemoPlayer);
            Assert.AreEqual(0, compareResult);
        }

        [TestMethod]
        public void PlayerInfoCompareToWithFirstPlayerBetter()
        {
            BullsAndCows.PlayerInfo firstDemoPlayer = new BullsAndCows.PlayerInfo("Master Nakov", 3);
            BullsAndCows.PlayerInfo secondDemoPlayer = new BullsAndCows.PlayerInfo("Niki", 6);
            int compareResult = firstDemoPlayer.CompareTo(secondDemoPlayer);
            Assert.IsTrue(compareResult < 0);
        }

        [TestMethod]
        public void PlayerInfoCompareToWithSecondPlayerBetter()
        {
            BullsAndCows.PlayerInfo firstDemoPlayer = new BullsAndCows.PlayerInfo("Master Nakov", 7);
            BullsAndCows.PlayerInfo secondDemoPlayer = new BullsAndCows.PlayerInfo("Niki", 3);
            int compareResult = firstDemoPlayer.CompareTo(secondDemoPlayer);
            Assert.IsTrue(compareResult > 0);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void PlayerInfoNullNickname()
        {
            BullsAndCows.PlayerInfo firstDemoPlayer = new BullsAndCows.PlayerInfo("", 7);
        }
    }
}
