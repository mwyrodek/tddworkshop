using RockPaperScissors.Backend.Moves;

namespace RockPaperScissors.Backend
{
    public class Scissors : Move
    {
        private List<MoveType> winsWith => new List<MoveType>() { MoveType.PAPER };
        private List<MoveType> losesTo => new List<MoveType>() { MoveType.ROCK };
        public Scissors() {
            this.MoveType = MoveType.SCISSORS;
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