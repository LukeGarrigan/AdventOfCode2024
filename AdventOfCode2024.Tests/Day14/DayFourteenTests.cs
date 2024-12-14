using AdventOfCode2024.Day14;
using FluentAssertions;

namespace AdventOfCode2024.Tests.Day14;

public class DayFourteenTests
{
    private string _input = "";

    [SetUp]
    public void SetUp()
    {
        _input =
            """
            p=0,4 v=3,-3
            p=6,3 v=-1,-3
            p=10,3 v=-1,2
            p=2,0 v=2,-1
            p=0,0 v=1,3
            p=3,0 v=-2,-2
            p=7,6 v=-1,-3
            p=3,0 v=-1,-2
            p=9,3 v=2,3
            p=7,3 v=-1,2
            p=2,4 v=2,-3
            p=9,5 v=-3,-3
            """;
    }

    [Test]
    public void Should_Handle_First_Example()
    {
        var solver = new DayFourteenSolver(11, 7);
        _input = "p=2,4 v=2, -3";
        solver.PartOne(_input.ToLines());
    }

    [Test]
    public void Should_Solve_First_Real_Example()
    {
        var solver = new DayFourteenSolver(11, 7);
        var result = solver.PartOne(_input.ToLines());
        result.Should().Be("12");
    }
}