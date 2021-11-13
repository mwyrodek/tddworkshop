using Moq;
using RockPaperScissors.Backend.Models;
using Xunit;

namespace RockPaperScisors.FrontEnd.Tests
{
    public class UserInterfaceTests
    {
        UserInterface sut;
        Mock<ITerminal> mocKTerimnal;

        public UserInterfaceTests()
        {
            mocKTerimnal = new Mock<ITerminal>();

            sut = new UserInterface(mocKTerimnal.Object);
        }

        [Fact]
        public void DisplayResults_PlayersTied_ResultHasTieInfo()
        {
            GameResult gameResult = new GameResult();
            gameResult.RoundWonByPlayer = 0;
            gameResult.PlayerOneScore = 2;
            gameResult.PlayerTwoScore = 1;

            sut.DisplayReults(gameResult);
            mocKTerimnal.Verify(t => t.Print(It.Is<string>(s => s.Contains("TIE"))), Times.Once);
            mocKTerimnal.Verify(t => t.Print(It.Is<string>(s => s.Contains("2 to 1"))), Times.Once);
        }

        [Fact]
        public void DisplayResults_PlayerWon_ResultHasProperInfo()
        {
            GameResult gameResult = new GameResult();
            gameResult.RoundWonByPlayer = 2;
            gameResult.PlayerOneScore = 1;
            gameResult.PlayerTwoScore = 2;

            sut.DisplayReults(gameResult);
            mocKTerimnal.Verify(t => t.Print(It.Is<string>(s => s.Contains("player 2"))), Times.Once);
            mocKTerimnal.Verify(t => t.Print(It.Is<string>(s => s.Contains("1 to 2"))), Times.Once);
        }
    }
}