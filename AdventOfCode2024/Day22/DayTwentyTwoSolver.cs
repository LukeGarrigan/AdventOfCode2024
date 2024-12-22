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
        var steps = 2000;

        BigInteger total = 0;
        HashSet<(int, int, int, int)> marketChanges = [];
        var pricesBySecret = new List<List<int>>();
        foreach (var secret in input)
        {
            var s = ComputePrices(secret, steps);
            pricesBySecret.Add(s);

            for (var i = 1; i < s.Count - 3; i++)
            {
                var d1 = s[i] - s[i - 1];
                var d2 = s[i + 1] - s[i];
                var d3 = s[i + 2] - s[i + 1];
                var d4 = s[i + 3] - s[i + 2];
                marketChanges.Add((d1, d2, d3, d4));
            }
        }

        var biggest = 0;
        Console.WriteLine($"Market changes {marketChanges.Count}");
        var count = 0;
        foreach (var pattern in marketChanges)
        {
            count++;
            if (count % 50 == 0)
            {
                Console.WriteLine(count);
            }

            var patternTotal = 0;
            foreach (var s in pricesBySecret)
            {
                for (var i = 1; i < s.Count - 3; i++)
                {
                    var d1 = s[i] - s[i - 1];
                    var d2 = s[i + 1] - s[i];
                    var d3 = s[i + 2] - s[i + 1];
                    var d4 = s[i + 3] - s[i + 2];

                    if (d1 == pattern.Item1 && d2 == pattern.Item2 && d3 == pattern.Item3 && d4 == pattern.Item4)
                    {
                        patternTotal += s[i + 3];
                        break;
                    }
                }
            }

            if (patternTotal > biggest)
            {
                biggest = patternTotal;
            }
        }

        return biggest.ToString();
    }

    private static List<int> ComputePrices(string secret, int steps)
    {
        var prices = new List<int>();
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

            prices.Add((int)s % 10);
        }

        return prices;
    }
}