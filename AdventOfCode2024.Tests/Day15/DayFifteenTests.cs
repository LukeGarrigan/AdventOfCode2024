using AdventOfCode2024.Day14;
using AdventOfCode2024.Day15;
using FluentAssertions;

namespace AdventOfCode2024.Tests.Day15;

public class DayFifteenTests
{
    private string _input = "";

    [SetUp]
    public void SetUp()
    {
        _input =
            """
            ##########
            #..O..O.O#
            #......O.#
            #.OO..O.O#
            #..O@..O.#
            #O#..O...#
            #O..O..O.#
            #.OO.O.OO#
            #....O...#
            ##########

            <vv>^<v^>v>^vv^v>v<>v^v<v<^vv<<<^><<><>>v<vvv<>^v^>^<<<><<v<<<v^vv^v>^
            vvv<<^>^v^^><<>>><>^<<><^vv^^<>vvv<>><^^v>^>vv<>v<<<<v<^v>^<^^>>>^<v<v
            ><>vv>v^v^<>><>>>><^^>vv>v<^^^>>v^v^<^^>v^^>v^<^v>v<>>v^v^<v>v^^<^^vv<
            <<v<^>>^^^^>>>v^<>vvv^><v<<<>^^^vv^<vvv>^>v<^^^^v<>^>vvvv><>>v^<<^^^^^
            ^><^><>>><>^^<<^^v>>><^<v>^<vv>>v>>>^v><>^v><<<<v>>v<v<v>vvv>^<><<>^><
            ^>><>^v<><^vvv<^^<><v<<<<<><^v<<<><<<^^<v<^^^><^>>^<v^><<<^>>^v<v^v<v^
            >^>>^v>vv>^<<^v<>><<><<v<<v><>v<^vv<<<>^^v^>^^>>><<^v>>v^v><^^>>^<>vv^
            <><^^>^^^<><vvvvv^v<v<<>^v<v>v<<^><<><<><<<^^<<<^<<>><<><^^^>^^<>^>v<>
            ^^>vv<^v^v<vv>^<><v<^v>^^^>>>^^vvv^>vvv<>>>^<^>>>>>^<<^v>^vvv<>^<><<v>
            v^^>>><<^^<>>^v^<v^vv<>v^<<>^<^v^v><^<<<><<^<v><v<>vv>>v><v^<vv<>v^<<^
            """;
    }

//     [Test]
//     public void Should_Move_Bot_Right()
//     {
//         var smallerInput = """
//                            ########
//                            #.@.OO.#
//                            ##..O..#
//                            #...O..#
//                            #.#.O..#
//                            #...O..#
//                            #......#
//                            ########
//
//                            >>>>
//                            """;
//         var solver = new DayFifteenSolver();
//         solver.PartOne(smallerInput.ToLines()).Should().Be("#..@OO.#");
//     }
//
//
//     [Test]
//     public void Should_Move_Box_Right_And_Push_Others()
//     {
//         var smallerInput = """
//                            ########
//                            #.@OOO.#
//                            ##..O..#
//                            #...O..#
//                            #.#.O..#
//                            #...O..#
//                            #......#
//                            ########
//
//                            >>>>
//                            """;
//         var solver = new DayFifteenSolver();
//         solver.PartOne(smallerInput.ToLines()).Should().Be("#..@OOO#");
//     }
//
//     [Test]
//     public void Should_Not_Move_Boxes_As_Ends_In_Wall()
//     {
//         var smallerInput = """
//                            ########
//                            #.@OOOO#
//                            ##..O..#
//                            #...O..#
//                            #.#.O..#
//                            #...O..#
//                            #......#
//                            ########
//
//                            >>>>
//                            """;
//         var solver = new DayFifteenSolver();
//         solver.PartOne(smallerInput.ToLines()).Should().Be("#.@OOOO#");
//     }
//
//     [Test]
//     public void Should_Move_Bot_Left_And_Push_Others()
//     {
//         var smallerInput = """
//                            ########
//                            #.O@OO.#
//                            ##..O..#
//                            #...O..#
//                            #.#.O..#
//                            #...O..#
//                            #......#
//                            ########
//
//                            <<<<
//                            """;
//         var solver = new DayFifteenSolver();
//         solver.PartOne(smallerInput.ToLines()).Should().Be("#O@.OO.#");
//     }
//
//
//     [Test]
//     public void Should_Move_Bot_Up_And_Push_Others()
//     {
//         var smallerInput = """
//                            ########
//                            #@O.OO.#
//                            #O..O..#
//                            #O..O..#
//                            #.#.O..#
//                            #...O..#
//                            #......#
//                            ########
//
//                            vvvv 
//                            """;
//         var solver = new DayFifteenSolver();
//         solver.PartOne(smallerInput.ToLines());
//     }
//
    [Test]
    public void Should_Handle_Small_Input()
    {
        var smallerInput = """
                           ########
                           #..O.O.#
                           ##@.O..#
                           #...O..#
                           #.#.O..#
                           #...O..#
                           #......#
                           ########

                           <^^>>>vv<v>>v<<
                           """;
        var solver = new DayFifteenSolver();
        solver.PartOne(smallerInput.ToLines()).Should().Be("2028");
    }

    [Test]
    public void Should_Solve_First_Real_Example()
    {
        var solver = new DayFifteenSolver();

        var biggerInput = """
                          ##########
                          #..O..O.O#
                          #......O.#
                          #.OO..O.O#
                          #..O@..O.#
                          #O#..O...#
                          #O..O..O.#
                          #.OO.O.OO#
                          #....O...#
                          ##########

                          <vv>^<v^>v>^vv^v>v<>v^v<v<^vv<<<^><<><>>v<vvv<>^v^>^<<<><<v<<<v^vv^v>^
                          vvv<<^>^v^^><<>>><>^<<><^vv^^<>vvv<>><^^v>^>vv<>v<<<<v<^v>^<^^>>>^<v<v
                          ><>vv>v^v^<>><>>>><^^>vv>v<^^^>>v^v^<^^>v^^>v^<^v>v<>>v^v^<v>v^^<^^vv<
                          <<v<^>>^^^^>>>v^<>vvv^><v<<<>^^^vv^<vvv>^>v<^^^^v<>^>vvvv><>>v^<<^^^^^
                          ^><^><>>><>^^<<^^v>>><^<v>^<vv>>v>>>^v><>^v><<<<v>>v<v<v>vvv>^<><<>^><
                          ^>><>^v<><^vvv<^^<><v<<<<<><^v<<<><<<^^<v<^^^><^>>^<v^><<<^>>^v<v^v<v^
                          >^>>^v>vv>^<<^v<>><<><<v<<v><>v<^vv<<<>^^v^>^^>>><<^v>>v^v><^^>>^<>vv^
                          <><^^>^^^<><vvvvv^v<v<<>^v<v>v<<^><<><<><<<^^<<<^<<>><<><^^^>^^<>^>v<>
                          ^^>vv<^v^v<vv>^<><v<^v>^^^>>>^^vvv^>vvv<>>>^<^>>>>>^<<^v>^vvv<>^<><<v>
                          v^^>>><<^^<>>^v^<v^vv<>v^<<>^<^v^v><^<<<><<^<v><v<>vv>>v><v^<vv<>v^<<^
                          """;
        var result = solver.PartOne(biggerInput.ToLines());
        result.Should().Be("10092");
    }
}