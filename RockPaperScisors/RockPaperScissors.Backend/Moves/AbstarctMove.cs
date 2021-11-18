using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RockPaperScissors.Backend.Moves
{
    public abstract class AbstarctMove : IMove
    {
        protected List<MoveType> winsWith;
        protected List<MoveType> losesTo;
        public  MoveType MoveType { get; }
        protected AbstarctMove(MoveType type)
        {
            MoveType = type;
            this.winsWith = new List<MoveType>();
            this.losesTo = new List<MoveType>();

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
