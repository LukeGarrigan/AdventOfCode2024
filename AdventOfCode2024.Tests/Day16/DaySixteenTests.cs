using AdventOfCode2024.Day15;
using FluentAssertions;

namespace AdventOfCode2024.Tests.Day15;

public class DaySixteenTests
{
    private string _input = "";

    [SetUp]
    public void SetUp()
    {
        _input =
            """
            ###############
            #.......#....E#
            #.#.###.#.###.#
            #.....#.#...#.#
            #.###.#####.#.#
            #.#.#.......#.#
            #.#.#####.###.#
            #...........#.#
            ###.#.#####.#.#
            #...#.....#.#.#
            #.#.#.###.#.#.#
            #.....#...#.#.#
            #.###.#.#.#.#.#
            #S..#.....#...#
            ###############
            """;
    }

    [Test]
    public void Should_Solve_Small_Maze()
    {
        var solver = new DaySixteenSolver();
        solver.PartOne(_input.ToLines()).Should().Be("7036");
    }

    [Test]
    public void Should_Handle_Bigger_Maze()
    {
        var input = """
                    #################
                    #...#...#...#..E#
                    #.#.#.#.#.#.#.#.#
                    #.#.#.#...#...#.#
                    #.#.#.#.###.#.#.#
                    #...#.#.#.....#.#
                    #.#.#.#.#.#####.#
                    #.#...#.#.#.....#
                    #.#.#####.#.###.#
                    #.#.#.......#...#
                    #.#.###.#####.###
                    #.#.#...#.....#.#
                    #.#.#.#####.###.#
                    #.#.#.........#.#
                    #.#.#.#########.#
                    #S#.............#
                    #################
                    """;
        var solver = new DaySixteenSolver();
        solver.PartOne(_input.ToLines()).Should().Be("7036");
    }
    
    [Test]
    public void Should_Solve_Small_For_Part_Two()
    {
        var solver = new DaySixteenSolver();
        solver.PartTwo(_input.ToLines()).Should().Be("45");
    }

    [Test]
    public void Should_Solve_Big_Example_For_Two()
    {
        
        var input = """
                    #################
                    #...#...#...#..E#
                    #.#.#.#.#.#.#.#.#
                    #.#.#.#...#...#.#
                    #.#.#.#.###.#.#.#
                    #...#.#.#.....#.#
                    #.#.#.#.#.#####.#
                    #.#...#.#.#.....#
                    #.#.#####.#.###.#
                    #.#.#.......#...#
                    #.#.###.#####.###
                    #.#.#...#.....#.#
                    #.#.#.#####.###.#
                    #.#.#.........#.#
                    #.#.#.#########.#
                    #S#.............#
                    #################
                    """;
        var solver = new DaySixteenSolver();
        solver.PartTwo(input.ToLines()).Should().Be("64");
    }
}