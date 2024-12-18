using AdventOfCode2024.Day17;
using FluentAssertions;

namespace AdventOfCode2024.Tests.Day17;

public class DaySeventeenTests
{
    [Test]
    public void Should_Handle_One_Op()
    {
        var solver = new DaySeventeenSolver();

        var input = """
                    Register A: 0
                    Register B: 0
                    Register C: 9

                    Program: 2,6
                    """;
        solver.PartOne(input.ToLines());
        solver.RegisterB.Should().Be(1);
    }

    [Test]
    public void Should_Handle_Program_Output()
    {
        var solver = new DaySeventeenSolver();

        var input = """
                    Register A: 10
                    Register B: 0
                    Register C: 0

                    Program: 5,0,5,1,5,4
                    """;
        solver.PartOne(input.ToLines()).Should().Be("0,1,2");
    }


    [Test]
    public void Should_Handle_Multiple_Opcodes()
    {
        var solver = new DaySeventeenSolver();

        var input = """
                    Register A: 2024
                    Register B: 0
                    Register C: 0

                    Program: 0,1,5,4,3,0
                    """;
        solver.PartOne(input.ToLines()).Should().Be("4,2,5,6,7,7,7,7,3,1,0");

        solver.RegisterA.Should().Be(0);
    }

    [Test]
    public void Should_Handle_RegisterB_Changes()
    {
        var solver = new DaySeventeenSolver();

        var input = """
                    Register A: 0
                    Register B: 29
                    Register C: 0

                    Program: 1,7
                    """;
        solver.PartOne(input.ToLines());
        solver.RegisterB.Should().Be(26);
    }

    [Test]
    public void Should_Handle_Two_Register_Changes()
    {
        var solver = new DaySeventeenSolver();

        var input = """
                    Register A: 0
                    Register B: 2024
                    Register C: 43690

                    Program: 4,0
                    """;
        solver.PartOne(input.ToLines());
        solver.RegisterB.Should().Be(44354);
    }

    [Test]
    public void Should_Handle_Their_Example()
    {
        var solver = new DaySeventeenSolver();

        var input = """
                    Register A: 729
                    Register B: 0
                    Register C: 0

                    Program: 0,1,5,4,3,0
                    """;
        solver.PartOne(input.ToLines()).Should().Be("4,6,3,5,6,3,5,2,1,0");
    }

    [Test]
    public void Should_Handle_Example_For_Part_Two()
    {
        var solver = new DaySeventeenSolver();

        var input = """
                    Register A: 2024
                    Register B: 0
                    Register C: 0

                    Program: 0,3,5,4,3,0
                    """;
        solver.PartTwo(input.ToLines()).Should().Be("117440");
    }
}