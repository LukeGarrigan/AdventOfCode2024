using System.Text.RegularExpressions;

namespace AdventOfCode2024.Day14;

public class DayFourteenSolver : ISolver
{
    private readonly int _tilesWide;
    private readonly int _tilesTall;

    public DayFourteenSolver(int tilesWide, int tilesTall)
    {
        _tilesWide = tilesWide;
        _tilesTall = tilesTall;
    }

    class Robot
    {
        public int X { get; set; }
        public int Y { get; set; }
        public int Xs { get; set; }
        public int Ys { get; set; }

        public Robot(int x, int y, int xs, int ys)
        {
            X = x;
            Y = y;
            Xs = xs;
            Ys = ys;
        }
    }

    public string PartOne(string[] lines)
    {
        var robots = GetRobots(lines);

        var ticks = 100;
        for (var i = 0; i < ticks; i++)
        {
            foreach (var robot in robots)
            {
                var newX = robot.X + robot.Xs;
                var newY = robot.Y + robot.Ys;
                robot.X = ((newX % _tilesWide) + _tilesWide) % _tilesWide;
                robot.Y = ((newY % _tilesTall) + _tilesTall) % _tilesTall;
            }
        }

        var squares = new Dictionary<int, int>()
        {
            { 0, 0 },
            { 1, 0 },
            { 2, 0 },
            { 3, 0 },
        };

        foreach (var robot in robots)
        {
            if (robot.X != _tilesWide / 2 && robot.Y != _tilesTall / 2)
            {
                if (robot.X < _tilesWide / 2)
                {
                    // left side
                    if (robot.Y < _tilesTall / 2)
                    {
                        // top left
                        squares[0]++;
                    }
                    else
                    {
                        // bottom left
                        squares[2]++;
                    }
                }
                else
                {
                    // right side
                    if (robot.Y < _tilesTall / 2)
                    {
                        // top right
                        squares[1]++;
                    }
                    else
                    {
                        // bottom right
                        squares[3]++;
                    }
                }
            }
        }

        var total = 1;
        foreach (var square in squares)
        {
            total *= square.Value;
        }

        return total.ToString();
    }

    public string PartTwo(string[] lines)
    {
        var robots = GetRobots(lines);

        var ticks = 10000000000;

        var grid = new char[_tilesTall, _tilesWide];
        for (var i = 0; i < ticks; i++)
        {
            grid = new char[_tilesTall, _tilesWide];
            foreach (var robot in robots)
            {
                var newX = robot.X + robot.Xs;
                var newY = robot.Y + robot.Ys;
                robot.X = ((newX % _tilesWide) + _tilesWide) % _tilesWide;
                robot.Y = ((newY % _tilesTall) + _tilesTall) % _tilesTall;
                grid[robot.Y, robot.X] = '#';
            }


            var contiguous = 0;
            for (var row = 0; row < _tilesTall; row++)
            {
                var columnsInARow = 0;
                for (var col = 0; col < _tilesWide; col++)
                {
                    if (grid[row, col] == '#')
                    {
                        columnsInARow++;
                    }
                    else
                    {
                        columnsInARow = 0;
                    }

                    if (columnsInARow > contiguous)
                    {
                        contiguous = columnsInARow;
                    }
                }
            }


            if (contiguous > 10)
            {
                Console.WriteLine($"Tick {i + 1}");
                for (var row = 0; row < _tilesTall; row++)
                {
                    for (var col = 0; col < _tilesWide; col++)
                    {
                        if (grid[row, col] == '#')
                        {
                            Console.Write(grid[row, col]);
                        }
                        else
                        {
                            Console.Write('.');
                        }
                    }

                    Console.WriteLine("");
                }
            }
        }

        return "";
    }

    private static List<Robot> GetRobots(string[] lines)
    {
        var robots = new List<Robot>();
        foreach (var line in lines)
        {
            var regex = new Regex(@"\d+|-\d+");
            var matches = regex.Matches(line);
            var (x, y, xs, ys) =
                (int.Parse(matches[0].Value),
                    int.Parse(matches[1].Value),
                    int.Parse(matches[2].Value),
                    int.Parse(matches[3].Value));
            robots.Add(new Robot(x, y, xs, ys));
        }

        return robots;
    }
}