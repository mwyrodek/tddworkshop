using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RockPaperScisors
{
    public interface ITerminal
    {
        void Print(string messege);

        char UserInput();
    }
}
