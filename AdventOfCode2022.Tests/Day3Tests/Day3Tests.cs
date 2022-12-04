using FluentAssertions;
namespace AdventOfCode2022.Tests.Day3Tests;
using Day3;

public class Day3Tests
{
    [Fact]
    public void CalculateTotalPriorityValueOfDuplicateItemsAcrossRucksacksCompartmentsTest() =>
        Day3.CalculateTotalPriorityValueOfDuplicateItemsAcrossRucksacksCompartments().Should().Be(8139);

    [Theory]
    [InlineData("kdsfs32423skjx", "kdsfs32", "423skjx")]
    [InlineData("ab", "a", "b")]
    public void ParseLineToCreateRucksackTests(string inputLine, string expectedCompartment1, string expectedCompartment2) =>
        Day3.ParseLineToCreateRucksack(inputLine).Should().BeEquivalentTo(
            new Day3.Rucksack(
                new Day3.Compartment(expectedCompartment1.ToCharArray()),
                new Day3.Compartment(expectedCompartment2.ToCharArray())));

    [Fact]
    public void SplitIntoTwoCompartmentsTests_WhenOddNumber_ShouldThrowException()
    {
        Action act = () => Day3.ParseLineToCreateRucksack("abc");
        act.Should().Throw<ArgumentException>()
            .WithMessage("Unexpected odd line length for line: 'abc'");
    }

    [Theory]
    [InlineData("abc", "def", "")]
    [InlineData("abc", "dbf", "b")]
    [InlineData("a", "A", "")]
    [InlineData("ab", "Ab", "b")]
    public void GetItemsThatExistInBothCompartmentsTests(string leftCompartment, string rightCompartment, string expectedDuplicateItems) =>
        Day3.GetItemsThatExistInBothCompartments(new Day3.Rucksack(
                new Day3.Compartment(leftCompartment.ToCharArray()),
                new Day3.Compartment(rightCompartment.ToCharArray())))
            .Should().BeEquivalentTo(expectedDuplicateItems);

    [Theory]
    [InlineData("pLPvts", 157)] // Example provided in requirement
    public void ConvertItemArrayToPriorityValueTests(string itemArray, int expectedSummedPriorityValue) =>
        Day3.ConvertItemArrayToPriorityValue(itemArray.ToCharArray()).Should().Be(expectedSummedPriorityValue);
}
