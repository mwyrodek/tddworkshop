using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RockPaperScissors.Backend.Moves
{
    public static class MoveFactory
    {
        public static IMove GetMove(MoveType move)
        {
            switch (move)
            {
                case MoveType.SCISSORS:
                    return new Scissors();
                case MoveType.PAPER:
                    return new Paper();
                case MoveType.ROCK:
                    return new Rock();
                case MoveType.SUN:
                    return new Sun();
                case MoveType.CLIPY:
                    return new Clipy();
                default: throw new ArgumentOutOfRangeException($"Enum took unknown value {move}");

            }
        }
    }
}
