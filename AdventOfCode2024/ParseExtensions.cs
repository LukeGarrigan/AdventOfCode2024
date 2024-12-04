namespace AdventOfCode2024;

public static class ParseExtensions
{
    public static List<int> SplitToInt(this string input) => input.Split(" ").Select(int.Parse).ToList();
}