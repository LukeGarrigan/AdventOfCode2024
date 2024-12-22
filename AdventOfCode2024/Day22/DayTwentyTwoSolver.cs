using System.Numerics;

namespace AdventOfCode2024.Day22;

public class DayTwentyTwoSolver : ISolver
{
    public string PartOne(string[] input)
    {
        var steps = 2000;
        
        BigInteger total = 0;
        foreach (var secret in input)
        {
            var s = BigInteger.Parse(secret);
            for (var i = 0; i < steps; i++)
            {
                var result = s * 64;
                s = result ^ s;
                s = s % 16777216;
                
                result = s / 32;
                s = result ^ s;
                s = s % 16777216;
                

                result = s * 2048;
                s = result ^ s;
                s = s % 16777216;
            }
            total += s;
        }

        return total.ToString();
    }

    public string PartTwo(string[] input)
    {
        throw new NotImplementedException();
    }
}