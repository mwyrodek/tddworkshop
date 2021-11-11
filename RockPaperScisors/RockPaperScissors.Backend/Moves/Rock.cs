using RockPaperScissors.Backend.Moves;

namespace RockPaperScissors.Backend
{
    public class Rock: Move
    {
        private List<MoveTypes> winsWith => new List<MoveTypes>() { MoveTypes.SCISSORS };
        private List<MoveTypes> losesTo => new List<MoveTypes>() { MoveTypes.PAPER };
        public Rock() {
            this.MoveType = MoveTypes.ROCK;
        }

        public override MoveTypes MoveType { get; }

        public override MatchResult IsWinning(MoveTypes move)
        {
            if (move == this.MoveType) 
                return MatchResult.TIE;
            if (winsWith.Contains(move))
            {
                return MatchResult.WIN;
            }
            if (losesTo.Contains(move))
            {
                return MatchResult.LOSE;
            }

                throw new ArgumentOutOfRangeException($"Unknow value of {move}");
        }
    }
}