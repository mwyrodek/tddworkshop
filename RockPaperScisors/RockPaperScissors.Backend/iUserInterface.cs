using RockPaperScissors.Backend.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RockPaperScissors.Backend
{
    public interface IUserInterface
    {
        GameOptions SetupGame();

        MoveType GetPlayerAction(int PlayerNumber);

        void DisplayReults(GameResult gameResult);
    }
}
