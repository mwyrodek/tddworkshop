using Xunit;
using RockPaperScissors.Backend;
using System;
using RockPaperScissors.Backend.Models;
using Moq;

namespace RockPaperScissors.Backend.Tests
{
    public class GameEngineTest
    {
        TestAbleEngine sut;
        Mock<iUserInterface> mockUI;

        public GameEngineTest()
        {
           mockUI = new Mock<iUserInterface>();
            sut = new TestAbleEngine(mockUI.Object);
        }



        [Theory]
        [InlineData(0)]
        [InlineData(-1)]
        public void CreateGame_WithZeroWins_EndInError(int maxWins)
        {
            GameOptions gameOptions = new GameOptions();

            gameOptions.MaxWins = maxWins;
            mockUI.Setup(x => x.SetupGame()).Returns(gameOptions);


            Assert.Throws<ArgumentOutOfRangeException>(() => sut.SetupGame());
        }

        //todo add info
        [Fact]
        public void GameInProgress_WinsLimitReached_GameFinishes()
        {
            GameOptions gameOptions = new GameOptions();
            gameOptions.MaxWins = 1;
            mockUI.Setup(x => x.SetupGame()).Returns(gameOptions);
            sut.SetupGame();
            PlayerActions playersActions = new PlayerActions();
            playersActions.PlayerOneMove = MoveType.SCISSORS;
            playersActions.PlayerTwoMove = MoveType.PAPER;

            var Result = sut.PlayTurn(playersActions);

            Assert.True(Result.Finshed);
        }

        [Fact]
        public void GameInProgress_AfterTurn_ReturnsPlayerOneScore()
        {
            GameOptions gameOptions = new GameOptions();
            gameOptions.MaxWins = 1;
            mockUI.Setup(x => x.SetupGame()).Returns(gameOptions);
            sut.SetupGame();

            PlayerActions playersActions = new PlayerActions();
            playersActions.PlayerOneMove = MoveType.SCISSORS;
            playersActions.PlayerTwoMove = MoveType.PAPER;

            var Result = sut.PlayTurn(playersActions);

            Assert.Equal(1, Result.PlayerOneScore);
        }

        [Fact]
        public void GameInProgress_AfterTurn_ReturnsPlayerTwoScore()
        {
            GameOptions gameOptions = new GameOptions();
            gameOptions.MaxWins = 1;
            mockUI.Setup(x => x.SetupGame()).Returns(gameOptions);
            sut.SetupGame();

            PlayerActions playersActions = new PlayerActions();
            playersActions.PlayerOneMove = MoveType.SCISSORS;
            playersActions.PlayerTwoMove = MoveType.PAPER;

            var Result = sut.PlayTurn(playersActions);

            Assert.Equal(0, Result.PlayerTwoScore);
        }

        [Fact]
        public void GameInProgress_AfterTurn_ReturnsTurnCount()
        {
            GameOptions gameOptions = new GameOptions();
            gameOptions.MaxWins = 1;
            mockUI.Setup(x => x.SetupGame()).Returns(gameOptions);
            sut.SetupGame();

            PlayerActions playersActions = new PlayerActions();
            playersActions.PlayerOneMove = MoveType.SCISSORS;
            playersActions.PlayerTwoMove = MoveType.PAPER;

            var Result = sut.PlayTurn(playersActions);

            Assert.Equal(1, Result.TurnsFinished);
        }

        [Fact]
        public void GameInProgress_CantPlayMoreRoundsThenPlaned()
        {
            GameOptions gameOptions = new GameOptions();
            gameOptions.MaxWins = 1;
            mockUI.Setup(x => x.SetupGame()).Returns(gameOptions);
            sut.SetupGame();

            sut.ExposedGameResult.Finshed = true;


            PlayerActions playersActions = new PlayerActions();
            playersActions.PlayerOneMove = MoveType.SCISSORS;
            playersActions.PlayerTwoMove = MoveType.PAPER;


            Assert.Throws<InvalidOperationException>(() => sut.PlayTurn(playersActions));
        }

        public class TestAbleEngine : GameEngine
        {
            public TestAbleEngine(iUserInterface ui) : base(ui)
            {
            }

            public GameResult ExposedGameResult
            {
                get
                {
                    return GameResult;
                }
                set
                {
                    GameResult = value;
                }
            }
        }
    }
}
