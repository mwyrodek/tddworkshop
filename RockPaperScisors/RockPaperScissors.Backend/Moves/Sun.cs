using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RockPaperScissors.Backend.Moves
{
    public class Sun : AbstarctMove

    {
        public Sun() : base(MoveType.SUN)
        {
            winsWith = new List<MoveType>() { MoveType.ROCK, MoveType.CLIPY };
            losesTo = new List<MoveType>() { MoveType.PAPER, MoveType.SCISSORS };
        }

    }
}
