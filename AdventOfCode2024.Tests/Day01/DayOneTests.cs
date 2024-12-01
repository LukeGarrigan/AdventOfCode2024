using AdventOfCode2024.Day01;
using FluentAssertions;

namespace AdventOfCode2024.Tests.Day01;

public class DayOneTests
{
    private DayOneSolver _dayOneSolver = new();

    private string[] _input;
    
    [SetUp]
    public void SetUp()
    {
        _input =
        [
            "3   4",
            "4   3",
            "2   5",
            "1   3",
            "3   9",
            "3   3"
        ];
    }

    [Test]
    public void Should_Solve_Part_One()
    {
        var result = _dayOneSolver.PartOne(_input);
        result.Should().Be("11");
    }
    
    [Test]
    public void Should_Solve_Part_Two()
    {
        var result = _dayOneSolver.PartTwo(_input);
        result.Should().Be("31");
    }
}
