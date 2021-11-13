using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RockPaperScissors.Backend.Models
{
    public class GameResult
    {
        public int TurnsFinished { get; set; }
        public int PlayerOneScore { get; set; }
        public int PlayerTwoScore { get; set; }
        public bool Finshed { get; set; }

        public int RoundWonByPlayer { get; set; }

        public GameResult()
        {
            TurnsFinished = 0;
            PlayerOneScore = 0;
            PlayerTwoScore = 0;
            Finshed = false;
        }
    }
}
