using AdventOfCode2024.Day19;
using FluentAssertions;

namespace AdventOfCode2024.Tests.Day19;

public class DayNineteenTests
{
    [Test]
    public void Should_Handle_Part_One()
    {
        var input = """
                    r, wr, b, g, bwu, rb, gb, br

                    brwrr
                    bggr
                    gbbr
                    rrbgbr
                    ubwu
                    bwurrg
                    brgr
                    bbrgwb
                    """;

        var solver = new DayNineteenSolver();
        solver.PartOne(input.ToLines()).Should().Be("6");
    }
    
    [Test]
    public void Should_Handle_Part_Two()
    {
        var input = """
                    r, wr, b, g, bwu, rb, gb, br

                    brwrr
                    bggr
                    gbbr
                    rrbgbr
                    ubwu
                    bwurrg
                    brgr
                    bbrgwb
                    """;

        var solver = new DayNineteenSolver();
        solver.PartTwo(input.ToLines()).Should().Be("16");
    }
}