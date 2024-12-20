using AdventOfCode2024.Day20;
using FluentAssertions;

namespace AdventOfCode2024.Tests.Day20;

public class DayTwentyTests
{
    [Test]
    public void Should_Handle_Part_One()
    {
        var input = """
                    ###############
                    #...#...#.....#
                    #.#.#.#.#.###.#
                    #S#...#.#.#...#
                    #######.#.#.###
                    #######.#.#...#
                    #######.#.###.#
                    ###..E#...#...#
                    ###.#######.###
                    #...###...#...#
                    #.#####.#.###.#
                    #.#...#.#.#...#
                    #.#.#.#.#.#.###
                    #...#...#...###
                    ###############
                    """;

        var solver = new DayTwentySolver();
        solver.PartOne(input.ToLines()).Should().Be("84");
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

        var solver = new DayTwentySolver();
        solver.PartTwo(input.ToLines()).Should().Be("16");
    }
}