using System.Data;

namespace AdventOfCode2024.Day08;

public class DayEightSolver : ISolver
{
    public string PartOne(string[] lines)
    {
        char[][] grid = lines.ToCharGrid();

        List<(int row, int column, char antenna)> antennas = new();

        for (int row = 0; row < grid.Length; row++)
        {
            for (int column = 0; column < grid[0].Length; column++)
            {
                if (grid[row][column] != '.')
                {
                    antennas.Add((row, column, grid[row][column]));
                }
            }
        }

        var uniqueAntiNodes = new HashSet<(int row, int column)>();

        foreach (var antenna in antennas)
        {
            for (int row = 0; row < grid.Length; row++)
            {
                for (int column = 0; column < grid[0].Length; column++)
                {
                    if (antenna.row == row && antenna.column == column) continue;


                    if (grid[row][column] == antenna.antenna)
                    {
                        var differenceRow = row - antenna.row;
                        var differenceColumn = column - antenna.column;

                        var firstAntiNodeRow = row + differenceRow;
                        var firstAntiNodeColumn = column + differenceColumn;

                        if (firstAntiNodeColumn >= 0 && firstAntiNodeColumn < grid.Length && firstAntiNodeRow >= 0 &&
                            firstAntiNodeRow < grid[0].Length)
                        {
                            uniqueAntiNodes.Add((firstAntiNodeRow, firstAntiNodeColumn));
                        }


                        var secondAntiNodeRow = antenna.row + differenceRow * -1;
                        var secondAntiNodeColumn = antenna.column + differenceColumn * -1;

                        if (secondAntiNodeColumn >= 0 && secondAntiNodeColumn < grid.Length && secondAntiNodeRow >= 0 &&
                            secondAntiNodeRow < grid[0].Length)
                        {
                            uniqueAntiNodes.Add((secondAntiNodeRow, secondAntiNodeColumn));
                        }
                    }
                }
            }
        }

        return uniqueAntiNodes.Count.ToString();
    }

    public string PartTwo(string[] lines)
    {
        char[][] grid = lines.ToCharGrid();

        List<(int row, int column, char antenna)> antennas = new();

        for (int row = 0; row < grid.Length; row++)
        {
            for (int column = 0; column < grid[0].Length; column++)
            {
                if (grid[row][column] != '.')
                {
                    antennas.Add((row, column, grid[row][column]));
                }
            }
        }

        var uniqueAntiNodes = new HashSet<(int row, int column)>();

        foreach (var antenna in antennas)
        {
            for (int row = 0; row < grid.Length; row++)
            {
                for (int column = 0; column < grid[0].Length; column++)
                {
                    if (antenna.row == row && antenna.column == column) continue;


                    if (grid[row][column] == antenna.antenna)
                    {
                        uniqueAntiNodes.Add((row, column));
                        var differenceRow = row - antenna.row;
                        var differenceColumn = column - antenna.column;

                        var firstAntiNodeRow = row + differenceRow;
                        var firstAntiNodeColumn = column + differenceColumn;

                        while (firstAntiNodeColumn >= 0 && firstAntiNodeColumn < grid.Length && firstAntiNodeRow >= 0 &&
                               firstAntiNodeRow < grid[0].Length)
                        {
                            uniqueAntiNodes.Add((firstAntiNodeRow, firstAntiNodeColumn));
                            firstAntiNodeRow = firstAntiNodeRow + differenceRow;
                            firstAntiNodeColumn = firstAntiNodeColumn + differenceColumn;
                        }


                        var secondAntiNodeRow = antenna.row + differenceRow * -1;
                        var secondAntiNodeColumn = antenna.column + differenceColumn * -1;

                        while (secondAntiNodeColumn >= 0 && secondAntiNodeColumn < grid.Length &&
                               secondAntiNodeRow >= 0 &&
                               secondAntiNodeRow < grid[0].Length)
                        {
                            uniqueAntiNodes.Add((secondAntiNodeRow, secondAntiNodeColumn));

                            secondAntiNodeRow = secondAntiNodeRow + differenceRow * -1;
                            secondAntiNodeColumn = secondAntiNodeColumn + differenceColumn * -1;
                        }
                    }
                }
            }
        }

        return uniqueAntiNodes.Count.ToString();
    }
}