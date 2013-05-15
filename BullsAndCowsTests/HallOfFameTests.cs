using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BullsAndCows;

namespace BullsAndCowsTests
{
    [TestClass]
    public class HallOfFameTests
    {
        [TestMethod]
        public void EmptyPlayerScoresTest()
        {
            int players = HallOfFame.PlayersCount;
            var expected = 0;
            var actual = players;
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void OnePlayerScoresTest()
        {
            HallOfFame.AddPlayerToScoreboard(5, 0, "pesho");
            int players = HallOfFame.PlayersCount;
            var expected = 1;
            var actual = players;
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void GenerateEmptyScoreboard()
        {
            HallOfFame.EraseScoreBoard();
            var expected = "\r\nScoreboard is empty!\r\n";
            var actual = HallOfFame.GenerateScoreBoard();
            Assert.AreEqual(expected, actual);
        }

    }
}
