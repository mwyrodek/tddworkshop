using NUnit.Framework;
using RockPaperScissors.Backend;
using FluentAssertions;
using RockPaperScissors.Backend.Models;

namespace RockPaperScisors.Nunit.Tests
{
    public class PaperTests
    {

        Paper sut = new Paper();

        [Test]
        public void Paper_GetType_ReturnsPaper()
        {
            var actualType = sut.MoveType;
            Assert.AreEqual(MoveType.PAPER, actualType, "Paper class should have paper type!");

        }

        [Test]
        public void Paper_GetType_ReturnsPaper_ThatExample()
        {

            var actualType = sut.MoveType;
            Assert.That(actualType, Is.EqualTo(MoveType.PAPER));
        }

        [Test]
        public void Paper_GetType_ReturnsPaper_FluentExample()
        {
            sut.MoveType
                .Should()
                .Be(MoveType.PAPER);
        }

        [TestCase(MoveType.SCISSORS, TurnResult.LOSE)]
        [TestCase(MoveType.PAPER, TurnResult.TIE)]
        [TestCase(MoveType.ROCK, TurnResult.WIN)]
        public void Paper_IsWinning_ReturnsExpected(MoveType playerMove, TurnResult expected)
        {
                sut.IsWinning(playerMove)
                .Should()
                .Be(expected);
        }

        [TestCase(MoveType.SCISSORS, ExpectedResult = TurnResult.LOSE)]
        [TestCase(MoveType.PAPER, ExpectedResult = TurnResult.TIE)]
        [TestCase(MoveType.ROCK, ExpectedResult = TurnResult.WIN)]
        public TurnResult Paper_IsWinning_ReturnsExpected_OtherAssertion(MoveType playerMove)
        {
            return sut.IsWinning(playerMove);
        }
    }
}