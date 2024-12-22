using AdventOfCode2024.Day22;
using FluentAssertions;

namespace AdventOfCode2024.Tests.Day22;

public class DayTwentyTwoTests
{
    [Test]
    public void Should_Handle_Part_One()
    {
        var input = """
                    1
                    10
                    100
                    2024
                    """;

        var solver = new DayTwentyTwoSolver();
        solver.PartOne(input.ToLines()).Should().Be("37327623");
    }
    
    [Test]
    public void Should_Handle_Part_Two()
    {
        var input = """
                    1
                    2
                    3
                    2024
                    """;

        var solver = new DayTwentyTwoSolver();
        solver.PartTwo(input.ToLines()).Should().Be("23");
    }
}