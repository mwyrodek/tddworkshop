using RockPaperScissors.Backend;
using Xunit;

namespace RockPaperScisors.Backend.Tests
{
    public class RockTests
    {
        Rock sut;

        public RockTests()
        {
            sut = new Rock();
        }

        [Fact]
        public void Rock_GetType_ReturnsRock()
        {
            var actualType = sut.MoveType;
            Assert.Equal(MoveType.ROCK, actualType);
        }

        [Theory]
        [InlineData(MoveType.SUN, TurnResult.WIN)]
        public void Rock_IsWinning_ReturnsExpected(MoveType playerMove, TurnResult expected)
        {
            var actualResult = sut
                .IsWinning(playerMove);
            Assert.Equal(expected, actualResult);
        }
    }
}
