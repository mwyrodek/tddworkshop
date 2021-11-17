using RockPaperScissors.Backend.Models;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace RockPaperScisors.FrontEnd.Tests
{
    public class UserInterfaceTests
    {
        [Fact]
        public void DisplayResults_GameIsTied_DisplaysTieWithScore()
        {
            var spyTerminal = new SpyTerminal();
            var results = new GameResult();
            results.RoundWonByPlayer = 0;
            results.PlayerOneScore = 3;
            results.PlayerTwoScore = 2;
            var sut = new UserInterface(spyTerminal);

            sut.DisplayResults(results);

            var actualMessege = spyTerminal.Prints.First();

            Assert.Equal("TIE !! current score 3 to 2", actualMessege);

        }

        [Fact]
        public void SetupGame_PlayersSelectP_GameOptionsAreSet()
        {
            var spyTerminal = new SpyTerminal();
            spyTerminal.Inputs.Push('P');
            var expetedMaxWins = 3;
            var expetedPrintCalls = 3;
            var sut = new UserInterface(spyTerminal);

            var actualOptions = sut.SetupGame();

            Assert.Equal(expetedPrintCalls, spyTerminal.Prints.Count);
            Assert.Equal(expetedMaxWins, actualOptions.MaxWins);
        }
    }

    public class SpyTerminal : ITerminal
    {
        public List<string> Prints { get; set; }
        public Stack<char> Inputs { get; set; }
        public SpyTerminal()
        {
            Prints = new List<string>();
            Inputs = new Stack<char>();
        }
        public void Print(string messege)
        {
            Prints.Add(messege);
        }

        public char UserInput()
        {
            return Inputs.Pop();
        }
    }
}