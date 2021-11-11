using Xunit;
using RockPaperScissors.Backend;

namespace RockPaperScissors.Backend.Tests
{
    public class ScissorsTest
    {
        [Fact]
        public void Scissors_HasScissorsMoveType()
        {
            Scissors scissors = new Scissors();

            Assert.Equal(MoveTypes.SCISSORS, scissors.MoveType);
        }


        [Theory]
        [InlineData(MoveTypes.PAPER)]
        public void Scissors_WinWith(MoveTypes move)
        {
            Scissors scissors = new Scissors();

            var actual = scissors.IsWinning(move);

            Assert.Equal(MatchResult.WIN, actual);
        }

        [Theory]
        [InlineData(MoveTypes.ROCK)]
        public void Scissors_LosesTo(MoveTypes move)
        {
            Scissors scissors = new Scissors();

            var actual = scissors.IsWinning(move);

            Assert.Equal(MatchResult.LOSE, actual);
        }

        [Theory]
        [InlineData(MoveTypes.SCISSORS)]
        public void Scissors_TiesWithScissors(MoveTypes move)
        {
            Scissors scissors = new Scissors();

            var actual = scissors.IsWinning(move);

            Assert.Equal(MatchResult.TIE, actual);
        }
    }
}