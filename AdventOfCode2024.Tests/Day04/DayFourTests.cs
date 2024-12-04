using AdventOfCode2024.Day01;
using AdventOfCode2024.Day04;
using FluentAssertions;

namespace AdventOfCode2024.Tests.Day02;

public class DayFourTests
{
    private DayFourSolver _dayFourSolver = new();

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
        _input = ["xmul(2,4)&mul[3,7]!^don't()_mul(5,5)+mul(32,64](mul(11,8)undo()?mul(8,5))"];
        var result = _dayFourSolver.PartTwo(_input);
        result.Should().Be("48");
    }
}