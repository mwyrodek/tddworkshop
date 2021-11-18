using RockPaperScissors.Backend.Moves;

namespace RockPaperScissors.Backend
{
    public class Rock: AbstarctMove
    {
  
        public Rock(): base(MoveType.ROCK) {
            winsWith = new List<MoveType>() { MoveType.SCISSORS, MoveType.CLIPY};
            losesTo = new List<MoveType>() { MoveType.PAPER, MoveType.SUN };
        }


    }
}