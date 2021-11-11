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

            Assert.Equal(MoveTypes.PAPER, paper.MoveType);
        }


        [Theory]
        [InlineData(MoveTypes.ROCK)]
        public void Paper_WinWith(MoveTypes move)
        {
            Paper paper = new Paper();

            var actual = paper.IsWinning(move);

            Assert.Equal(MatchResult.WIN, actual);
        }

        [Theory]
        [InlineData(MoveTypes.SCISSORS)]
        public void Paper_LosesTo(MoveTypes move)
        {
            Paper paper = new Paper();

            var actual = paper.IsWinning(move);

            Assert.Equal(MatchResult.LOSE, actual);
        }

        [Theory]
        [InlineData(MoveTypes.PAPER)]
        public void Paper_TiesWithRock(MoveTypes move)
        {
            Paper paper = new Paper();

            var actual = paper.IsWinning(move);

            Assert.Equal(MatchResult.TIE, actual);
        }
    }
}