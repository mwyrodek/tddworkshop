using RockPaperScissors.Backend;
using Xunit;

namespace RockPaperScisors.Backend.Tests
{
    public class PaperTests
    {
        Paper sut;

        public PaperTests()
        {
            sut = new Paper();
        }
        [Fact]
        public void Paper_GetType_ReturnsPaper()
        {
            var sut = new Paper();

            var actualType = sut.MoveType;
            Assert.Equal(MoveType.PAPER, actualType);
        }

        [Theory]
        [InlineData(MoveType.SCISSORS, TurnResult.LOSE)]
        [InlineData(MoveType.PAPER, TurnResult.TIE)]
        [InlineData(MoveType.ROCK, TurnResult.WIN)]
        public void Paper_IsWinning_ReturnsExpected(MoveType playerMove, TurnResult expected)
        {
            var actualResult = new Paper()
                .IsWinning(playerMove);
            Assert.Equal(expected, actualResult);
        }

    }
}
