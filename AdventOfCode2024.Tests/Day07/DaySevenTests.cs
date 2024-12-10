using AdventOfCode2024.Day07;
using FluentAssertions;

namespace AdventOfCode2024.Tests.Day07;

public class DaySevenTests
{
    private readonly DaySevenSolver _daySevenSolver = new();

    private string[] _input;

    [SetUp]
    public void SetUp()
    {
        _input =
        [
            "190: 10 19",
            "3267: 81 40 27",
            "83: 17 5",
            "156: 15 6",
            "7290: 6 8 6 15",
            "161011: 16 10 13",
            "192: 17 8 14",
            "21037: 9 7 18 13",
            "292: 11 6 16 20"
        ];
    }

    [Test]
    public void Should_Solve_Part_One()
    {
        var result = _daySevenSolver.PartOne(_input);
        result.Should().Be("3749");
    }

    [Test]
    public void Should_Solve_Part_Two()
    {
        var result = _daySevenSolver.PartTwo(_input);
        result.Should().Be("11387");
    }
}