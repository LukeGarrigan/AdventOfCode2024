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
        var incrementingOrDecrementing = levels.SequenceEqual(levels.OrderByDescending(x => x)) ||
                                         levels.SequenceEqual(levels.OrderBy(x => x).ToList());

        if (!incrementingOrDecrementing) return false;
        for (var i = 1; i < levels.Count; i++)
        {

            var difference = Math.Abs(levels[i] - levels[i - 1]);
            if (difference is 0 or > 3)
            {
                return false;
            }
        }

        return true;
    }
}