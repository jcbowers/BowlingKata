using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BowlingKata;

namespace BowlingKataTest
{
    [TestClass]
    public class BowlingKataUnitTest
    {
        #region Original Unit Tests

            [TestMethod]
            public void AllGutterBalls()
            {
                var game = new Game();

                game.RollMany(20, 0);

                Assert.AreEqual(0, game.Score());

            }

            [TestMethod]
            public void PerfectGame()
            {
                var game = new Game();

                game.RollMany(21, 10);

                Assert.AreEqual(300, game.Score());
            }

            [TestMethod]
            public void AllSpares()
            {
                var game = new Game();

                game.RollMany(21, 5);

                Assert.AreEqual(150, game.Score());
            }

            [TestMethod]
            public void AllOnes()
            {
                var game = new Game();

                game.RollMany(20, 1);

                Assert.AreEqual(20, game.Score());
            }

        #endregion

        #region Extended Domain Tests
            [TestMethod]
            public void Turkey()
            {
                var game = new Game();

                game.RollMany(3, 10);

                Assert.AreEqual(40, game.Score());

            }

            [TestMethod]
            public void OneStrike()
            {
                var game = new Game();

                game.Roll(10).Roll(5).Roll(5);

                Assert.AreEqual(25, game.Score());
            }

            [TestMethod]
            [ExpectedException(typeof(InvalidOperationException))]
            public void InvalidBonus()
            {
                var game = new Game();
                game.RollMany(21, 1);
            }

            [TestMethod]
            [ExpectedException(typeof(ArgumentException))]
            public void TooManyPins()
            {
                var game = new Game();
                game.Roll(9).Roll(9);
            }

            [TestMethod]
            [ExpectedException(typeof(InvalidOperationException))]
            public void TooManyRollsInFinalFrame()
            {
                var game = new Game();
                game.RollMany(18, 10);
                game.RollMany(3,1);
            }

            [TestMethod]
            [ExpectedException(typeof(InvalidOperationException))]
            public void TooManyRolls()
            {
                var game = new Game();

                game.RollMany(22, 1);
            }

            [TestMethod]
            [ExpectedException(typeof(InvalidOperationException))]
            public void TooManySpares()
            {
                var game = new Game();

                game.RollMany(22, 5);
            }

            [TestMethod]
            [ExpectedException(typeof(InvalidOperationException))]
            public void TooManyStrikes()
            {
                var game = new Game();

                game.RollMany(22, 10);
            }
        #endregion
    }

}
