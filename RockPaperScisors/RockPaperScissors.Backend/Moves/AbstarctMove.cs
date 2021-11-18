using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RockPaperScissors.Backend.Moves
{
    public abstract class AbstarctMove : Move
    {
        protected List<MoveType> winsWith;
        protected List<MoveType> losesTo;
        public  MoveType MoveType { get; }
        public AbstarctMove(MoveType type)
        {
            MoveType = type;
        }


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
