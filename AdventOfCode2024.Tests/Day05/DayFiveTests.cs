using AdventOfCode2024.Day05;
using FluentAssertions;

namespace AdventOfCode2024.Tests.Day05;

public class DayFiveTests
{
    private DayFiveSolver _dayFiveSolver = new();

    private string[] _input;

    [SetUp]
    public void SetUp()
    {
        _input =
        [
            "47|53",
            "97|13",
            "97|61",
            "97|47",
            "75|29",
            "61|13",
            "75|53",
            "29|13",
            "97|29",
            "53|29",
            "61|53",
            "97|53",
            "61|29",
            "47|13",
            "75|47",
            "97|75",
            "47|61",
            "75|61",
            "47|29",
            "75|13",
            "53|13",
            "",
            "75,47,61,53,29",
            "97,61,53,29,13",
            "75,29,13",
            "75,97,47,61,53",
            "61,13,29",
            "97,13,75,29,47"
        ];
    }

    [Test]
    public void Should_Solve_Part_One()
    {
        var result = _dayFiveSolver.PartOne(_input);
        result.Should().Be("143");
    }

    [Test]
    public void Should_Solve_Part_Two()
    {
        var result = _dayFiveSolver.PartTwo(_input);
        result.Should().Be("123");
    }
}