using System;
using System.Collections.Generic;
using System.Linq;

namespace BowlingKata
{
    public class Frame
    {
        Frame _nextFrame;

        protected List<UInt16> _rolls;

        public IReadOnlyList<ushort> Rolls { get; protected set; }

        internal Frame()
        {
            _rolls = new List<UInt16>(2);
            Rolls = _rolls;
        }

        internal Frame(Frame nextFrame) : this()
        {
            _nextFrame = nextFrame;
        }

        public virtual bool IsComplete 
        { 
            get { return _rolls.Count == 2; }
        }

        public UInt16 Score
        {
            get { return (UInt16)(_rolls.Sum(i => i) + NextFrameBonus); }
        }

        internal void AddRoll(UInt16 pins)
        {
            if (TooManyPinsForFrame(pins))
                throw new ArgumentException("Too many pins");

            _rolls.Add(pins);
        }

        protected virtual int NextFrameBonus
        {
            get { return IsStrikeOrSpare ? _nextFrame.Rolls.FirstOrDefault() : 0; }
        }

        protected bool IsStrikeOrSpare
        {
            get{ return Rolls.Take(2).Sum(i => i) >= 10; }
        }

        protected virtual bool TooManyPinsForFrame(UInt16 pins)
        {
            return (!IsStrikeOrSpare && _rolls.FirstOrDefault() + pins > 10) || (IsStrikeOrSpare && _rolls[0] + pins > 20);
        }
    }
}
