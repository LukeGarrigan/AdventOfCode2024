using AdventOfCode2024.Day23;
using FluentAssertions;

namespace AdventOfCode2024.Tests.Day23;

public class DayTwentyThreeTests
{
    [Test]
    public void Should_Handle_Part_One()
    {
        var input = """
                    kh-tc
                    qp-kh
                    de-cg
                    ka-co
                    yn-aq
                    qp-ub
                    cg-tb
                    vc-aq
                    tb-ka
                    wh-tc
                    yn-cg
                    kh-ub
                    ta-co
                    de-co
                    tc-td
                    tb-wq
                    wh-td
                    ta-ka
                    td-qp
                    aq-cg
                    wq-ub
                    ub-vc
                    de-ta
                    wq-aq
                    wq-vc
                    wh-yn
                    ka-de
                    kh-ta
                    co-tc
                    wh-qp
                    tb-vc
                    td-yn
                    """;

        var solver = new DayTwentyThreeSolver();
        solver.PartOne(input.ToLines()).Should().Be("7");
    }

    
    [Test]
    public void Should_Handle_Part_Two()
    {
        var input = """
                    kh-tc
                    qp-kh
                    de-cg
                    ka-co
                    yn-aq
                    qp-ub
                    cg-tb
                    vc-aq
                    tb-ka
                    wh-tc
                    yn-cg
                    kh-ub
                    ta-co
                    de-co
                    tc-td
                    tb-wq
                    wh-td
                    ta-ka
                    td-qp
                    aq-cg
                    wq-ub
                    ub-vc
                    de-ta
                    wq-aq
                    wq-vc
                    wh-yn
                    ka-de
                    kh-ta
                    co-tc
                    wh-qp
                    tb-vc
                    td-yn
                    """;

        var solver = new DayTwentyThreeSolver();
        solver.PartTwo(input.ToLines()).Should().Be("co,de,ka,ta");
    }
}