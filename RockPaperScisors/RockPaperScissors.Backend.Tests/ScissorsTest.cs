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

            Assert.Equal(MoveType.SCISSORS, scissors.MoveType);
        }


        [Theory]
        [InlineData(MoveType.PAPER)]
        public void Scissors_WinWith(MoveType move)
        {
            Scissors scissors = new Scissors();

            var actual = scissors.IsWinning(move);

            Assert.Equal(TurnResult.WIN, actual);
        }

        [Theory]
        [InlineData(MoveType.ROCK)]
        public void Scissors_LosesTo(MoveType move)
        {
            Scissors scissors = new Scissors();

            var actual = scissors.IsWinning(move);

            Assert.Equal(TurnResult.LOSE, actual);
        }

        [Theory]
        [InlineData(MoveType.SCISSORS)]
        public void Scissors_TiesWithScissors(MoveType move)
        {
            Scissors scissors = new Scissors();

            var actual = scissors.IsWinning(move);

            Assert.Equal(TurnResult.TIE, actual);
        }
    }
}