using FluentAssertions;

namespace AdventOfCode2022.Tests;

public class ElfCalorieCountTests
{
    [Fact]
    public void GivenDay1sPuzzleInput_ResultShouldMatchHighestElfsCalorieCount() =>
        ElfUtils.GetElfWithHighestCalorieCount().Should().Be(71471);
}