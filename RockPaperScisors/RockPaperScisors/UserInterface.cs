using RockPaperScissors.Backend;
using RockPaperScissors.Backend.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RockPaperScisors
{
    public class UserInterface : IUserInterface
    {

        private ITerminal terminal;
        private int MistakeLimit = 10;

        public UserInterface(ITerminal terminal)
        {
            this.terminal = terminal;
        }

        public void DisplayResults(GameResult gameResult)
        {

            string score = $"{gameResult.PlayerOneScore} to {gameResult.PlayerTwoScore}";

            if (gameResult.RoundWonByPlayer == 0)
            {
                this.terminal.Print($"TIE !! current score {score}");
            }
            else
            {
                this.terminal.Print($"Point for player {gameResult.RoundWonByPlayer} current score {score}");
            }
            
        }

        public MoveType GetPlayerAction(int PlayerNumber)
        {
            this.terminal.Print($"Player {PlayerNumber} your move");
            this.terminal.Print("[R]ock [P]aper [S]cisors [U]Sun [C]lipy [Q]");
            char[] legalActions = new char[] { 'R', 'P', 'S','U','C', 'Q' };

            var input = GetLegalUserActions(legalActions);
            HandleQuitRequest(input);

            switch (input)
            {
                case 'R':
                    return MoveType.ROCK;
                case 'P':
                    return MoveType.PAPER;
                case 'S':
                    return MoveType.SCISSORS;
                case 'U':
                    return MoveType.SUN;
                case 'C':
                    return MoveType.CLIPY;
                default: throw new InvalidOperationException();
            }
        }

        public GameOptions SetupGame()
        {

            this.terminal.Print("Rock Paper Scisors the game!");
            this.terminal.Print("[P]lay [Q]uit");
            char[] legalActions = new char[] { 'P', 'Q' };

            var input = GetLegalUserActions(legalActions);
            HandleQuitRequest(input);

            var options = new GameOptions();
            options.MaxWins = 3;
            this.terminal.Print($"Game is up to {options.MaxWins} wins");
            return options;
        }

        private void HandleQuitRequest(char userInput)
        {
            if (userInput == 'Q') QuitGame();
        }

        internal protected char GetLegalUserActions(char[] LegalActions)
        {
            for(int i = 0; i < this.MistakeLimit; i++)
            {
                var input = terminal.UserInput();
                if (LegalActions.Contains(input))
                {
                    return input;
                }
                this.terminal.Print($"Incorrect action avaible actions are:{new string(LegalActions)}");
            }
            throw new TooManyMistakesException();

        }
        private void QuitGame()
        {
            Environment.Exit(0);
        }
    }
}
