using System;
using System.Collections.Generic;
using System.Linq;

namespace BowlingKata
{
    public class Frame
    {
        private readonly Frame _nextFrame;

        protected List<ushort> _rolls;

        public IReadOnlyList<ushort> Rolls { get; protected set; }

        internal Frame()
        {
            _rolls = new List<ushort>(2);
            Rolls = _rolls;
        }

        internal Frame(Frame nextFrame) : this()
        {
            _nextFrame = nextFrame;
        }

        public virtual bool IsComplete => _rolls.Count == 2;

        public ushort Score
        {
            get { return (ushort)(_rolls.Sum(i => i) + NextFrameBonus); }
        }

        internal void AddRoll(ushort pins)
        {
            if (TooManyPinsForFrame(pins))
                throw new ArgumentException("Too many pins");

            _rolls.Add(pins);
        }

        protected virtual int NextFrameBonus => IsStrikeOrSpare ? _nextFrame.Rolls.FirstOrDefault() : 0;

        protected bool IsStrikeOrSpare
        {
            get{ return Rolls.Take(2).Sum(i => i) >= 10; }
        }

        protected virtual bool TooManyPinsForFrame(ushort pins)
        {
            return (!IsStrikeOrSpare && _rolls.FirstOrDefault() + pins > 10) || (IsStrikeOrSpare && _rolls[0] + pins > 20);
        }
    }
}
