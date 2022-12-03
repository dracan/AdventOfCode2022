using FluentAssertions;

namespace AdventOfCode2022.Tests.Day1Tests;

using Day1 = Day1.Day1;

public class Day1Tests
{
    [Fact]
    public void GivenDay1sPuzzleInput_ResultShouldMatchHighestElfsCalorieCount() =>
        Day1.GetElfWithHighestCalorieCount().Should().Be(71471);
}