namespace AdventOfCode2024.Day06;

public class DaySixSolver : ISolver
{
    enum Direction
    {
        Up,
        Right,
        Down,
        Left
    }

    public string PartOne(string[] lines)
    {
        char[][] maze = lines.Select(line => line.ToArray()).ToArray();

        var seenPositions = new HashSet<(Direction, int, int)>();

        var x = 0;
        var y = 0;
        var direction = Direction.Up;
        for (var i = 0; i < maze.Length; i++)
        {
            for (var j = 0; j < maze.Length; j++)
            {
                if (maze[i][j] == '^')
                {
                    x = j;
                    y = i;
                    seenPositions.Add((direction, i, j));
                }
            }
        }

        while (true)
        {
            try
            {
                if (direction == Direction.Up)
                {
                    if (maze[y - 1][x] == '#')
                    {
                        direction = Direction.Right;
                    }
                    else
                    {
                        y--;
                    }
                }
                else if (direction == Direction.Right)
                {
                    if (maze[y][x + 1] == '#')
                    {
                        direction = Direction.Down;
                    }
                    else
                    {
                        x++;
                    }
                }
                else if (direction == Direction.Down)
                {
                    if (maze[y + 1][x] == '#')
                    {
                        direction = Direction.Left;
                    }
                    else
                    {
                        y++;
                    }
                }
                else if (direction == Direction.Left)
                {
                    if (maze[y][x - 1] == '#')
                    {
                        direction = Direction.Up;
                    }
                    else
                    {
                        x--;
                    }
                }
            }
            catch
            {
                return seenPositions.DistinctBy(key => (key.Item2, key.Item3)).Count().ToString();
            }

            if (seenPositions.Contains((direction, y, x)))
            {
                return seenPositions.DistinctBy(key => (key.Item2, key.Item3)).Count().ToString();
            }
            else
            {
                seenPositions.Add((direction, y, x));
            }
        }
    }

    public string PartTwo(string[] lines)
    {
        char[][] maze = lines.Select(line => line.ToArray()).ToArray();

        var infiniteIdeas = 0;
        for (var i = 0; i < maze.Length; i++)
        {
            for (var j = 0; j < maze[i].Length; j++)
            {
                char[][] currentMaze = lines.Select(line => line.ToArray()).ToArray();

                if (currentMaze[i][j] == '.')
                {
                    currentMaze[i][j] = '#';

                    if (IsInfinite(currentMaze))
                    {

                        infiniteIdeas++;
                    }
                }
            }
        }

        return infiniteIdeas.ToString();
    }

    private static bool IsInfinite(char[][] maze)
    {
        var seenPositions = new HashSet<(Direction, int, int)>();

        var x = 0;
        var y = 0;
        var direction = Direction.Up;
        for (var i = 0; i < maze.Length; i++)
        {
            for (var j = 0; j < maze.Length; j++)
            {
                if (maze[i][j] == '^')
                {
                    x = j;
                    y = i;
                    seenPositions.Add((direction, i, j));
                }
            }
        }

        while (true)
        {
            try
            {
                if (direction == Direction.Up)
                {
                    if (maze[y - 1][x] == '#')
                    {
                        direction = Direction.Right;
                    }
                    else
                    {
                        y--;
                    }
                }
                else if (direction == Direction.Right)
                {
                    if (maze[y][x + 1] == '#')
                    {
                        direction = Direction.Down;
                    }
                    else
                    {
                        x++;
                    }
                }
                else if (direction == Direction.Down)
                {
                    if (maze[y + 1][x] == '#')
                    {
                        direction = Direction.Left;
                    }
                    else
                    {
                        y++;
                    }
                }
                else if (direction == Direction.Left)
                {
                    if (maze[y][x - 1] == '#')
                    {
                        direction = Direction.Up;
                    }
                    else
                    {
                        x--;
                    }
                }
            }
            catch
            {
                return false;
            }

            if (seenPositions.Contains((direction, y, x)))
            {
                return true;
            }
            else
            {
                seenPositions.Add((direction, y, x));
            }
        }
    }
}