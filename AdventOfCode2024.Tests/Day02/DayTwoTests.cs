using AdventOfCode2024.Day01;
using FluentAssertions;

namespace AdventOfCode2024.Tests.Day02;

public class DayTwoTests
{
    private DayTwoSolver _dayTwoSolver = new();

    private string[] _input;

    [SetUp]
    public void SetUp()
    {
        _input =
        [
            "7 6 4 2 1",
            "1 2 7 8 9",
            "9 7 6 2 1",
            "1 3 2 4 5",
            "8 6 4 4 1",
            "1 3 6 7 9",
        ];
    }

    [Test]
    public void Should_Solve_Part_One()
    {
        var result = _dayTwoSolver.PartOne(_input);
        result.Should().Be("2");
    }

    [Test]
    public void Should_Solve_Part_Two()
    {
        var result = _dayTwoSolver.PartTwo(_input);
        result.Should().Be("31");
    }
}