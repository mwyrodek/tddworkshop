using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RockPaperScissors.Backend.Moves
{
    public interface IMove
    {
         MoveType MoveType { get; }

         TurnResult IsWinning(MoveType move);
    }
}
