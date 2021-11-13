using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RockPaperScissors.Backend.Moves
{
    public static class MoveFactory
    {
        public static Move GetMove(MoveType move)
        {
            switch (move)
            {
                case MoveType.SCISSORS:
                    return new Scissors();
                case MoveType.PAPER:
                    return new Paper();
                case MoveType.ROCK:
                    return new Rock();
                default: throw new ArgumentOutOfRangeException();

            }
        }
    }
}
