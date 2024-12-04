namespace AdventOfCode2024.Day04;

public class DayFourSolver : ISolver
{
    public string PartOne(string[] reports)
    {
        var letters = new Dictionary<int, char>()
        {
            { 0, 'X' },
            { 1, 'M' },
            { 2, 'A' },
            { 3, 'S' }
        };

        var count = 0;
        var graph = new List<(int, int)>()
        {
            (0, 1),
            (0, -1),
            (1, 0),
            (-1, 0),
            (1, 1),
            (-1, -1),
            (1, -1),
            (-1, 1)
        };
        for (var i = 0; i < reports.Length; i++)
        {
            for (var j = 0; j < reports[i].Length; j++)
            {
                foreach (var (x, y) in graph)
                {
                    var isMatch = true;
                    for (var letterIndex = 0; letterIndex < 4; letterIndex++)
                    {
                        var xIndex = i + x * letterIndex;
                        var yIndex = j + y * letterIndex;

                        if (xIndex < 0 || xIndex >= reports.Length || yIndex < 0 || yIndex >= reports[xIndex].Length  || reports[xIndex][yIndex] != letters[letterIndex])
                        {
                            isMatch = false;
                            break;
                        }
                    }

                    if (isMatch) count++;
                }
            }
        }

        return count.ToString();
    }

    public string PartTwo(string[] reports)
    {
        throw new NotImplementedException();
    }
}