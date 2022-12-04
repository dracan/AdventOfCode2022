using System.Diagnostics;

namespace AdventOfCode2022.Day3;

public static class Day3
{
    public record Rucksack(Compartment LeftCompartment, Compartment RightCompartment);
    public record Compartment(char[] Items);

    public static int CalculateTotalPriorityValueOfDuplicateItemsAcrossRucksacksCompartments() =>
        File.ReadLines(@"Day3\puzzle-input-day3.txt")
            .Where(x => !string.IsNullOrWhiteSpace(x))
            .Select(ParseLineToCreateRucksack)
            .Select(GetItemsThatExistInBothCompartments)
            .Select(ConvertItemArrayToPriorityValue)
            .Sum(x => x);

    public static Rucksack ParseLineToCreateRucksack(string line)
    {
        if (line.Length % 2 != 0)
            throw new ArgumentException($"Unexpected odd line length for line: '{line}'");

        var compartmentLength = line.Length / 2;

        return new Rucksack(
            new Compartment(line[..compartmentLength].ToCharArray()),
            new Compartment(line[compartmentLength..].ToCharArray())
        );
    }

    public static char[] GetItemsThatExistInBothCompartments(Rucksack rucksack)
    {
        Debug.Assert(rucksack.LeftCompartment.Items.Length == rucksack.RightCompartment.Items.Length);

        // This is pretty brute force, and not the most efficient! But nothing in the requirement suggests
        // that it's going to be run in a tight loop - so let's keep things simple and readable!

        return
            (from leftItem in rucksack.LeftCompartment.Items
             from rightItem in rucksack.RightCompartment.Items
             where leftItem == rightItem select leftItem).Distinct().ToArray();
    }

    public static int ConvertItemArrayToPriorityValue(char[] itemArray)
    {
        int ToPriorityValue(char item) =>
            char.IsUpper(item)
                ? item - 38
                : item - 96;

        return itemArray.Select(ToPriorityValue).Sum();
    }
}