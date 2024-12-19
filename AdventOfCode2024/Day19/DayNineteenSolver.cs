using System.Numerics;
using AdventOfCode2024.Day12;

namespace AdventOfCode2024.Day19;

public class DayNineteenSolver : ISolver
{
    private List<string> _towelPatterns { get; set; }
    private Dictionary<string, BigInteger> _seen = new();
    public string PartOne(string[] input)
    {
        _towelPatterns = input[0].Split(",").Select(towel => towel.Trim()).ToList();

        int count = 0;
        for (var i = 2; i < input.Length; i++)
        {
            var pattern = input[i];

            if (IsTowelPossible(pattern))
            {
                count++;
            }

        }

        return count.ToString();
    }

    public bool IsTowelPossible(string towel)
    {
        if (towel == "")
        {
            return true;
        }

        var towelLengths = new List<int>();
        for (var i = 1; i < towel.Length + 1; i++)
        {
            if (_towelPatterns.Any(t => t == towel.Substring(0, i)))
            {
                towelLengths.Add(i);
            }
        }

        if (!towelLengths.Any())
        {
            return false;
        }

        return towelLengths.Any(tl => IsTowelPossible(towel.Substring(tl)));
    }

    public string PartTwo(string[] input)
    {
        _towelPatterns = input[0].Split(",").Select(towel => towel.Trim()).ToList();

        BigInteger count = 0;
        for (var i = 2; i < input.Length; i++)
        {
            Console.WriteLine($"{i}/{input.Length}");
            var pattern = input[i];
            count += TowelPossibilities(pattern);
        }

        return count.ToString();
    }
    
    public BigInteger TowelPossibilities(string towel)
    {
        if (towel == "")
        {
            return 1;
        }

        if (_seen.ContainsKey(towel))
        {
            return _seen[towel];
        }

        BigInteger total = 0;
        for (var i = 1; i < towel.Length + 1; i++)
        {
            if (_towelPatterns.Any(t => t == towel.Substring(0, i)))
            {
                total += TowelPossibilities(towel[i..]);
            }
        }

        _seen[towel] = total;
        return total;
    }
}