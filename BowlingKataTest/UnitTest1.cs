using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BowlingKata;

namespace BowlingKataTest
{
    [TestClass]
    public class BowlingKataUnitTest
    {
        private Game _game;

        [TestInitialize]
        public void Cleanup()
        {
            _game = new Game();
        }

        #region Original Unit Tests

            [TestMethod]
            public void AllGutterBalls()
            {
                _game.RollMany(20, 0);
                Assert.AreEqual(0, _game.Score());
            }

            [TestMethod]
            public void PerfectGame()
            {
                _game.RollMany(21, 10);
                Assert.AreEqual(300, _game.Score());
            }

            [TestMethod]
            public void AllSpares()
            {
                _game.RollMany(21, 5);
                Assert.AreEqual(150, _game.Score());
            }

            [TestMethod]
            public void AllOnes()
            {
                _game.RollMany(20, 1);
                Assert.AreEqual(20, _game.Score());
            }

        #endregion

        #region Extended Domain Tests
            [TestMethod]
            public void Turkey()
            {
                _game.RollMany(3, 10);
                Assert.AreEqual(40, _game.Score());

            }

            [TestMethod]
            public void OneStrike()
            {
                _game.Roll(10).Roll(5).Roll(5);
                Assert.AreEqual(25, _game.Score());
            }

            [TestMethod]
            [ExpectedException(typeof(InvalidOperationException))]
            public void InvalidBonus()
            {
                _game.RollMany(21, 1);
            }

            [TestMethod]
            [ExpectedException(typeof(ArgumentException))]
            public void TooManyPins()
            {
                _game.Roll(9).Roll(9);
            }

            [TestMethod]
            [ExpectedException(typeof(InvalidOperationException))]
            public void TooManyRollsInFinalFrame()
            {
                _game.RollMany(18, 10).RollMany(3,1);
            }

            [TestMethod]
            [ExpectedException(typeof(InvalidOperationException))]
            public void TooManyRolls()
            {
                _game.RollMany(22, 1);
            }

            [TestMethod]
            [ExpectedException(typeof(InvalidOperationException))]
            public void TooManySpares()
            {
                _game.RollMany(22, 5);
            }

            [TestMethod]
            [ExpectedException(typeof(InvalidOperationException))]
            public void TooManyStrikes()
            {
                _game.RollMany(22, 10);
            }
        #endregion
    } 

}
