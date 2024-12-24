using System.Collections;

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
        var connections = GetConnections(input);


        var biggest = new List<string>();
        foreach (var connection in connections)
        {
            var network = BiggestNetwork(connections, connection);

            if (network.Count > biggest.Count)
            {
                biggest = network;
            }
        }

        return string.Join(",", biggest.OrderBy(l => l));
    }

    private List<string> BiggestNetwork(Dictionary<string, HashSet<string>> connections,
        KeyValuePair<string, HashSet<string>> connection)
    {
        var queue = new Queue<(string, List<string>)>();

        var biggestNetwork = new List<string>() { connection.Key };
        queue.Enqueue((connection.Key, biggestNetwork));

        while (queue.Any())
        {
            var node = queue.Dequeue();

            if (node.Item2.Count > biggestNetwork.Count)
            {
                biggestNetwork = node.Item2;
            }

            foreach (var nextNode in connections[node.Item1])
            {
                if (node.Item2.All(n => connections[nextNode].Contains(n)))
                {
                    var network = new List<string>(node.Item2) { nextNode };
                    queue.Enqueue((nextNode, network));
                }
            }
        }
        return biggestNetwork;
    }
}