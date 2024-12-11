using System.Numerics;
using System.Runtime.Serialization;

namespace AdventOfCode2024.Day11;

public class DayElevenSolver : ISolver
{
    private readonly int _blinks;
    private readonly Dictionary<(string, int), int> _seen = new();

    public DayElevenSolver(int blinks)
    {
        _blinks = blinks;
    }

    public string PartOne(string[] lines)
    {
        var line = lines[0].Split(" ").ToList();
        var total = 0;
        foreach (var stone in line)
        {
            total += Solve(stone, _blinks);
        }

        return total.ToString();
    }

    public string PartTwo(string[] lines)
    {
        return PartOne(lines);

        // 1719712269 too low
    }

    private int Solve(string stone, int blinks)
    {
        int res;
        if (_seen.TryGetValue((stone, blinks), out var cachedResult))
        {
            return cachedResult;
        }

        if (blinks == 0)
        {
            res = 1;
        }
        else if (stone == "0")
        {
            res = Solve("1", blinks - 1);
        }
        else if (stone.Length % 2 == 0)
        {
            var leftStone = stone.Substring(0, stone.Length / 2);
            var rightStone = stone.Substring(stone.Length / 2, stone.Length / 2);
            res = Solve(leftStone, blinks - 1) + Solve(BigInteger.Parse(rightStone).ToString(), blinks - 1);
        }
        else
        {
            if (!BigInteger.TryParse(stone, out var bigStone))
            {
                throw new ArgumentException("Invalid stone value: " + stone);
            }

            res = Solve((bigStone * 2024).ToString(), blinks - 1);
        }

        _seen[(stone, blinks)] = res;

        return res;
    }
}