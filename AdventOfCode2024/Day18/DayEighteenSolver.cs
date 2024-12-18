using System.Data;
using System.Diagnostics.CodeAnalysis;

namespace AdventOfCode2024.Day18;

public class DayEighteenSolver : ISolver
{
    public string PartOne(string[] input)
    {
        var size = 71;
        var grid = new char[size, size];

        for (var row = 0; row < size; row++)
        {
            for (var col = 0; col < size; col++)
            {
                grid[row, col] = '.';
            }
        }

        for (var i = 0; i < 1024; i++)
        {
            var line = input[i];
            var coords = line.Split(",").Select(int.Parse);
            var x = coords.ElementAt(0);
            var y = coords.ElementAt(1);

            grid[y, x] = '#';
        }

        grid.Print();

        return ShortestPath(grid).ToString();
    }

    private int ShortestPath(char[,] grid)
    {
        var dist = new Dictionary<(int row, int col), int>();
        var queue = new PriorityQueue<(int row, int col), int>();

        dist[(0, 0)] = 0;
        queue.Enqueue((0, 0), 0);
        var dirs = new (int row, int col)[]
        {
            (0, 1),
            (1, 0),
            (-1, 0),
            (0, -1),
        };

        for (var i = 0; i < grid.GetLength(0); i++)
        {
            for (var j = 0; j < grid.GetLength(0); j++)
            {
                if (grid[i, j] != '#' && (i != 0 || j != 0))
                {
                    dist.Add((i, j), int.MaxValue);
                }
            }
        }

        while (queue.TryDequeue(out var current, out var priority))
        {
            if (current.row == grid.GetLength(0) - 1 && current.col == grid.GetLength(0) - 1)
            {
                return dist[(current.row, current.col)];
            }

            foreach (var dir in dirs)
            {
                var nRow = current.row + dir.row;
                var nCol = current.col + dir.col;

                if (nRow >= 0 && nRow < grid.GetLength(0) && nCol >= 0 && nCol < grid.GetLength(0) &&
                    grid[nRow, nCol] != '#')
                {
                    if (dist[(nRow, nCol)] > dist[(current.row, current.col)] + 1)
                    {
                        queue.Enqueue((nRow, nCol), priority + 1);
                        dist[(nRow, nCol)] = dist[(current.row, current.col)] + 1;
                    }
                }
            }
        }

        // 990 too high
        return -1;
    }


    public string PartTwo(string[] input)
    {
        var size = 71;
        var grid = new char[size, size];

        for (var row = 0; row < size; row++)
        {
            for (var col = 0; col < size; col++)
            {
                grid[row, col] = '.';
            }
        }

        for (var i = 0; i < input.Length; i++)
        {
            var line = input[i];
            var coords = line.Split(",").Select(int.Parse);
            var x = coords.ElementAt(0);
            var y = coords.ElementAt(1);

            grid[y, x] = '#';

            if (ShortestPath(grid) == -1)
            {
                return (x, y).ToString();
            }
        }

        return "";
        
    }
}