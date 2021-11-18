using RockPaperScissors.Backend;
using Xunit;

namespace RockPaperScisors.Backend.Tests
{
    public class ScissorsTests
    {
        Scissors sut;

        public ScissorsTests()
        {
            sut = new Scissors();
        }
        [Fact]
        public void Scissors_GetType_ReturnsScissors()
        {
            var actualType = sut.MoveType;
            Assert.Equal(MoveType.SCISSORS, actualType);
        }

        [Theory]
        [InlineData(MoveType.SUN, TurnResult.WIN)]
        [InlineData(MoveType.SCISSORS, TurnResult.TIE)]
        [InlineData(MoveType.PAPER, TurnResult.WIN)]
        [InlineData(MoveType.ROCK, TurnResult.LOSE)]
        [InlineData(MoveType.CLIPY, TurnResult.LOSE)]
        public void Scissors_IsWinning_ReturnsExpected(MoveType playerMove, TurnResult expected)
        {
            var actualResult = sut
                .IsWinning(playerMove);
            Assert.Equal(expected, actualResult);
        }
    }
}
