using AdventOfCode2024.Day06;
using FluentAssertions;

namespace AdventOfCode2024.Tests.Day06;

public class DaySixTests
{
    private DaySixSolver _daySixSolver = new();

    private string[] _input;

    [SetUp]
    public void SetUp()
    {
        _input =
        [
            "....#.....",
            ".........#",
            "..........",
            "..#.......",
            ".......#..",
            "..........",
            ".#..^.....",
            "........#.",
            "#.........",
            "......#..."
        ];
    }

    [Test]
    public void Should_Solve_Part_One()
    {
        var result = _daySixSolver.PartOne(_input);
        result.Should().Be("41");
    }

    [Test]
    public void Should_Solve_Part_Two()
    {
        var result = _daySixSolver.PartTwo(_input);
        result.Should().Be("123");
    }
}