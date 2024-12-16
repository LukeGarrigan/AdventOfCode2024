using System.Collections;
using System.Data;
using System.Security.Cryptography;

namespace AdventOfCode2024.Day15;

public class DaySixteenSolver : ISolver
{
    public string PartOne(string[] input)
    {
        var grid = input.ToCharGrid();

        var dist = new Dictionary<(int row, int col, int dir), int>();
        var queue = new PriorityQueue<(int row, int col, int dir), int>();

        (int row, int col) pos = (0, 0);
        (int row, int col) goal = (0, 0);
        for (var i = 0; i < grid.Length; i++)
        {
            for (var j = 0; j < grid[i].Length; j++)
            {
                if (grid[i][j] == 'S')
                {
                    pos.row = i;
                    pos.col = j;
                }

                if (grid[i][j] == 'E')
                {
                    goal.row = i;
                    goal.col = j;
                }
            }
        }

        dist[(pos.row, pos.col, 0)] = 0;
        queue.Enqueue((pos.row, pos.col, 0), 0);

        for (var row = 0; row < grid.Length; row++)
        {
            for (var col = 0; col < grid[row].Length; col++)
            {
                for (var dir = 0; dir < 4; dir++)
                {
                    if (grid[pos.row][pos.col] != '#')
                    {
                        if (row != pos.row || col != pos.col || dir != 0)
                        {
                            dist.Add((row, col, dir), int.MaxValue);
                            queue.Enqueue((row, col, dir), int.MaxValue);
                        }
                    }
                }
            }
        }

        while (queue.Count > 0)
        {
            var current = queue.Dequeue();

            if (current.row == goal.row && current.col == goal.col)
            {
                return dist[(current.row, current.col, current.dir)].ToString();
            }

            // turning neighbours
            var currentCost = dist[(current.row, current.col, current.dir)];
            var rotatingCost = currentCost + 1000;

            var clockWise = (current.dir + 1) % 4;
            if (dist[(current.row, current.col, clockWise)] > rotatingCost)
            {
                dist[(current.row, current.col, clockWise)] = rotatingCost;
                queue.Enqueue((current.row, current.col, clockWise), rotatingCost);
            }

            var antiClockWise = (current.dir - 1 == -1) ? 3 : current.dir - 1;
            if (dist[(current.row, current.col, antiClockWise)] > rotatingCost)
            {
                dist[(current.row, current.col, antiClockWise)] = rotatingCost;
                queue.Enqueue((current.row, current.col, antiClockWise), rotatingCost);
            }

            // move forward
            var row = current.row;
            var col = current.col;
            if (current.dir == 0) col++;
            else if (current.dir == 1) row++;
            else if (current.dir == 2) col--;
            else if (current.dir == 3) row--;

            var movementCost = currentCost + 1;

            if (row < grid.Length && row >= 0 && col < grid[0].Length && col >= 0 &&
                dist[(row, col, current.dir)] > movementCost && grid[row][col] != '#')
            {
                dist[(row, col, current.dir)] = movementCost;
                queue.Enqueue((row, col, current.dir), movementCost);
            }
        }

        var min = Math.Min(
            Math.Min(dist[(1, grid[0].Length - 2, 0)], dist[(1, grid[0].Length - 2, 1)]),
            Math.Min(dist[(1, grid[0].Length - 2, 2)], dist[(1, grid[0].Length - 2, 3)]));
        return min.ToString();
    }


    public string PartTwo(string[] input)
    {
        var grid = input.ToCharGrid();

        var dist = new Dictionary<(int row, int col, int dir), int>();
        var queue = new PriorityQueue<(int row, int col, int dir), int>();
        var prev = new Dictionary<(int row, int col), HashSet<(int row, int col)>?>();
        var directions = new (int row, int col)[]
        {
            (0, 1),
            (1, 0),
            (0, -1),
            (-1, 0),
        };
        (int row, int col) pos = (0, 0);
        (int row, int col) goal = (0, 0);
        for (var i = 0; i < grid.Length; i++)
        {
            for (var j = 0; j < grid[i].Length; j++)
            {
                if (grid[i][j] == 'S')
                {
                    pos.row = i;
                    pos.col = j;
                }

                if (grid[i][j] == 'E')
                {
                    goal.row = i;
                    goal.col = j;
                }
            }
        }

        prev[(pos.row, pos.col)] = null;
        queue.Enqueue((pos.row, pos.col, 0), 0);

        for (var row = 0; row < grid.Length; row++)
        {
            for (var col = 0; col < grid[row].Length; col++)
            {
                for (var dir = 0; dir < 4; dir++)
                {
                    if (grid[pos.row][pos.col] != '#')
                    {
                        dist.Add((row, col, dir), int.MaxValue);
                    }
                }
            }
        }

        dist[(pos.row, pos.col, 0)] = 0;

        var count = 0;

        while (queue.Count > 0)
        {
            var current = queue.Dequeue();

            if (current.row == goal.row && current.col == goal.col)
            {
                break;
            }


            // turning neighbours
            var currentCost = dist[(current.row, current.col, current.dir)];
            var rotatingCost = currentCost + 1000;

            var clockWise = (current.dir + 1) % 4;
            if (dist[(current.row, current.col, clockWise)] > rotatingCost)
            {
                dist[(current.row, current.col, clockWise)] = rotatingCost;
                queue.Enqueue((current.row, current.col, clockWise), rotatingCost);
            }

            var antiClockWise = (current.dir - 1 == -1) ? 3 : current.dir - 1;
            if (dist[(current.row, current.col, antiClockWise)] > rotatingCost)
            {
                dist[(current.row, current.col, antiClockWise)] = rotatingCost;
                queue.Enqueue((current.row, current.col, antiClockWise), rotatingCost);
            }


            var (dr, dc) = directions[current.dir];
            var row = current.row + dr;
            var col = current.col + dc;
            var movementCost = currentCost + 1;

            if (grid[row][col] != '#')
            {
                if (dist[(row, col, current.dir)] > movementCost)
                {
                    dist[(row, col, current.dir)] = movementCost;

                    if (!prev.ContainsKey((row, col)))
                    {
                        prev[(row, col)] = new HashSet<(int, int)>();
                    }

                    prev[(row, col)].Add((current.row, current.col));

                    queue.Enqueue((row, col, current.dir), movementCost);
                }
                else if (dist[(row, col, current.dir)] == movementCost)
                {
                    prev[(row, col)].Add((current.row, current.col));
                }
            }
        }

        var from = new Queue<(int row, int col)>();
        HashSet<(int row, int col)> seen =
        [
            (goal.row, goal.col)
        ];

        from.Enqueue((goal.row, goal.col));

        while (from.Any())
        {
            var previousNode = from.Dequeue();

            seen.Add(previousNode);
            if (prev[(previousNode.row, previousNode.col)] == null)
            {
                Print(grid, seen);
                return seen.Count.ToString();
            }
            else
            {
                var neighbours = prev[(previousNode.row, previousNode.col)];
                foreach (var p in neighbours.Where(n => !seen.Contains(n)))
                {
                    from.Enqueue(p);
                }
            }
        }

        return seen.Count.ToString();
    }

    private static void Print(char[][] grid, HashSet<(int row, int col)> seen)
    {
        Console.WriteLine();
        for (var i = 0; i < grid.Length; i++)
        {
            Console.WriteLine();
            for (var j = 0; j < grid[i].Length; j++)
            {
                if (seen.Contains((i, j)))
                {
                    Console.Write("O");
                }
                else
                {
                    Console.Write(grid[i][j]);
                }
            }
        }

        Console.WriteLine();
    }
}