using System.Text;

namespace AdventOfCode2024.Day24;

public class DayTwentyFourSolver : ISolver
{
    record Gate
    {
        public string LeftWire { get; set; }
        public string RightWire { get; set; }
        public string Operation { get; set; }
        public string Output { get; set; }
    }

    public string PartOne(string[] input)
    {
        var i = 0;
        var line = input[i];
        Dictionary<string, int> outputs = [];
        while (line != "")
        {
            var parts = line.Split(":");
            outputs.Add(parts[0].Trim(), int.Parse(parts[1]));
            i++;
            line = input[i];
        }

        i++;

        var gates = new List<Gate>();
        for (; i < input.Length; i++)
        {
            var currentLine = input[i];

            var parts = currentLine.Split(" ");
            gates.Add(new Gate()
            {
                LeftWire = parts[0],
                Operation = parts[1],
                RightWire = parts[2],
                Output = parts[4]
            });
        }

        var queue = new Queue<Gate>();

        foreach (var gate in gates)
        {
            queue.Enqueue(gate);
        }

        while (queue.Any())
        {
            var currentGate = queue.Dequeue();

            if (!outputs.ContainsKey(currentGate.LeftWire) || !outputs.ContainsKey(currentGate.RightWire))
            {
                queue.Enqueue(currentGate);
                continue;
            }

            var leftWire = outputs[currentGate.LeftWire];
            var rightWire = outputs[currentGate.RightWire];

            if (currentGate.Operation == "AND")
            {
                outputs[currentGate.Output] = leftWire & rightWire;
            }
            else if (currentGate.Operation == "OR")
            {
                outputs[currentGate.Output] = leftWire | rightWire;
            }
            else if (currentGate.Operation == "XOR")
            {
                outputs[currentGate.Output] = leftWire ^ rightWire;
            }
        }

        var sb = new StringBuilder();

        var zs = gates.Where(g => g.Output.StartsWith("z"))
                                 .OrderBy(g => g.Output).ToList();
        for (i = zs.Count() - 1; i >= 0; i--)
        {
            sb.Append(outputs[zs[i].Output]);
        }

        return Convert.ToInt64(sb.ToString(), 2).ToString();
    }

    public string PartTwo(string[] input)
    {
        throw new NotImplementedException();
    }
}