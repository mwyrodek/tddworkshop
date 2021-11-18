using RockPaperScissors.Backend.Moves;

namespace RockPaperScissors.Backend
{
    public class Scissors : AbstarctMove
    {

        public Scissors() : base(MoveType.SCISSORS)
        {
            winsWith = new List<MoveType>() { MoveType.PAPER };
            losesTo = new List<MoveType>() { MoveType.ROCK, MoveType.SUN };
        }

 
    }
}