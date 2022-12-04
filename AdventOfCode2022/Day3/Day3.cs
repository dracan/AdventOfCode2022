using System.Diagnostics;

namespace AdventOfCode2022.Day3;

public static class Day3
{
    public record Rucksack(Compartment LeftCompartment, Compartment RightCompartment);
    public record Compartment(char[] Items);
    private record ElfGroup(char BadgeChar);

    public static int Part1_CalculateTotalPriorityValueOfDuplicateItemsAcrossRucksacksCompartments() =>
        File.ReadLines(@"Day3\puzzle-input-day3.txt")
            .Where(x => !string.IsNullOrWhiteSpace(x))
            .Select(ParseLineToCreateRucksack)
            .Select(GetItemsThatExistInBothCompartments)
            .Select(ConvertItemArrayToPriorityValue)
            .Sum(x => x);

    public static int Part2_CalculateTotalElfGroupBadgePriories() =>
        File.ReadLines(@"Day3\puzzle-input-day3.txt")
            .Where(x => !string.IsNullOrWhiteSpace(x))
            .Select((line, index) => new { line, index })
            .GroupBy(x => x.index / 3, x => x.line)
            .Select(ToElfGroup)
            .Select(x => ConvertItemArrayToPriorityValue(new[] { x.BadgeChar }))
            .Sum(x => x);

    private static ElfGroup ToElfGroup(IGrouping<int, string> grouping)
    {
        Debug.Assert(grouping.Count() == 3);
        var elfItems = grouping.ToArray();
        var badgeChar = FindGroupBadge(elfItems[0], elfItems[1], elfItems[2]);
        return new ElfGroup(badgeChar);
    }

    public static char FindGroupBadge(string elf1Items, string elf2Items, string elf3Items) =>
        // Distinct removes all duplicates items held by the same elf
        elf1Items.ToCharArray().Distinct()
            .Concat(elf2Items.ToCharArray().Distinct())
            .Concat(elf3Items.Distinct())
            // Reorder so same items are together, then group so we can count (3 together will be the badge)
            .OrderBy(x => x)
            .GroupBy(x => x)
            // Only the badge will have three in the group
            .Where(x => x.Count() == 3)
            .Select(x => x.ToArray()[0])
            .Single();

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