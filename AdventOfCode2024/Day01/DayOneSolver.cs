namespace AdventOfCode2024.Day01;

public class DayOneSolver : ISolver
{
    public string PartOne(string[] input)
    {
        var listOne = input.Select(line => int.Parse(line.Split(" ")[0])).OrderBy(x => x);
        var listTwo = input.Select(line => int.Parse(line.Split(" ")[^1])).OrderBy(x => x);
        return listOne.Zip(listTwo, (x, y) => Math.Abs(x - y)).Sum().ToString();
    }

    public string PartTwo(string[] input)
    {
        var listOne = input.Select(line => int.Parse(line.Split(" ")[0]));
        var listTwo = input.Select(line => int.Parse(line.Split(" ")[^1])).ToList();
        var occurenceDictionary = listTwo.GroupBy(n => n).ToDictionary(g => g.Key, g => g.Count());
        return listOne.Select(n => occurenceDictionary.TryGetValue(n, out var value) ? n * value : 0).Sum().ToString();
    }
}