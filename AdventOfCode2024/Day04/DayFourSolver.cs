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
        // M.S
        // .A.
        // M.S
        
        // S.S
        // .A.
        // M.M
        
        // M.M 
        // .A.
        // S.S
        
        // S.M
        // .A.
        // S.M
            var count = 0;
            for (var i = 0; i < reports.Length; i++)
            {
                for (var j = 0; j < reports[i].Length; j++)
                {
                    if (i + 2 < reports.Length && j + 2 < reports[i].Length && reports[i][j] == 'M' && reports[i + 2][j] == 'S' && reports[i + 1][j + 1] == 'A' &&
                        reports[i][j + 2] == 'M' && reports[i + 2][j + 2] == 'S')
                    {
                        count++;
                    }
                    
                    if (i + 2 < reports.Length  && j + 2 < reports[i].Length && reports[i][j] == 'S' && reports[i + 2][j] == 'S' && reports[i + 1][j + 1] == 'A' &&
                        reports[i][j + 2] == 'M' && reports[i + 2][j + 2] == 'M')
                    {
                        count++;
                    } 
                    
                    if (i + 2 < reports.Length && j + 2 < reports[i].Length && reports[i][j] == 'M' && reports[i + 2][j] == 'M' && reports[i + 1][j + 1] == 'A' &&
                        reports[i][j + 2] == 'S' && reports[i + 2][j + 2] == 'S')
                    {
                        count++;
                    }
                    
                    if (i + 2 < reports.Length && j + 2 < reports[i].Length && reports[i][j] == 'S' && reports[i + 2][j] == 'M' && reports[i + 1][j + 1] == 'A' &&
                        reports[i][j + 2] == 'S' && reports[i + 2][j + 2] == 'M')
                    {
                        count++;
                    }
                 
                }
            }
    
            return count.ToString();}
}