namespace AdventOfCode2022;

public static class CalorieLoader
{
    private const string ElfCaloriesInputFile = "puzzle-input-day1.txt";

    public static IEnumerable<int> LoadCalories()
    {
        var caloriesCounts = new List<int>();

        var lines = File.ReadAllLines(ElfCaloriesInputFile);

        var thisCount = 0;

        foreach (var line in lines)
        {
            if (string.IsNullOrWhiteSpace(line))
            {
                caloriesCounts.Add(thisCount);
                thisCount = 0;
            }
            else
            {
                if (!int.TryParse(line, out var calorieCount))
                    throw new InvalidDataException("Input data has a non-empty line that isn't numeric");

                thisCount += calorieCount;
            }
        }

        return caloriesCounts;
    }
}