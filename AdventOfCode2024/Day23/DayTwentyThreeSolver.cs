namespace AdventOfCode2024.Day23;

public class DayTwentyThreeSolver : ISolver
{
    public string PartOne(string[] input)
    {
        var connections = GetConnections(input);
        var lans = new HashSet<string>();
        foreach (var connection in connections)
        {
            var node1 = connection.Key;
            foreach (var node2 in connection.Value)
            {
                foreach (var node3 in connections[node2])
                {
                    if (connections[node3].Contains(node1))
                    {
                        var lan = string
                            .Join("-", new List<string>() { node1, node2, node3 }
                                .OrderByDescending(l => l));

                        if (node1.StartsWith("t") || node2.StartsWith("t") || node3.StartsWith("t"))
                        {
                            lans.Add(lan);
                        }
                    }
                }
            }
        }

        return lans.Count(l => l.Contains("t")).ToString();
    }

    private static Dictionary<string, HashSet<string>> GetConnections(string[] input)
    {
        Dictionary<string, HashSet<string>> connections = [];
        foreach (var connection in input)
        {
            var computer1 = connection.Split("-")[0];
            var computer2 = connection.Split("-")[1];

            if (!connections.ContainsKey(computer1))
            {
                connections[computer1] = [];
            }

            connections[computer1].Add(computer2);

            if (!connections.ContainsKey(computer2))
            {
                connections[computer2] = [];
            }

            connections[computer2].Add(computer1);
        }

        return connections;
    }

    public string PartTwo(string[] input)
    {
        throw new NotImplementedException();
    }
}