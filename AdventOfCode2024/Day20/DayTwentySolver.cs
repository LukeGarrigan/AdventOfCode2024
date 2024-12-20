namespace AdventOfCode2024.Day20;

public class DayTwentySolver : ISolver
{
    public string PartOne(string[] input)
    {
        var grid = input.ToCharGrid();

        (int row, int col) start = (0, 0);
        (int row, int col) goal = (0, 0);

        for (var i = 0; i < grid.Length; i++)
        {
            for (var j = 0; j < grid[0].Length; j++)
            {
                var current = grid[i][j];

                if (current == 'S')
                {
                    start.row = i;
                    start.col = j;
                }
                else if (current == 'E')
                {
                    goal.row = i;
                    goal.col = j;
                }
            }
        }

        var scoreWithoutCheating = Solve(grid, start, goal);

        var total = 0;
        var totalPermutations = 0;
        (int previousRow, int previousCol) = (0, 0);
        for (var i = 0; i < grid.Length; i++)
        {
            for (var j = 0; j < grid[i].Length; j++)
            {
                if (totalPermutations % 1000 == 0)
                {
                    Console.WriteLine($"{totalPermutations}/ {grid.Length * grid[0].Length}");
                }

                if (grid[i][j] != '#') continue;
                grid[i][j] = '.';
                grid[previousRow][previousCol] = '#';

                previousRow = i;
                previousCol = j;
                var scoreWithCheating = Solve(grid, start, goal);
                if (scoreWithCheating <= scoreWithoutCheating - 100)
                {
                    total++;
                }

                totalPermutations++;
            }
        }

        return total.ToString();
    }

    public string PartTwo(string[] input)
    {
        var grid = input.ToCharGrid();

        (int row, int col) start = (0, 0);
        (int row, int col) goal = (0, 0);

        for (var i = 0; i < grid.Length; i++)
        {
            for (var j = 0; j < grid[0].Length; j++)
            {
                var current = grid[i][j];

                if (current == 'S')
                {
                    start.row = i;
                    start.col = j;
                    grid[i][j] = '.';
                }
                else if (current == 'E')
                {
                    goal.row = i;
                    goal.col = j;
                    grid[i][j] = '.';
                }
            }
        }

        var scoreWithoutCheating = Solve(grid, start, goal);


        var fromStart = Dist(grid, start);
        var fromEnd = Dist(grid, goal);

        var count = 0;
        foreach (var s in fromStart)
        {
            foreach (var e in fromEnd)
            {
                var dist = Math.Abs(s.Key.row - e.Key.row) + Math.Abs(s.Key.col - e.Key.col);
                if (dist <= 20)
                {
                    if (dist + s.Value + e.Value <= scoreWithoutCheating - 100)
                    {
                        count++;
                    }
                }
            }
        }

        return count.ToString();
    }

    private Dictionary<(int row, int col), int> Dist(char[][] grid, (int row, int col) start)
    {
        var dist = new Dictionary<(int row, int col), int>();
        var queue = new PriorityQueue<(int row, int col), int>();

        queue.Enqueue((start.row, start.col), 0);
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
                if (grid[i][j] != '#')
                {
                    dist.Add((i, j), int.MaxValue);
                }
            }
        }
        
        dist[(start.row, start.col)] = 0;

        while (queue.TryDequeue(out var current, out var priority))
        {
            foreach (var dir in dirs)
            {
                var nRow = current.row + dir.row;
                var nCol = current.col + dir.col;

                if (nRow >= 0 && nRow < grid.GetLength(0) && nCol >= 0 && nCol < grid.GetLength(0) &&
                    grid[nRow][nCol] != '#')
                {
                    if (dist[(nRow, nCol)] > dist[(current.row, current.col)] + 1)
                    {
                        queue.Enqueue((nRow, nCol), priority + 1);
                        dist[(nRow, nCol)] = dist[(current.row, current.col)] + 1;
                    }
                }
            }
        }

        return dist;
    }

    private int Solve(char[][] grid, (int row, int col) start, (int row, int col) goal)
    {
        var dist = new Dictionary<(int row, int col), int>();
        var queue = new PriorityQueue<(int row, int col), int>();

        queue.Enqueue((start.row, start.col), 0);
        var dirs = new (int row, int col)[]
        {
            (0, 1),
            (1, 0),
            (-1, 0),
            (0, -1),
        };

        for (var i = 0; i < grid.Length; i++)
        {
            for (var j = 0; j < grid[i].Length; j++)
            {
                if (grid[i][j] != '#')
                {
                    dist.Add((i, j), int.MaxValue);
                }
            }
        }
        
        dist[(start.row, start.col)] = 0;

        while (queue.TryDequeue(out var current, out var priority))
        {
            if (current.row == goal.row && current.col == goal.col)
            {
                return dist[(current.row, current.col)];
            }

            foreach (var dir in dirs)
            {
                var nRow = current.row + dir.row;
                var nCol = current.col + dir.col;

                if (nRow >= 0 && nRow < grid.GetLength(0) && nCol >= 0 && nCol < grid.GetLength(0) &&
                    grid[nRow][nCol] != '#')
                {
                    if (dist[(nRow, nCol)] > dist[(current.row, current.col)] + 1)
                    {
                        queue.Enqueue((nRow, nCol), priority + 1);
                        dist[(nRow, nCol)] = dist[(current.row, current.col)] + 1;
                    }
                }
            }
        }

        return -1;
    }
}