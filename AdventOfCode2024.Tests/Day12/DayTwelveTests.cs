using AdventOfCode2024.Day12;
using FluentAssertions;

namespace AdventOfCode2024.Tests.Day12;

public class DayTwelveTests
{
    private string[] _input;

    [SetUp]
    public void SetUp()
    {
        _input =
        [
            "AAAA",
            "BBCD",
            "BBCC",
            "EEEC"
        ];
    }

    [Test]
    public void Should_Handle_First_Example()
    {
        var dayTwelve = new DayTwelveSolver();
        var result = dayTwelve.PartOne(_input);
        result.Should().Be("140");
    }

    [Test]
    public void Should_Handle_Second_Example()
    {
        var dayTwelve = new DayTwelveSolver();

        var input =
            """
            RRRRIICCFF
            RRRRIICCCF
            VVRRRCCFFF
            VVRCCCJFFF
            VVVVCJJCFE
            VVIVCCJJEE
            VVIIICJJEE
            MIIIIIJJEE
            MIIISIJEEE
            MMMISSJEEE
            """;

        var result = dayTwelve.PartOne(input.ToLines());
        result.Should().Be("1930");
    }

    [Test]
    public void Should_Handle_Part_Two_Easy_Example()
    {
        var dayTwelve = new DayTwelveSolver();
        var result = dayTwelve.PartTwo(_input);
        result.Should().Be("80");
    }
}