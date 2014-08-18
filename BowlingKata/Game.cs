using System;
using System.Collections.Generic;
using System.Linq;

namespace BowlingKata
{
    public class Game
    {
        public IReadOnlyList<Frame> Frames { get; private set; }
        LinkedList<Frame> _frames = new LinkedList<Frame>();

        public Game()
        {
            _frames.AddFirst(new FinalFrame());

            for (int i = 0; i < 9; i++)
                _frames.AddFirst(new Frame(_frames.First()));

            Frames = _frames.ToList();
        }

        public Game Roll(UInt16 pins)
        {
            if (pins > 10)
                throw new ArgumentException("You cannot knock down more than 10 pins per roll");

            var nextFrame = _frames.First(f => !f.IsComplete);
            nextFrame.AddRoll(pins);

            return this;
        }

        public int Score()
        {
            return _frames.Sum(f=>f.Score);
        }
    }
}
