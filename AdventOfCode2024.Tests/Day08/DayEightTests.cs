using AdventOfCode2024.Day08;
using FluentAssertions;

namespace AdventOfCode2024.Tests.Day08;

public class DayEightTests
{
    private DayEightSolver _dayEightSolver = new();

    private string[] _input;

    [SetUp]
    public void SetUp()
    {
        _input =
        [
        "............",
        "........0...", // row 1 column 8 - this is our current node
        ".....0......", // row 2 column 5 - difference is +1 row -3 columns (two anti nodes: 1: row 2 + 1, column 5 -3, (row 3, 2), row 1 - 1, column 8 + 3, (row 0, column 11)
        ".......0....",
        "....0.......",
        "......A.....",
        "............",
        "............",
        "........A...",
        ".........A..",
        "............",
        "............"
        ];
    }

    [Test]
    public void Should_Solve_Part_One()
    {
        var result = _dayEightSolver.PartOne(_input);
        result.Should().Be("14");
    }

    [Test]
    public void Should_Solve_Part_Two()
    {
        var result = _dayEightSolver.PartTwo(_input);
        result.Should().Be("34");
    }
}