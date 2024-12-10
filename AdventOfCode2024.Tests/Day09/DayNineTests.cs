using AdventOfCode2024.Day09;
using FluentAssertions;

namespace AdventOfCode2024.Tests.Day09;

public class DayNineTests
{
    private readonly DayNineSolver _dayNineSolver = new();

    private string[] _input;

    [SetUp]
    public void SetUp()
    {
        _input =
        [
            "2333133121414131402"
        ];
    }

    [Test]
    public void Should_Solve_Part_One()
    {
        var result = _dayNineSolver.PartOne(_input);
        result.Should().Be("1928");
    }

    [Test]
    public void Should_Solve_Part_Two()
    {
        var result = _dayNineSolver.PartTwo(_input);
        result.Should().Be("2858");
    }
}