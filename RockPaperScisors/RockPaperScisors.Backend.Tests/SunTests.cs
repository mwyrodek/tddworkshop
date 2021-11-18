using RockPaperScissors.Backend;
using RockPaperScissors.Backend.Moves;
using Xunit;

namespace RockPaperScisors.Backend.Tests
{
    public class SunTests
    {
        Sun sut;

        public SunTests()
        { 
            sut = new Sun();
        }

        [Fact]
        public void Sun_GetType_ReturnsSun()
        {
            var actualType = sut.MoveType;
            Assert.Equal(MoveType.SUN, actualType);
        }

        [Theory]
        [InlineData(MoveType.SCISSORS, TurnResult.LOSE)]
        [InlineData(MoveType.PAPER, TurnResult.LOSE)]
        [InlineData(MoveType.ROCK, TurnResult.WIN)]
        [InlineData(MoveType.SUN, TurnResult.TIE)]
        [InlineData(MoveType.CLIPY, TurnResult.WIN)]
        public void Sun_IsWinning_ReturnsExpected(MoveType playerMove, TurnResult expected)
        {
            var actualResult = sut
                .IsWinning(playerMove);
            Assert.Equal(expected, actualResult);
        }

    }
}
