using System;

namespace BowlingKata
{
    internal static class GameExtensions
    {
        public static Game RollMany(this Game game, int rolls, ushort pins)
        {
            for (var i = 0; i < rolls; i++)
            {
                game.Roll(pins);
            }

            return game;
        }
    }
}
