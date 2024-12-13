using System.Data;

namespace AdventOfCode2024.Day12;

public class DayTwelveSolver : ISolver
{
    public string PartOne(string[] lines)
    {
        var grid = lines.ToCharGrid();

        var seen = new HashSet<(int row, int col)>();
        var total = 0;
        for (var row = 0; row < grid.Length; row++)
        {
            for (var col = 0; col < grid[0].Length; col++)
            {
                if (seen.Contains((row, col)))
                {
                    continue;
                }

                var area = 0;
                var perimeter = 0;

                var queue = new Queue<(int row, int col)>();
                queue.Enqueue((row, col));
                seen.Add((row, col));
                while (queue.Any())
                {
                    var current = queue.Dequeue();

                    area++;
                    var neighbours = GetNeighbours((current.row, current.col), grid);
                    var matchingNeighbours = neighbours
                        .Where(n => grid[n.row][n.col] == grid[current.row][current.col]).ToList();

                    perimeter += 4 - matchingNeighbours.Count;

                    foreach (var neighbour in matchingNeighbours)
                    {
                        if (!seen.Contains(neighbour))
                        {
                            queue.Enqueue(neighbour);
                            seen.Add(neighbour);
                        }
                    }
                }

                Console.WriteLine($"{area} * {perimeter} = {area * perimeter}");
                total += area * perimeter;
            }
        }

        return total.ToString();
    }

    public string PartTwo(string[] lines)
    {
        var grid = lines.ToCharGrid();

        var seen = new HashSet<(int row, int col)>();
        var total = 0;
        for (var row = 0; row < grid.Length; row++)
        {
            for (var col = 0; col < grid[0].Length; col++)
            {
                if (seen.Contains((row, col)))
                {
                    continue;
                }

                var area = 0;
                var perimeter = 0;

                var queue = new Queue<(int row, int col)>();
                queue.Enqueue((row, col));
                seen.Add((row, col));
                while (queue.Any())
                {
                    var current = queue.Dequeue();

                    area++;
                    var neighbours = GetNeighbours((current.row, current.col), grid);
                    var matchingNeighbours = neighbours
                        .Where(n => grid[n.row][n.col] == grid[current.row][current.col]).ToList();

                    // perimeter += 4 - matchingNeighbours.Count;

                    foreach (var neighbour in matchingNeighbours)
                    {
                        if (!seen.Contains(neighbour))
                        {
                            queue.Enqueue(neighbour);
                            seen.Add(neighbour);
                        }
                    }
                }

                Console.WriteLine($"{area} * {perimeter} = {area * perimeter}");
                // total += area * perimeter;
            }
        }

        return total.ToString();
    }

    private List<(int row, int col)> GetNeighbours((int row, int col) current, char[][] map)
    {
        var list = new List<(int row, int col)>();
        if (current.row - 1 >= 0)
        {
            list.Add((current.row - 1, current.col));
        }

        if (current.row + 1 < map.Length)
        {
            list.Add((current.row + 1, current.col));
        }

        if (current.col + 1 < map[current.row].Length)
        {
            list.Add((current.row, current.col + 1));
        }

        if (current.col - 1 >= 0)
        {
            list.Add((current.row, current.col - 1));
        }

        return list;
    }
}