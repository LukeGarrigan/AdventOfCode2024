using System.Numerics;
using System.Reflection.Metadata.Ecma335;

namespace AdventOfCode2024.Day09;

public class DayNineSolver : ISolver
{
    private bool _isPartOne;

    public DayNineSolver()
    {
        _isPartOne = true;
    }

    public string PartOne(string[] lines)
    {
        var outList = GetMemoryList(lines);

        var leftIndex = 0;
        var rightIndex = outList.Count - 1;

        while (leftIndex < rightIndex)
        {
            if (outList[leftIndex] != ".")
            {
                leftIndex++;
            }
            else if (outList[rightIndex] == ".")
            {
                rightIndex--;
            }
            else
            {
                (outList[leftIndex], outList[rightIndex]) = (outList[rightIndex], outList[leftIndex]);
            }
        }


        BigInteger checkSum = 0;
        for (var i = 0; i < outList.Count(); i++)
        {
            if (outList[i] != ".")
            {
                checkSum += i * BigInteger.Parse(outList[i]);
            }
        }

        return checkSum.ToString();
    }


    public string PartTwo(string[] lines)
    {
        var outList = GetMemoryList(lines);

        var rightIndex = outList.Count - 1;

        while (rightIndex >= 0)
        {
            var currentFile = outList[rightIndex];
            while (currentFile == ".")
            {
                rightIndex--;
                currentFile = outList[rightIndex];
            }

            var fileStartIndex = outList.IndexOf(currentFile);
            var blockSize = (rightIndex - fileStartIndex) + 1;


            var emptyBlockSize = 0;
            var index = 0;
            var emptyBlockStart = 0;
            while (emptyBlockSize < blockSize && index < outList.Count)
            {
                if (outList[index] == ".")
                {
                    if (emptyBlockSize == 0)
                    {
                        emptyBlockStart = index;
                    }

                    emptyBlockSize++;
                }
                else
                {
                    emptyBlockSize = 0;
                }

                index++;
            }

            if (index < fileStartIndex)
            {
                for (var i = 0; i < blockSize; i++)
                {
                    (outList[emptyBlockStart + i], outList[fileStartIndex + i]) = (outList[fileStartIndex + i], outList[emptyBlockStart + i]);
                }
            }

            rightIndex = fileStartIndex - 1;
        }


        BigInteger checkSum = 0;
        for (var i = 0; i < outList.Count; i++)
        {
            if (outList[i] != ".")
            {
                checkSum += i * BigInteger.Parse(outList[i]);
            }
        }

        return checkSum.ToString();
    }
    // 6307653502443 too high

    private static List<string> GetMemoryList(string[] lines)
    {
        var line = lines[0].ToList();
        var outList = new List<string>();
        var index = 0;
        for (var i = 0; i < line.Count; i++)
        {
            var current = Convert.ToInt32(line[i].ToString());
            var isFree = i % 2 == 1;

            for (var j = 0; j < current; j++)
            {
                outList.Add(isFree ? "." : index.ToString());
            }

            if (isFree)
            {
                index++;
            }
        }

        return outList;
    }
}