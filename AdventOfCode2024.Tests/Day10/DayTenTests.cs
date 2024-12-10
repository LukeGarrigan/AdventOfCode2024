using AdventOfCode2024.Day10;
using FluentAssertions;

namespace AdventOfCode2024.Tests.Day09;

public class DayTenTests
{
    private readonly DayTenSolver _dayTenSolver = new();

    private string[] _input;

    [SetUp]
    public void SetUp()
    {
        _input =
        [
            "89010123",
            "78121874",
            "87430965",
            "96549874",
            "45678903",
            "32019012",
            "01329801",
            "10456732"
        ];
        // _input =
        // [
        //     "..90..9",
        //     "...1.98",
        //     "...2..7",
        //     "6543456",
        //     "765.987",
        //     "876....",
        //     "987...."
        // ];
        // _input =
        // [
        //     "10..9..",
        //     "2...8..",
        //     "3...7..",
        //     "4567654",
        //     "...8..3",
        //     "...9..2",
        //     ".....01"
        // ];
        // _input =
        // [
        //     "...0...",
        //     "...1...",
        //     "...2...",
        //     "6543456",
        //     "7.....7",
        //     "8.....8",
        //     "9.....9"
        // ];

        // _input =
        // [
        //     ".....0.",
        //     "..4321.",
        //     "..5..2.",
        //     "..6543.",
        //     "..7..4.",
        //     "..8765.",
        //     "..9...."
        // ];
        _input =
        [
            "..90..9",
            "...1.98",
            "...2..7",
            "6543456",
            "765.987",
            "876....",
            "987...."
        ];
    }

    [Test]
    public void Should_Solve_Part_One()
    {
        var result = _dayTenSolver.PartOne(_input);
        result.Should().Be("36");
    }

    [Test]
    public void Should_Solve_Part_Two()
    {
        var result = _dayTenSolver.PartTwo(_input);
        result.Should().Be("13");
    }
}