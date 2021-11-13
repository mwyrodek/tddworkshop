using RockPaperScissors.Backend.Moves;

namespace RockPaperScissors.Backend
{
    public class Rock: Move
    {
        private List<MoveType> winsWith => new List<MoveType>() { MoveType.SCISSORS };
        private List<MoveType> losesTo => new List<MoveType>() { MoveType.PAPER };
        public Rock() {
            this.MoveType = MoveType.ROCK;
        }

        public MoveType MoveType { get; }

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