using System.Numerics;

namespace AdventOfCode2024.Day07;

public class DaySevenSolver : ISolver
{
    private bool _isPartOne;

    public DaySevenSolver()
    {
        _isPartOne = true;
    }

    public string PartOne(string[] lines)
    {
        return FixBridge(lines);
    }

    public string PartTwo(string[] lines)
    {
        _isPartOne = false;
        return FixBridge(lines);
    }
    
    private string FixBridge(string[] lines)
    {
        BigInteger validTotal = 0;
        foreach (var line in lines)
        {
            var total = BigInteger.Parse(line.Split(":")[0]);
            var values = line.Split(":")[1].Split(" ").Where(l => l != "").Select(BigInteger.Parse).ToList();

            List<BigInteger> computedResults = [];
            DoCalculations(values, computedResults);
            if (computedResults.Any(r => r == total))
            {
                validTotal += total;
            }
        }

        return validTotal.ToString();
    }

    private void DoCalculations(List<BigInteger> values, List<BigInteger> computedResults)
    {
        TryOperators(0, values[0]);

        void Calculate(string op, int index, BigInteger currentTotal)
        {
            if (index == values.Count)
            {
                computedResults.Add(currentTotal);
                return;
            }

            var currentValue = values[index];
            if (op == "*")
            {
                currentTotal *= currentValue;
                TryOperators(index, currentTotal);
            }
            else if (op == "||")
            {
                currentTotal = BigInteger.Parse(currentTotal.ToString() + "" + currentValue.ToString());
                TryOperators(index, currentTotal);
            }
            else
            {
                currentTotal += currentValue;
                TryOperators(index, currentTotal);
            }
        }

        void TryOperators(int index, BigInteger currentTotal)
        {
            Calculate("*", index + 1, currentTotal);
            Calculate("+", index + 1, currentTotal);
            if (!_isPartOne)
            {
                Calculate("||", index + 1, currentTotal);
            }
        }
    }
}