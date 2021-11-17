using Moq;
using RockPaperScissors.Backend;
using RockPaperScissors.Backend.Models;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace RockPaperScisors.FrontEnd.Tests
{
    public class UserInterfaceTests
    {
        Mock<ITerminal> mockTerminal;
        public UserInterfaceTests()
        {
            mockTerminal = new Mock<ITerminal>();
        }

        [Fact]
        public void DisplayResults_GameIsTied_DisplaysTieWithScore()
        {
            var results = new GameResult();
            results.RoundWonByPlayer = 0;
            results.PlayerOneScore = 3;
            results.PlayerTwoScore = 2;
            var sut = new UserInterface(mockTerminal.Object);

            sut.DisplayResults(results);

            mockTerminal.Verify(t => t.Print(It.Is<string>(s => s.Equals("TIE !! current score 3 to 2"))));
        }

        [Fact]
        public void SetupGame_PlayersSelectP_GameOptionsAreSet()
        {
            mockTerminal.Setup(t => t.UserInput()).Returns('P');
            var expetedMaxWins = 3;
            var expetedPrintCalls = 3;
            var sut = new UserInterface(mockTerminal.Object);

            var actualOptions = sut.SetupGame();
      
            mockTerminal.Verify(t => t.Print(It.IsAny<string>()),Times.Exactly(expetedPrintCalls));
            Assert.Equal(expetedMaxWins, actualOptions.MaxWins);
        }

        [Fact]
        public void LegalUserActions_UserMakesMistakeTwoTimesThenSendProperResponse_ResponseAccepted()
        {
            mockTerminal.SetupSequence(t => t.UserInput()).Returns('S').Returns('A').Returns('P');

            var expetedPrintCalls = 2;
            var sut = new TestAbleUserInteface(mockTerminal.Object);
            var expectedActions = new char[] { 'P', 'C' };

            var actualResult = sut.PublicGetLegalUserActions(expectedActions);

            mockTerminal.Verify(t => t.Print(It.IsAny<string>()), Times.Exactly(expetedPrintCalls));
            Assert.Equal(expectedActions[0], actualResult);
        }

        [Theory]
        [InlineData('S', MoveType.SCISSORS)]
        [InlineData('P', MoveType.PAPER)]
        [InlineData('R', MoveType.ROCK)]
        public void GetPlayerAction_TakeUserInput_ReturnMove(char input, MoveType expectedResult)
        {
            mockTerminal.Setup(t => t.UserInput()).Returns(input);

            var expetedPrintCalls = 2;
            var playerNumber = 2;
            var sut = new TestAbleUserInteface(mockTerminal.Object);
    
            var actualResult = sut.GetPlayerAction(playerNumber);
            Assert.Equal(expectedResult, actualResult);
        }

        [Theory]
        [InlineData('S', MoveType.SCISSORS)]
        public void GetPlayerAction_TakeUserInput_ProperInfoIsDisplayed(char input, MoveType expectedResult)
        {
            mockTerminal.Setup(t => t.UserInput()).Returns(input);

            var expetedPrintCalls = 2;
            var playerNumber = 2;
            var sut = new TestAbleUserInteface(mockTerminal.Object);

            var actualResult = sut.GetPlayerAction(playerNumber);
            mockTerminal.Verify(t => t.Print(It.IsAny<string>()), Times.Exactly(expetedPrintCalls));
            mockTerminal.Verify(t => t.Print(It.Is<string>(s => s.Contains($"Player {playerNumber} your move"))));
            mockTerminal.Verify(t => t.Print(It.Is<string>(s => s.Contains($"[R]ock [P]aper [S]cisors [Q]"))));
        }

    }

    internal class TestAbleUserInteface : UserInterface
    {
        public TestAbleUserInteface(ITerminal terminal) : base(terminal)
        {
        }

        public char PublicGetLegalUserActions(char[] LegalActions)
        {
            return this.GetLegalUserActions(LegalActions);
        }

    }
}