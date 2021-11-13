using Xunit;
using RockPaperScissors.Backend;
using System;
using RockPaperScissors.Backend.Models;
using Moq;
using System.Collections.Generic;

namespace RockPaperScissors.Backend.Tests
{
    public class GameEngineE2ETest
    {
        GameEngine sut;
        MockUi mockUI;

        public GameEngineE2ETest()
        {
           mockUI = new MockUi();
            sut = new GameEngine(mockUI);
        }

        //game lenght 3
        //absolute vicory of p1
        //r-s
        //p-r
        //s-p
        //check final result

        [Fact]
        public void PlayerOneAbsoulteWin()
        {
            mockUI.GameOptions.MaxWins = 3;
            //last move
            mockUI.MoveType.Push(MoveType.PAPER);
            mockUI.MoveType.Push(MoveType.SCISSORS);
            mockUI.MoveType.Push(MoveType.ROCK);
            mockUI.MoveType.Push(MoveType.PAPER);
            mockUI.MoveType.Push(MoveType.SCISSORS);
            //fist move
            mockUI.MoveType.Push(MoveType.ROCK);

            sut.RunGame();

            Assert.True(mockUI.GameResult.Finshed);
            Assert.Equal(3, mockUI.GameResult.PlayerOneScore);
            Assert.Equal(0, mockUI.GameResult.PlayerTwoScore);
            Assert.Equal(3, mockUI.GameResult.TurnsFinished);
        }

        public class MockUi : IUserInterface
        {
            public GameResult GameResult { get; set; }

            public Stack<MoveType> MoveType { get; set; }

            public GameOptions GameOptions { get; set; }

            public MockUi()
            { 
                GameOptions = new GameOptions();
                GameResult = new GameResult();
                MoveType = new Stack<MoveType>();
            }
            public void DisplayReults(GameResult gameResult)
            {
                GameResult = gameResult;
            }

            public MoveType GetPlayerAction(int PlayerNumber)
            {
                return MoveType.Pop();
            }

            public GameOptions SetupGame()
            {
                return GameOptions;
            }
        }
    }
}
