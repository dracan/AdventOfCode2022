namespace AdventOfCode2022.Day1;

public static class Day1
{
    public static int GetElfWithHighestCalorieCount() =>
        CalorieLoader.LoadCalories().Max(x => x);
}