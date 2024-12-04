using System.Text.RegularExpressions;

namespace AdventOfCode2024.Day01;

public class DayThreeSolver : ISolver
{
    public string PartOne(string[] reports)
    {
        var regex = new Regex(@"mul\((\d+),(\d+)\)");

        var sum = 0;
        foreach (var report in reports)
        {
            var matches = regex.Matches(report);
            foreach (Match match in matches)
            {
                sum += int.Parse(match.Groups[1].Value) * int.Parse(match.Groups[2].Value);
            }
        }

        return sum.ToString();
    }

    public string PartTwo(string[] reports)
    {
        var regex = new Regex(@"don't\(\)|do\(\)|mul\((\d+),(\d+)\)");
        var sum = 0;
        var doMultiplication = true;
        foreach (var report in reports)
        {
            var matches = regex.Matches(report);
            foreach (Match match in matches)
            {
                if (match.Groups[0].Value == "don't()")
                {
                    doMultiplication = false;
                }
                else if (match.Groups[0].Value == "do()")
                {
                    doMultiplication = true;
                }
                else if (doMultiplication)
                {
                    sum += int.Parse(match.Groups[1].Value) * int.Parse(match.Groups[2].Value);
                }
            }
        }

        return sum.ToString();
    }
}