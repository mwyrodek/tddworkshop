using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RockPaperScissors.Backend.Moves
{
    public abstract class Move
    {
        public abstract MoveTypes MoveType { get; }

        public abstract MatchResult IsWinning(MoveTypes move);
    }
}
