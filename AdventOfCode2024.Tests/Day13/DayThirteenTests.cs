using AdventOfCode2024.Day13;
using FluentAssertions;

namespace AdventOfCode2024.Tests.Day13;

public class DayThirteenTests
{
    private string[] _input;

    [SetUp]
    public void SetUp()
    {
        _input =
        [
        "Button A: X+94, Y+34",
        "Button B: X+22, Y+67",
        "Prize: X=8400, Y=5400",
        "",
        "Button A: X+26, Y+66",
        "Button B: X+67, Y+21",
        "Prize: X=12748, Y=12176",
        "",
        "Button A: X+17, Y+86",
        "Button B: X+84, Y+37",
        "Prize: X=7870, Y=6450",
        "",
        "Button A: X+69, Y+23",
        "Button B: X+27, Y+71",
        "Prize: X=18641, Y=10279",
        ];
    }

    [Test]
    public void Should_Handle_First_Example()
    {
        var solver = new DayThirteenSolver();
        var result = solver.PartOne(_input);
        result.Should().Be("480");
    }
    
    [Test]
    public void Should_Handle_Part_Two()
    {
        var solver = new DayThirteenSolver();
        var result = solver.PartTwo(_input);
        result.Should().Be("480");
    }
}