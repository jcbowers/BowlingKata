using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BowlingKata;

namespace BowlingKataTest
{
    [TestClass]
    public class BowlingKataUnitTest
    {
        Game game = new Game();

        [TestCleanup]
        public void Cleanup()
        {
            game.Restart();
        }

        #region Original Unit Tests

            [TestMethod]
            public void AllGutterBalls()
            {
                game.RollMany(20, 0);
                Assert.AreEqual(0, game.Score());
            }

            [TestMethod]
            public void PerfectGame()
            {
                game.RollMany(21, 10);
                Assert.AreEqual(300, game.Score());
            }

            [TestMethod]
            public void AllSpares()
            {
                game.RollMany(21, 5);
                Assert.AreEqual(150, game.Score());
            }

            [TestMethod]
            public void AllOnes()
            {
                game.RollMany(20, 1);
                Assert.AreEqual(20, game.Score());
            }

        #endregion

        #region Extended Domain Tests
            [TestMethod]
            public void Turkey()
            {
                game.RollMany(3, 10);
                Assert.AreEqual(40, game.Score());

            }

            [TestMethod]
            public void OneStrike()
            {
                game.Roll(10).Roll(5).Roll(5);
                Assert.AreEqual(25, game.Score());
            }

            [TestMethod]
            [ExpectedException(typeof(InvalidOperationException))]
            public void InvalidBonus()
            {
                game.RollMany(21, 1);
            }

            [TestMethod]
            [ExpectedException(typeof(ArgumentException))]
            public void TooManyPins()
            {
                game.Roll(9).Roll(9);
            }

            [TestMethod]
            [ExpectedException(typeof(InvalidOperationException))]
            public void TooManyRollsInFinalFrame()
            {
                game.RollMany(18, 10).RollMany(3,1);
            }

            [TestMethod]
            [ExpectedException(typeof(InvalidOperationException))]
            public void TooManyRolls()
            {
                game.RollMany(22, 1);
            }

            [TestMethod]
            [ExpectedException(typeof(InvalidOperationException))]
            public void TooManySpares()
            {
                game.RollMany(22, 5);
            }

            [TestMethod]
            [ExpectedException(typeof(InvalidOperationException))]
            public void TooManyStrikes()
            {
                game.RollMany(22, 10);
            }
        #endregion
    }

}
