namespace AdventOfCode2024.Day01;

public class DayTwoSolver : ISolver
{
    public string PartOne(string[] reports)
    {

        var safe = 0;
        foreach (var report in reports)
        {
            var levels = report.SplitToInt();
            if (levels[1] == levels[0]) continue;
            var ascending = levels[1] > levels[0];

            var isValid = true;
            for (var i = 1; i < levels.Length; i++)
            {

                if (!IsCorrectlyAscending(ascending, levels, i) && 
                    !IsCorrectlyDescending(ascending, levels, i))
                {
                    isValid = false;
                    break;
                } 

            }

            if (isValid)
            {
                safe++;
            }

        }
        return safe.ToString();
    }

    private static bool IsCorrectlyDescending(bool ascending, int[] levels, int i)
    {
        return !ascending && levels[i] < levels[i - 1] && levels[i] >= levels[i - 1] - 3;
    }

    private static bool IsCorrectlyAscending(bool ascending, int[] levels, int i)
    {
        return ascending && levels[i] > levels[i - 1] && levels[i] <= levels[i - 1] + 3;
    }

    public string PartTwo(string[] input)
    {
        throw new NotImplementedException();
    }
}