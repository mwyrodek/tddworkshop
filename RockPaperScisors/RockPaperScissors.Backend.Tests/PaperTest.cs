using Xunit;
using RockPaperScissors.Backend;

namespace RockPaperScissors.Backend.Tests
{
    public class PaperTest
    {
        [Fact]
        public void Paper_HasPaperMoveType()
        {
            Paper paper = new Paper();

            Assert.Equal(MoveType.PAPER, paper.MoveType);
        }


        [Theory]
        [InlineData(MoveType.ROCK)]
        public void Paper_WinWith(MoveType move)
        {
            Paper paper = new Paper();

            var actual = paper.IsWinning(move);

            Assert.Equal(TurnResult.WIN, actual);
        }

        [Theory]
        [InlineData(MoveType.SCISSORS)]
        public void Paper_LosesTo(MoveType move)
        {
            Paper paper = new Paper();

            var actual = paper.IsWinning(move);

            Assert.Equal(TurnResult.LOSE, actual);
        }

        [Theory]
        [InlineData(MoveType.PAPER)]
        public void Paper_TiesWithRock(MoveType move)
        {
            Paper paper = new Paper();

            var actual = paper.IsWinning(move);

            Assert.Equal(TurnResult.TIE, actual);
        }
    }
}