using RockPaperScissors.Backend.Moves;

namespace RockPaperScissors.Backend.Moves
{
    public class Clipy : AbstarctMove
    {
        public Clipy() : base(MoveType.CLIPY)
        {
            winsWith = new List<MoveType>() { MoveType.SCISSORS, MoveType.PAPER };
            losesTo = new List<MoveType>() { MoveType.ROCK, MoveType.SUN };
        }
    }
}
