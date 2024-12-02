namespace AdventOfCode2024;

public static class ParseExtensions
{
    public static int[] SplitToInt(this string input) => input.Split(" ").Select(int.Parse).ToArray();
}