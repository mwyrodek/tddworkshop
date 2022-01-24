using RockPaperScissors.Backend;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using AutoFixture;
using AutoFixture.AutoMoq;
using Moq;
using RockPaperScissors.Backend.Models;
using DeepEqual;
using DeepEqual.Syntax;

namespace RockPaperScisors.Backend.Tests
{
    public class GameEngineTests
    {
        private IFixture fixture;

        public GameEngineTests()
        {
            fixture = new Fixture().Customize(new AutoMoqCustomization());
        }

        [Fact]
        public void SetupGame_NotEnoughMaxwins_ThrowsError()
        {
            var options = fixture.Create<GameOptions>();
            options.MaxWins = 0;
            fixture.Register(() => options);
            fixture.Freeze<GameOptions>();
            var uiMock = fixture.Freeze<Mock<IUserInterface>>();

            var sut = fixture.Create<TestableGameEngine>();

            Assert.Throws<ArgumentOutOfRangeException>(() =>
            {
                sut.TestableSetupGame();
            });
        }

        [Fact]
        public void SetupGame_ProperCountOfWinsProived_ThrowsError()
        {
            var options = fixture.Create<GameOptions>();
            options.MaxWins = 1;
            fixture.Register(() => options);
            fixture.Freeze<GameOptions>();
            fixture.Register(() => new GameResult());

            var expetedResults = fixture.Create<GameResult>();
            var uiMock = fixture.Freeze<Mock<IUserInterface>>();

            var sut = fixture.Create<TestableGameEngine>();

            sut.TestableGameResults.ShouldDeepEqual(expetedResults);
        }

        [Fact]
        public void PlayTurn_AfterGameHasFinished_EndsInError()
        {
            var result = fixture.Create<GameResult>();
            result.Finshed = true;
            fixture.Register(() => result);

            var uiMock = fixture.Freeze<Mock<IUserInterface>>();

            var sut = fixture.Create<TestableGameEngine>();

            Assert.Throws<InvalidOperationException>(() =>
            {
                sut.TestablePlayTurn(fixture.Create<PlayerActions>());
            });
        }

        [Fact]
        public void PlayTurn_PlayersSendTheirActions_GameReultsDisplayed()
        {
            var result = fixture.Create<GameResult>();
            result.Finshed = false;
            fixture.Register(() => result);
            var actions = new PlayerActions();
            actions.PlayerOneMove = MoveType.PAPER;
            actions.PlayerTwoMove = MoveType.ROCK;

            var expetedResult = fixture.Create<GameResult>();
            expetedResult.RoundWonByPlayer = 1;
            expetedResult.PlayerOneScore++;

            var uiMock = fixture.Freeze<Mock<IUserInterface>>();

            var sut = fixture.Create<TestableGameEngine>();

            var gameResult = sut.TestablePlayTurn(actions);

            gameResult.ShouldDeepEqual(expetedResult);
        }

        [Fact]
        public void GameDoenstCloseAfterPlayerWin()
        {
            var uiMock = fixture.Freeze<Mock<IUserInterface>>();
            var GameOptions = new GameOptions();
            GameOptions.MaxWins = 2;

            uiMock.Setup(ui => ui.SetupGame())
            .Returns(GameOptions);
            uiMock.SetupSequence(ui => ui.GetPlayerAction(It.IsAny<int>()))
                .Returns(MoveType.SCISSORS)
                .Returns(MoveType.ROCK)
                 .Returns(MoveType.SCISSORS)
                .Returns(MoveType.ROCK)
                .Returns(MoveType.SCISSORS)
                .Returns(MoveType.ROCK)
                 .Returns(MoveType.SCISSORS)
                .Returns(MoveType.ROCK);

            uiMock.SetupSequence(ui => ui.Continue())
                           .Returns(true)
                           .Returns(false);

            var sut = fixture.Create<TestableGameEngine>();

            sut.RunGame();

            uiMock.Verify(ui => ui.SetupGame(), Times.Exactly(2));
        }
    }

    internal class TestableGameEngine : GameEngine
    {
        public TestableGameEngine(IUserInterface Ui, GameResult result) : base(Ui)
        {
            base.GameResult = result;
        }

        public void TestableSetupGame()
        {
            this.SetupGame();
        }

        public GameResult TestablePlayTurn(PlayerActions playersActions)
        {
            return this.PlayTurn(playersActions);
        }


        public GameResult TestableGameResults
        {
            get { return this.GameResult; }
            set { this.GameResult = value; }

        }
    }

}
