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
        Mock<IUserInterface> mockUI;

        public GameEngineTest()
        {
           mockUI = new Mock<IUserInterface>();
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


            Assert.Throws<ArgumentOutOfRangeException>(() => sut.ExposedSetupGame());
        }

        //todo add info
        [Fact]
        public void GameInProgress_WinsLimitReached_GameFinishes()
        {
            GameOptions gameOptions = new GameOptions();
            gameOptions.MaxWins = 1;
            mockUI.Setup(x => x.SetupGame()).Returns(gameOptions);
            sut.ExposedSetupGame();
            PlayerActions playersActions = new PlayerActions();
            playersActions.PlayerOneMove = MoveType.SCISSORS;
            playersActions.PlayerTwoMove = MoveType.PAPER;

            var Result = sut.ExposedPlayTurn(playersActions);

            Assert.True(Result.Finshed);
        }

        [Fact]
        public void GameInProgress_AfterTurn_ReturnsPlayerOneScore()
        {
            GameOptions gameOptions = new GameOptions();
            gameOptions.MaxWins = 1;
            mockUI.Setup(x => x.SetupGame()).Returns(gameOptions);
            sut.ExposedSetupGame();

            PlayerActions playersActions = new PlayerActions();
            playersActions.PlayerOneMove = MoveType.SCISSORS;
            playersActions.PlayerTwoMove = MoveType.PAPER;

            var Result = sut.ExposedPlayTurn(playersActions);

            Assert.Equal(1, Result.PlayerOneScore);
        }

        [Fact]
        public void GameInProgress_AfterTurn_ReturnsPlayerTwoScore()
        {
            GameOptions gameOptions = new GameOptions();
            gameOptions.MaxWins = 1;
            mockUI.Setup(x => x.SetupGame()).Returns(gameOptions);
            sut.ExposedSetupGame();

            PlayerActions playersActions = new PlayerActions();
            playersActions.PlayerOneMove = MoveType.SCISSORS;
            playersActions.PlayerTwoMove = MoveType.PAPER;

            var Result = sut.ExposedPlayTurn(playersActions);

            Assert.Equal(0, Result.PlayerTwoScore);
        }

        [Fact]
        public void GameInProgress_AfterTurn_ReturnsTurnCount()
        {
            GameOptions gameOptions = new GameOptions();
            gameOptions.MaxWins = 1;
            mockUI.Setup(x => x.SetupGame()).Returns(gameOptions);
            sut.ExposedSetupGame();

            PlayerActions playersActions = new PlayerActions();
            playersActions.PlayerOneMove = MoveType.SCISSORS;
            playersActions.PlayerTwoMove = MoveType.PAPER;

            var Result = sut.ExposedPlayTurn(playersActions);

            Assert.Equal(1, Result.TurnsFinished);
        }

        [Fact]
        public void GameInProgress_PlayerTwoWinsRound_ResultsAreUpdated()
        {
            GameOptions gameOptions = new GameOptions();
            gameOptions.MaxWins = 1;
            mockUI.Setup(x => x.SetupGame()).Returns(gameOptions);
            sut.ExposedSetupGame();

            PlayerActions playersActions = new PlayerActions();
            playersActions.PlayerOneMove = MoveType.SCISSORS;
            playersActions.PlayerTwoMove = MoveType.ROCK;

            var Result = sut.ExposedPlayTurn(playersActions);

            Assert.Equal(2, Result.RoundWonByPlayer );
            Assert.Equal(0, Result.PlayerOneScore);
            Assert.Equal(1, Result.PlayerTwoScore);

        }

        [Fact]
        public void GameInProgress_Tie_ResultsAreUpdated()
        {
            GameOptions gameOptions = new GameOptions();
            gameOptions.MaxWins = 1;
            mockUI.Setup(x => x.SetupGame()).Returns(gameOptions);
            sut.ExposedSetupGame();

            PlayerActions playersActions = new PlayerActions();
            playersActions.PlayerOneMove = MoveType.ROCK;
            playersActions.PlayerTwoMove = MoveType.ROCK;

            var Result = sut.ExposedPlayTurn(playersActions);

            Assert.Equal(0, Result.RoundWonByPlayer);
            Assert.Equal(0, Result.PlayerOneScore);
            Assert.Equal(0, Result.PlayerTwoScore);

        }
        [Fact]
        public void GameInProgress_CantPlayMorewsThenPlaned()
        {
            GameOptions gameOptions = new GameOptions();
            gameOptions.MaxWins = 1;
            mockUI.Setup(x => x.SetupGame()).Returns(gameOptions);
            sut.ExposedSetupGame();

            sut.ExposedGameResult.Finshed = true;


            PlayerActions playersActions = new PlayerActions();
            playersActions.PlayerOneMove = MoveType.SCISSORS;
            playersActions.PlayerTwoMove = MoveType.PAPER;


            Assert.Throws<InvalidOperationException>(() => sut.ExposedPlayTurn(playersActions));
        }


        public class TestAbleEngine : GameEngine
        {
            public TestAbleEngine(IUserInterface ui) : base(ui)
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

            public void ExposedSetupGame()
            {
                SetupGame();
            }
            public GameResult ExposedPlayTurn(PlayerActions playersActions)
            {
                return PlayTurn(playersActions);
            }
        }
    }
}
