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

            Assert.Equal(MoveType.ROCK, rock.MoveType);
        }


        [Theory]
        [InlineData(MoveType.SCISSORS)]
        public void Rock_WinWith(MoveType move)
        {
            Rock rock = new Rock();

            var actual = rock.IsWinning(move);

            Assert.Equal(TurnResult.WIN, actual);
        }

        [Theory]
        [InlineData(MoveType.PAPER)]
        public void Rock_LosesTo(MoveType move)
        {
            Rock rock = new Rock();

            var actual = rock.IsWinning(move);

            Assert.Equal(TurnResult.LOSE, actual);
        }

        [Theory]
        [InlineData(MoveType.ROCK)]
        public void Rock_TiesWithRock(MoveType move)
        {
            Rock rock = new Rock();

            var actual = rock.IsWinning(move);

            Assert.Equal(TurnResult.TIE, actual);
        }
    }
}