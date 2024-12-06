using System.Threading.Channels;

namespace AdventOfCode2024.Day05;

public class DayFiveSolver : ISolver
{
    public string PartOne(string[] lines)
    {
        var reports = lines.Where(line => line.Contains("|"));
        var updates = lines.Where(line => line.Contains(","));
        var output = 0;
        foreach (var update in updates)
        {
            var pages = update.Split(",");

            var valid = true;
            for (var index = 0; index < pages.Length; index++)
            {
                var page = pages[index];
                var mustBeAfter = reports.Where(r => r.StartsWith(page)).Select(r => r.Split("|")[1]);
                var mustBefore = reports.Where(r => r.EndsWith(page)).Select(r => r.Split("|")[0]);

                var updatesAfter = pages.Skip(index + 1);
                if (index != 0)
                {
                    foreach (var before in mustBefore)
                    {
                        if (updatesAfter.Contains(before))
                        {
                            valid = false;
                        }
                    }
                }

                var updatesBefore = pages.Take(index);
                if (index != pages.Length - 1)
                {
                    foreach (var after in mustBeAfter)
                    {
                        if (updatesBefore.Contains(after))
                        {
                            valid = false;
                        }
                    }
                }
            }

            if (valid)
            {
                output += int.Parse(pages.ElementAt(pages.Count() / 2));
            }
        }

        return output.ToString();
    }

    public string PartTwo(string[] lines)
    {
        var reports = lines.Where(line => line.Contains("|"));
        var updates = lines.Where(line => line.Contains(","));
        var output = 0;
        foreach (var update in updates)
        {
            var pages = update.Split(",");

            var valid = true;
            var changes = false;
            do
            {
                var madeAChange = false;
                for (var index = 0; index < pages.Length; index++)
                {
                    var page = pages[index];
                    var mustBefore = reports.Where(r => r.EndsWith(page)).Select(r => r.Split("|")[0]);

                    var futureUpdates = pages.Skip(index + 1).ToList();
                    if (index != 0)
                    {
                        foreach (var before in mustBefore)
                        {
                            var shouldBeBeforeIndex = futureUpdates.IndexOf(before);
                            if (shouldBeBeforeIndex != -1)
                            {
                                valid = false;
                                shouldBeBeforeIndex = index + 1;
                                (pages[shouldBeBeforeIndex], pages[index]) = (pages[index], pages[shouldBeBeforeIndex]);
                                madeAChange = true;
                            }
                        }
                    }


                    var mustBeAfter = reports.Where(r => r.StartsWith(page)).Select(r => r.Split("|")[1]);
                    var seenUpdates = pages.Take(index).ToList();
                    if (index != pages.Length - 1)
                    {
                        foreach (var after in mustBeAfter)
                        {
                            var shouldBeAfterIndex = seenUpdates.IndexOf(after);
                            if (shouldBeAfterIndex != -1)
                            {
                                valid = false;
                                (pages[shouldBeAfterIndex], pages[index]) = (pages[index], pages[shouldBeAfterIndex]);
                                madeAChange = true;
                            }
                        }
                    }
                }

                changes = madeAChange;
            } while (changes);


            if (!valid)
            {
                output += int.Parse(pages.ElementAt(pages.Count() / 2));
            }
        }

        return output.ToString();
    }
}