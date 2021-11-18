using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RockPaperScissors.Backend.Moves
{
    public class Sun : Move
    {
        private List<MoveType> winsWith => new List<MoveType>() { MoveType.SCISSORS, MoveType.CLIPY };
        private List<MoveType> losesTo => new List<MoveType>() { MoveType.PAPER, MoveType.ROCK };

        public MoveType MoveType => MoveType.SUN;

        public TurnResult IsWinning(MoveType move)
        {
            if (move == this.MoveType)
                return TurnResult.TIE;
            if (winsWith.Contains(move))
            {
                return TurnResult.WIN;
            }
            if (losesTo.Contains(move))
            {
                return TurnResult.LOSE;
            }

            throw new ArgumentOutOfRangeException($"Unknow value of {move}");
        }
    }
}
