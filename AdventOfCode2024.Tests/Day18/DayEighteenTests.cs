using AdventOfCode2024.Day18;

namespace AdventOfCode2024.Tests.Day18;

public class DayEighteenTests
{
    [Test]
    public void Should_Handle_Small_Example()
    {
        var input = """
                    5,4
                    4,2
                    4,5
                    3,0
                    2,1
                    6,3
                    2,4
                    1,5
                    0,6
                    3,3
                    2,6
                    5,1
                    1,2
                    5,5
                    2,5
                    6,5
                    1,4
                    0,4
                    6,4
                    1,1
                    6,1
                    1,0
                    0,5
                    1,6
                    2,0
                    """;

        var solver = new DayEighteenSolver();
        solver.PartOne(input.ToLines());
    }
}