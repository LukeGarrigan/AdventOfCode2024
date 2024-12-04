namespace AdventOfCode2024.Day01;

public class DayTwoSolver : ISolver
{
    public string PartOne(string[] reports)
    {
        var safe = 0;
        foreach (var report in reports)
        {
            var levels = report.SplitToInt();
            if (IsReportSafe(levels.ToList()))
            {
                safe++;
            }
        }

        return safe.ToString();
    }

    public string PartTwo(string[] reports)
    {
        var safe = 0;
        foreach (var report in reports)
        {
            var levels = report.SplitToInt();

            if (IsReportSafe(levels) || IsSafeWithDampener(levels))
            {
                safe++;
            }
        }

        return safe.ToString();
    }

    private static bool IsSafeWithDampener(List<int> levels)
    {
        for (var i = 0; i < levels.Count; i++)
        {
            var slicedLevel = levels.Where((_, index) => index != i).ToList();
            if (IsReportSafe(slicedLevel))
            {
                return true;
            }
        }

        return false;
    }

    private static bool IsReportSafe(List<int> levels)
    {
        if (levels[1] == levels[0]) return false;
        var ascending = levels[1] > levels[0];

        var isValid = true;
        for (var i = 1; i < levels.Count; i++)
        {
            if (!IsCorrectlyAscending(ascending, levels, i) &&
                !IsCorrectlyDescending(ascending, levels, i))
            {
                return false;
            }
        }

        return true;
    }

    private static bool IsCorrectlyDescending(bool ascending, List<int> levels, int i)
    {
        return !ascending && levels[i] < levels[i - 1] && levels[i] >= levels[i - 1] - 3;
    }

    private static bool IsCorrectlyAscending(bool ascending, List<int> levels, int i)
    {
        return ascending && levels[i] > levels[i - 1] && levels[i] <= levels[i - 1] + 3;
    }
}