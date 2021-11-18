using RockPaperScissors.Backend;
using RockPaperScissors.Backend.Moves;
using Xunit;
using System;

namespace RockPaperScisors.Backend.Tests
{
    public class MoveFactoryTests
    {
        [Fact]
        public void MoveFactory_GetingScissors_ReturnsScissorsClass()
        {
            //Arange
            MoveType moveToGenerate = MoveType.SCISSORS;
            var expetedType = typeof(Scissors);
            
            //Act
            var result = MoveFactory.GetMove(moveToGenerate);

            //Assert
            Assert.Equal(expetedType, result.GetType());
        }

        [Theory]
        [InlineData(MoveType.SCISSORS, typeof(Scissors))]
        [InlineData(MoveType.ROCK, typeof(Rock))]
        [InlineData(MoveType.PAPER, typeof(Paper))]
        [InlineData(MoveType.SUN, typeof(Sun))]
        [InlineData(MoveType.CLIPY, typeof(Clipy))]
        public void MoveFactory_SendingMoveType_ReturnsProperClass(MoveType playerMove, Type expectedType)
        {

            //Act
            var result = MoveFactory.GetMove(playerMove);

            //Assert
            Assert.Equal(expectedType, result.GetType());
        }
    }
}