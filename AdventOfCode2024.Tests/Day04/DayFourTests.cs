using AdventOfCode2024.Day04;
using FluentAssertions;

namespace AdventOfCode2024.Tests.Day02;

public class DayFourTests
{
    private readonly DayFourSolver _dayFourSolver = new();

    private string[] _input;

    [SetUp]
    public void SetUp()
    {
        _input =
        [
            "MMMSXXMASM",
            "MSAMXMSMSA",
            "AMXSXMAAMM",
            "MSAMASMSMX",
            "XMASAMXAMM",
            "XXAMMXXAMA",
            "SMSMSASXSS",
            "SAXAMASAAA",
            "MAMMMXMMMM",
            "MXMXAXMASX",
        ];
    }

    [Test]
    public void Should_Solve_Part_One()
    {
        var result = _dayFourSolver.PartOne(_input);
        result.Should().Be("18");
    }

    [Test]
    public void Should_Solve_Part_Two()
    {
        var result = _dayFourSolver.PartTwo(_input);
        result.Should().Be("9");
    }
}