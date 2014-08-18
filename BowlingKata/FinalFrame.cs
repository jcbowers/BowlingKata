using System;
using System.Collections.Generic;

namespace BowlingKata
{
    public class FinalFrame : Frame
    {
        internal FinalFrame()
        {
            _rolls = new List<UInt16>(3);
            Rolls = _rolls;
        }

        public override bool IsComplete
        {
            get
            {
                return (IsStrikeOrSpare && _rolls.Count == 3) || (!IsStrikeOrSpare && _rolls.Count == 2);
            }
        }

        protected override int NextFrameBonus
        {
            get { return 0; }
        }
    }
}
