using AdventOfCode2024.Day14;
using FluentAssertions;

namespace AdventOfCode2024.Tests.Day14;

public class DayFourteenTests
{
    private string[] _input;

    [SetUp]
    public void SetUp()
    {
        _input =
        [
        ];
    }

    [Test]
    public void Should_Handle_First_Example()
    {
        var solver = new DayFourteenSolver();
        var result = solver.PartOne(_input);
        result.Should().Be("something else");
    }
    
    [Test]
    public void Should_Handle_Part_Two()
    {
        var solver = new DayFourteenSolver();
        var result = solver.PartTwo(_input);
        result.Should().Be("something here too ");
    }
}