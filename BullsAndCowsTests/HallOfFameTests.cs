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
        [TestMethod]
        public void FiveIsMaximumPlayersCount()
        {
            HallOfFame.AddPlayerToScoreboard(5, 0, "pesho");
            HallOfFame.AddPlayerToScoreboard(3, 0, "Sashko");
            HallOfFame.AddPlayerToScoreboard(4, 0, "Petrokal");
            HallOfFame.AddPlayerToScoreboard(7, 0, "Strahil");
            HallOfFame.AddPlayerToScoreboard(1, 0, "Ceco");
            HallOfFame.AddPlayerToScoreboard(12, 0, "Yonko");
            int actual = HallOfFame.PlayersCount;

            Assert.AreEqual(actual, 5);
        }

        [TestMethod]
        public void ScoreHolderIsSorted()
        {
            HallOfFame.EraseScoreBoard();
            HallOfFame.AddPlayerToScoreboard(5, 0, "atanas");
            HallOfFame.AddPlayerToScoreboard(3, 0, "Sashko");
            HallOfFame.AddPlayerToScoreboard(4,0,"kiril");

            string scoreBoard = HallOfFame.GenerateScoreBoard();
            int indexOfAtanas = scoreBoard.IndexOf("atanas");
            int indexOfSashko = scoreBoard.IndexOf("Sashko");
            int indexOfKiril = scoreBoard.IndexOf("kiril");

            bool actual = (indexOfSashko < indexOfKiril) && (indexOfKiril < indexOfAtanas);
            Assert.IsTrue(actual);
        }

    }
}
