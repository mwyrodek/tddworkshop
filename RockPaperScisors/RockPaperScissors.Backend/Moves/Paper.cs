using RockPaperScissors.Backend.Moves;

namespace RockPaperScissors.Backend
{
    public class Paper : AbstarctMove
    {
        public Paper() : base(MoveType.PAPER)
        {
            winsWith = new List<MoveType>() { MoveType.ROCK, MoveType.SUN };
            losesTo = new List<MoveType>() { MoveType.SCISSORS, MoveType.CLIPY };
        }
    }
}