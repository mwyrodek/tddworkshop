using RockPaperScissors.Backend;
using RockPaperScissors.Backend.Moves;
using Xunit;


namespace RockPaperScisors.Backend.Tests
{
    public class ClipyTests
    {
        Clipy sut;
        
        public ClipyTests()
        {
            sut = new Clipy();
        }

        [Fact]
        public void Clipy_GetType_ReturnsClipy()
        {
            var actualType = sut.MoveType;
            Assert.Equal(MoveType.CLIPY, actualType);
        }

        [Theory]
        [InlineData(MoveType.SCISSORS, TurnResult.WIN)]
        [InlineData(MoveType.PAPER, TurnResult.WIN)]
        [InlineData(MoveType.ROCK, TurnResult.LOSE)]
        [InlineData(MoveType.SUN, TurnResult.LOSE)]
        [InlineData(MoveType.CLIPY, TurnResult.TIE)]
        public void Clipy_IsWinning_ReturnsExpected(MoveType playerMove, TurnResult expected)
        {
            var actualResult = sut
                .IsWinning(playerMove);
            Assert.Equal(expected, actualResult);
        }
    }
}
