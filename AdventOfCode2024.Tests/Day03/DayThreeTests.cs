using AdventOfCode2024.Day01;
using FluentAssertions;

namespace AdventOfCode2024.Tests.Day02;

public class DayThreeTests
{
    private DayThreeSolver _dayThreeSolver = new();

    private string[] _input;

    [SetUp]
    public void SetUp()
    {
        _input =
        [
            "xmul(2,4)%&mul[3,7]!@^do_not_mul(5,5)+mul(32,64]then(mul(11,8)mul(8,5))",
        ];
    }

    [Test]
    public void Should_Solve_Part_One()
    {
        var result = _dayThreeSolver.PartOne(_input);
        result.Should().Be("161");
    }

    [Test]
    public void Should_Solve_Part_Two()
    {
        _input = ["xmul(2,4)&mul[3,7]!^don't()_mul(5,5)+mul(32,64](mul(11,8)undo()?mul(8,5))"];
        var result = _dayThreeSolver.PartTwo(_input);
        result.Should().Be("48");
    }
}