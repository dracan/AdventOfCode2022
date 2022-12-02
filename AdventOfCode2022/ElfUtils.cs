namespace AdventOfCode2022;

public static class ElfUtils
{
    public static int GetElfWithHighestCalorieCount() =>
        CalorieLoader.LoadCalories().Max(x => x);
}