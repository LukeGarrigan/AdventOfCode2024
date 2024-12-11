using AdventOfCode2024.Day11;
using FluentAssertions;

namespace AdventOfCode2024.Tests.Day11;

public class DayElevenTests
{

    private string[] _input;

    [SetUp]
    public void SetUp()
    {
        _input =
        [
            "0 1 10 99 999"
        ];
    }

    [Test]
    public void Should_Be_Correct_After_One_Blink()
    {
        var dayEleven = new DayElevenSolver(1);
        var result = dayEleven.PartOne(_input);
        result.Should().Be("7");
    }
    
    [Test]
    public void Should_Be_Correct_After_Six_Blinks()
    {
        var dayEleven = new DayElevenSolver(6);
        var result = dayEleven.PartOne(["125 17"]);
        result.Should().Be("22");
    }
    
    [Test]
    public void Should_Have_The_Correct_Stone_Count_After_25_Turns()
    {
        var dayEleven = new DayElevenSolver(25);
        var result = dayEleven.PartOne(["125 17"]);
        result.Should().Be("55312");
    }
}