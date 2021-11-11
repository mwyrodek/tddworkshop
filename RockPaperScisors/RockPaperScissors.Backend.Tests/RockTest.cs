using Xunit;
using RockPaperScissors.Backend;

namespace RockPaperScissors.Backend.Tests
{
    public class RockTest
    {
        [Fact]
        public void Rock_HasRockMoveType()
        {
            Rock rock = new Rock();

            Assert.Equal(MoveTypes.ROCK, rock.MoveType);
        }


        [Theory]
        [InlineData(MoveTypes.SCISSORS)]
        public void Rock_WinWith(MoveTypes move)
        {
            Rock rock = new Rock();

            var actual = rock.IsWinning(move);

            Assert.Equal(MatchResult.WIN, actual);
        }

        [Theory]
        [InlineData(MoveTypes.PAPER)]
        public void Rock_LosesTo(MoveTypes move)
        {
            Rock rock = new Rock();

            var actual = rock.IsWinning(move);

            Assert.Equal(MatchResult.LOSE, actual);
        }

        [Theory]
        [InlineData(MoveTypes.ROCK)]
        public void Rock_TiesWithRock(MoveTypes move)
        {
            Rock rock = new Rock();

            var actual = rock.IsWinning(move);

            Assert.Equal(MatchResult.TIE, actual);
        }
    }
}