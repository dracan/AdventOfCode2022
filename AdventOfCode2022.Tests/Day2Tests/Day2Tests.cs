using FluentAssertions;

namespace AdventOfCode2022.Tests.Day2Tests;

using Day2 = Day2.Day2;

public class Day2Tests
{
    [Fact]
    public void CalculateTotalGameScoreFromInputFileTest_Part1() =>
        Day2.CalculateTotalScoreFromInputFile_Part1().Should().Be(13005);

    [Fact]
    public void CalculateTotalGameScoreFromInputFileTest_Part2() =>
        Day2.CalculateTotalScoreFromInputFile_Part2().Should().Be(11373);

    [Theory]
    [InlineData(Day2.MoveType.Rock, Day2.MoveType.Rock, Day2.GameResult.Draw)]
    [InlineData(Day2.MoveType.Rock, Day2.MoveType.Paper, Day2.GameResult.Win)]
    [InlineData(Day2.MoveType.Rock, Day2.MoveType.Scissors, Day2.GameResult.Lose)]
    [InlineData(Day2.MoveType.Paper, Day2.MoveType.Rock, Day2.GameResult.Lose)]
    [InlineData(Day2.MoveType.Paper, Day2.MoveType.Paper, Day2.GameResult.Draw)]
    [InlineData(Day2.MoveType.Paper, Day2.MoveType.Scissors, Day2.GameResult.Win)]
    [InlineData(Day2.MoveType.Scissors, Day2.MoveType.Rock, Day2.GameResult.Win)]
    [InlineData(Day2.MoveType.Scissors, Day2.MoveType.Paper, Day2.GameResult.Lose)]
    [InlineData(Day2.MoveType.Scissors, Day2.MoveType.Scissors, Day2.GameResult.Draw)]
    public void CalculateGameResultTests(Day2.MoveType theirMove, Day2.MoveType ourMove, Day2.GameResult expectedResult) =>
        Day2.CalculateGameResult(ourMove, theirMove).Should().Be(expectedResult);

    [Theory]
    [InlineData(Day2.MoveType.Rock, Day2.GameResult.Draw, Day2.MoveType.Rock)]
    [InlineData(Day2.MoveType.Rock, Day2.GameResult.Win, Day2.MoveType.Paper)]
    [InlineData(Day2.MoveType.Rock, Day2.GameResult.Lose, Day2.MoveType.Scissors)]
    [InlineData(Day2.MoveType.Paper, Day2.GameResult.Lose, Day2.MoveType.Rock)]
    [InlineData(Day2.MoveType.Paper, Day2.GameResult.Draw, Day2.MoveType.Paper)]
    [InlineData(Day2.MoveType.Paper, Day2.GameResult.Win, Day2.MoveType.Scissors)]
    [InlineData(Day2.MoveType.Scissors, Day2.GameResult.Win, Day2.MoveType.Rock)]
    [InlineData(Day2.MoveType.Scissors, Day2.GameResult.Lose, Day2.MoveType.Paper)]
    [InlineData(Day2.MoveType.Scissors, Day2.GameResult.Draw, Day2.MoveType.Scissors)]
    public void DeriveOurMoveFromOpponentMoveAndGameResultTests(Day2.MoveType theirMove, Day2.GameResult gameResult, Day2.MoveType expectedOurMove) =>
        Day2.DeriveOurMoveFromOpponentMoveAndGameResult(theirMove, gameResult).Should().Be(expectedOurMove);

    [Theory]
    [InlineData(Day2.MoveType.Rock, Day2.MoveType.Rock, 4)]
    [InlineData(Day2.MoveType.Rock, Day2.MoveType.Paper, 8)]
    [InlineData(Day2.MoveType.Rock, Day2.MoveType.Scissors, 3)]
    [InlineData(Day2.MoveType.Paper, Day2.MoveType.Rock, 1)]
    [InlineData(Day2.MoveType.Paper, Day2.MoveType.Paper, 5)]
    [InlineData(Day2.MoveType.Paper, Day2.MoveType.Scissors, 9)]
    [InlineData(Day2.MoveType.Scissors, Day2.MoveType.Rock, 7)]
    [InlineData(Day2.MoveType.Scissors, Day2.MoveType.Paper, 2)]
    [InlineData(Day2.MoveType.Scissors, Day2.MoveType.Scissors, 6)]
    public void CalculateGameScoreTests(Day2.MoveType theirMove, Day2.MoveType ourMove, int expectedScore) =>
        Day2.CalculateGameScore(ourMove, theirMove).Should().Be(expectedScore);
}