using System.Runtime.InteropServices.Marshalling;

namespace AdventOfCode2024.Day25;

public class DayTwentyFiveSolver : ISolver
{
    public string PartOne(string[] input)
    {
        var keys = new List<string>();
        var locks = new List<string>();

        var count = 0;
        var isLock = input[0] == "#####";
        var current = "";
        for (var i = 0; i < input.Length; i++)
        {
            if (input[i] == "")
            {
                if (isLock)
                {
                    locks.Add(current);
                }
                else
                {
                    keys.Add(current);
                }

                count++;
                isLock = input[i + 1] == "#####";
                current = "";
                continue;
            }

            current += input[i];
        }

        if (isLock)
        {
            locks.Add(current);
        }
        else
        {
            keys.Add(current);
        }

        var pairs = 0;

        foreach (var currentLock in locks)
        {
            foreach (var key in keys)
            {
                var isMatch = true;
                for (var i = 0; i < currentLock.Length; i++)
                {
                    if (currentLock[i] == '#' &&  key[i] == '#')
                    {
                        isMatch = false;
                    }
                }

                if (isMatch) pairs++;
            }
        }

        return pairs.ToString();
    }

    public string PartTwo(string[] input)
    {
        throw new NotImplementedException();
    }
}