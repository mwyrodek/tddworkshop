using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RockPaperScisors
{
    internal class ComandLineTerminal : iTerminal
    {
        public void Print(string messege)
        {

            Console.WriteLine(messege);
        }

        public char UserInput()
        {
            var input = Char.ToUpper(Console.ReadKey().KeyChar);
            Console.Clear(); 
            return input;
        }
    }
}
